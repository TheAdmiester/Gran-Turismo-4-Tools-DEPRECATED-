using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using log4net;
using Memory;


namespace GT4_Tools
{
    public partial class GT4Tools : Form
    {
        Mem m = new Mem();
        Addresses addresses;// = new NTSCUAddresses();
        List<ComboBox> cboList1 = new List<ComboBox>();
        List<ComboBox> cboList2 = new List<ComboBox>();
        List<KeyValuePair<string, string>> cars = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> tracks = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> drivetrains = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> engines = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> exhausts = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> naTunes = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> superchargers = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> turbos = new List<KeyValuePair<string, string>>();
        List<List<KeyValuePair<string, string>>> globalList = new List<List<KeyValuePair<string, string>>>();
        List<TextBox> txtCars = new List<TextBox>();
        private static readonly ILog log = LogManager.GetLogger(typeof(GT4Tools));
        Random random = new Random();
        int rnd = 0, camType = 0;
        string cboPopulator, memWrite, selectedDrivetrain, selectedEngine, selectedExhaust, selectedNATune, selectedSupercharger, selectedTurbo;
        string drivetrain, engine, exhaust, naTune, supercharger, turbo, oppCar1, oppCar2, oppCar3, oppCar4, oppCar5, oppCarLbl1, oppCarLbl2, oppCarLbl3, oppCarLbl4, oppCarLbl5, plrCar, plrCarLbl, track, trackLbl, gameVer;
        bool btnDrivetrainClicked, btnEngineClicked, btnExhaustClicked, btnNATuneClicked, btnSuperchargerClicked, btnTurboClicked, csvsLoaded, hybridTabChanged, isLoading;
        bool essoClicked, marcosClicked, opelClicked;

        public GT4Tools()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
        }

        private void GT4Tools_Load(object sender, EventArgs e)
        {
            //File.WriteAllText("log.txt", string.Empty);
            nudFOV.Value = Properties.Settings.Default.FOV;
            cboCameraType.SelectedIndex = Properties.Settings.Default.CameraSetting;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                log.Info("Background worker started");
            }

            foreach (TextBox textBox in grpCars.Controls.OfType<TextBox>())
            {
                txtCars.Add(textBox);
            }

            log.Info("Cars list populated");

            try
            {
                cars = LoadCSV("vehicles", false);
                tracks = LoadCSV("tracks", false);
                drivetrains = LoadCSV("drivetrains", true);
                engines = LoadCSV("engines", true);
                exhausts = LoadCSV("exhausts", true);
                naTunes = LoadCSV("natunes", true);
                superchargers = LoadCSV("superchargers", true);
                turbos = LoadCSV("turbos", true);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred when loading CSV files. Please ensure the files are in the directory and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            csvsLoaded = true;

            PopulateGlobalList(tracks, drivetrains, engines, exhausts, naTunes, superchargers, turbos);
            PopulateCboList(cboList1, cboPlrCar, cboCar1, cboCar2, cboCar3, cboCar4, cboCar5);
            PopulateCboList(cboList2, cboTrack, cboDrivetrain, cboEngine, cboExhaust, cboNATune, cboSupercharger, cboTurbo);
 
            foreach (ComboBox cbo in cboList1)
            {
                PopulateComboBox(cbo, cars);
            }

            for (int i = 0; i < cboList2.Count; i++)
            {
                PopulateComboBox(cboList2[i], globalList[i]);
            }
            log.Info("Comboboxes populated");

            CheckGameVersion();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                int pID = m.getProcIDFromName("pcsx2");
                bool openProc = false;

                if (pID > 0)
                {
                    openProc = m.OpenProcess(pID);
                }

                if (openProc && csvsLoaded)
                {
                    if (m.readByte("0x206DE8C0") == 1)
                    {
                        isLoading = true;
                    }
                    else
                    {
                        isLoading = false;
                    }

                    if (hybridTabChanged)
                    {
                        selectedDrivetrain = GetExistingPart(addresses.Drivetrain, drivetrains, "drivetrain");
                        selectedEngine = GetExistingPart(addresses.Engine, engines, "engine");
                        selectedExhaust = GetExistingPart(addresses.Exhaust, exhausts, "exhaust");
                        selectedNATune = GetExistingPart(addresses.NATune, naTunes, "NA tune");
                        selectedSupercharger = GetExistingPart(addresses.Supercharger, superchargers, "supercharger");
                        selectedTurbo = GetExistingPart(addresses.Turbo, turbos, "turbo");

                        hybridTabChanged = false;
                    }

                    if (chkCamera.Checked)
                    {
                        m.writeMemory(Addresses.MEM_FOVA, "float", nudFOV.Value.ToString()); // Arcade mode FOV
                        m.writeMemory(Addresses.MEM_FOVG, "float", nudFOV.Value.ToString()); // GT Mode FOV
                        m.writeMemory(Addresses.MEM_FOVS, "float", nudFOV.Value.ToString()); // Special Condition Race FOV

                        if (camType == 1)
                        {
                            m.writeMemory(Addresses.MEM_CAM, "bytes", "0xF0 0x3F 0x01 0x3C"); // Set to GT3-like chase camera attachment
                        }
                        else
                        {
                            m.writeMemory(Addresses.MEM_CAM, "bytes", "0x80 0x3F 0x01 0x3C"); // Otherwise back to GT4 default
                        }
                    }

                    if (chkPlrCar.Checked && isLoading)
                    {
                        m.writeMemory(Addresses.MEM_PLR, "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");

                        m.writeMemory(Addresses.MEM_PLR, "string", plrCar);
                    }

                    if (chkTrack.Checked && isLoading)
                    {
                        m.writeMemory(Addresses.MEM_TRK, "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");

                        m.writeMemory(Addresses.MEM_TRK, "string", track);
                    }

                    if (chkCar.Checked && isLoading)
                    {

                        // If generating a new set of cars, null out any existing selection
                        // This is for if the new car string is shorter than prev (e.g. "VolkswagenGolf" to "AudiTT" would result in "AudiTTagenGolf" otherwise)
                        m.writeMemory(Addresses.MEM_CR1, "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory(Addresses.MEM_CR2, "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory(Addresses.MEM_CR3, "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory(Addresses.MEM_CR4, "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory(Addresses.MEM_CR5, "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");

                        m.writeMemory(Addresses.MEM_CR1, "string", oppCar1);
                        m.writeMemory(Addresses.MEM_CR2, "string", oppCar2);
                        m.writeMemory(Addresses.MEM_CR3, "string", oppCar3);
                        m.writeMemory(Addresses.MEM_CR4, "string", oppCar4);
                        m.writeMemory(Addresses.MEM_CR5, "string", oppCar5);
                    }

                    if (btnDrivetrainClicked)
                    {
                        memWrite = MakeMemorySubstring(drivetrain);
                        WriteMemory(addresses.Drivetrain, "bytes", "0x00 0x00 0x00 0x00");

                        WriteMemory(addresses.Drivetrain, "bytes", memWrite);

                        log.Info($"Wrote bytes {memWrite} to memory address {addresses.Drivetrain:X8}");

                        btnDrivetrainClicked = false;
                    }

                    if (btnEngineClicked)
                    {
                        memWrite = MakeMemorySubstring(engine);
                        WriteMemory(addresses.Engine, "bytes", "0x00 0x00 0x00 0x00");

                        WriteMemory(addresses.Engine, "bytes", memWrite);

                        log.Info($"Wrote bytes {memWrite} to memory address {addresses.Engine:X8}");

                        btnEngineClicked = false;
                    }

                    if (btnExhaustClicked)
                    {
                        memWrite = MakeMemorySubstring(exhaust);
                        WriteMemory(addresses.Exhaust, "bytes", "0x00 0x00 0x00 0x00");

                        WriteMemory(addresses.Exhaust, "bytes", memWrite);

                        log.Info($"Wrote bytes {memWrite} to memory address {addresses.Exhaust:X8}");

                        btnExhaustClicked = false;
                    }

                    if (btnNATuneClicked)
                    {
                        memWrite = MakeMemorySubstring(naTune);
                        WriteMemory(addresses.NATune, "bytes", "0x00 0x00 0x00 0x00");

                        WriteMemory(addresses.NATune, "bytes", memWrite);

                        log.Info($"Wrote bytes {memWrite} to memory address {addresses.NATune:X8}");

                        btnNATuneClicked = false;
                    }

                    if (btnSuperchargerClicked)
                    {
                        memWrite = MakeMemorySubstring(supercharger);
                        WriteMemory(addresses.Supercharger, "bytes", "0x00 0x00 0x00 0x00");

                        WriteMemory(addresses.Supercharger, "bytes", memWrite);

                        log.Info($"Wrote bytes {memWrite} to memory address {addresses.Supercharger:X8}");

                        btnSuperchargerClicked = false;
                    }

                    if (btnTurboClicked)
                    {
                        memWrite = MakeMemorySubstring(turbo);
                        WriteMemory(addresses.Turbo, "bytes", "0x00 0x00 0x00 0x00");

                        WriteMemory(addresses.Turbo, "bytes", memWrite);

                        log.Info($"Wrote bytes {memWrite} to memory address {addresses.Turbo:X8}");

                        btnTurboClicked = false;
                    }

                    if (essoClicked)
                    {
                        if (chkEsso.Checked)
                        {
                            m.writeMemory(Addresses.MEM_206, "string", "peug0002");
                            m.writeMemory(Addresses.MEM_GT1, "string", "toyt0018");
                            m.writeMemory(Addresses.MEM_SUP, "string", "toyt0035");
                        }
                        else
                        {
                            m.writeMemory(Addresses.MEM_206, "string", "peug0012");
                            m.writeMemory(Addresses.MEM_GT1, "string", "toyt0063");
                            m.writeMemory(Addresses.MEM_SUP, "string", "toyt0027");
                        }

                        essoClicked = false;
                    }

                    if (marcosClicked)
                    {
                        if (chkMarcos.Checked)
                        {
                            m.writeMemory(Addresses.MEM_MRC, "string", "rov10001");
                        }
                        else
                        {
                            m.writeMemory(Addresses.MEM_MRC, "string", "mrcs0001");
                        }

                        marcosClicked = false;
                    }

                    if (opelClicked)
                    {
                        if (chkOpel.Checked)
                        {
                            m.writeMemory(Addresses.MEM_CAL, "string", "vxhl0002");
                            m.writeMemory(Addresses.MEM_CRS, "string", "vxhl0003");
                            m.writeMemory(Addresses.MEM_SPS, "string", "vxhl0005");
                            m.writeMemory(Addresses.MEM_SPT, "string", "vxhl0006");
                            m.writeMemory(Addresses.MEM_TIG, "string", "vxhl0004");
                            m.writeMemory(Addresses.MEM_VEC, "string", "vxhl0007");
                        }
                        else
                        {
                            m.writeMemory(Addresses.MEM_CAL, "string", "opel0003");
                            m.writeMemory(Addresses.MEM_CRS, "string", "opel0005");
                            m.writeMemory(Addresses.MEM_SPS, "string", "opel0006");
                            m.writeMemory(Addresses.MEM_SPT, "string", "opel0007");
                            m.writeMemory(Addresses.MEM_TIG, "string", "opel0001");
                            m.writeMemory(Addresses.MEM_VEC, "string", "opel0004");
                        }
                    }
                }
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public string GetExistingPart(uint memAddress, List<KeyValuePair<string, string>> listToSearch, string carPart)
        {
            // Read the memory of the existing part, flip the two bytes (e.g. 1234 -> 3412)
            cboPopulator = ByteArrayToString(ReadMemoryBytes(memAddress, 4));
            cboPopulator = cboPopulator.Substring(2, 2) + cboPopulator.Substring(0, 2);

            string foundPart = listToSearch.FirstOrDefault(x => x.Key == cboPopulator).Value;
            if (foundPart != null)
            {
                log.Info(string.Format("Detected installed {0} part as {1}", carPart, foundPart));
            }
            else
            {
                log.Info(string.Format("Detected installed {0} part as stock/none", carPart));
            }

            return foundPart;
        }

        public string MakeMemorySubstring(string partString)
        {
            // Flip endianness of byte pair (e.g. 1234 -> 0x34 0x12)
            string memAddr1 = "0x" + partString.Substring(2, 2);
            string memAddr2 = "0x" + partString.Substring(0, 2);

            log.Info("Built memory substring " + memAddr1 + " " + memAddr2 + " from input part string " + partString);

            return memAddr1 + " " + memAddr2;
        }

        public void PopulateComboBox(ComboBox comboBox, List<KeyValuePair<string, string>> list)
        {
            foreach (KeyValuePair<string, string> item in list)
            {
                comboBox.Items.Add(item.Value);
            }

            comboBox.SelectedIndex = 0;
        }

        public void PopulateGlobalList(params List<KeyValuePair<string, string>>[] lists)
        {
            foreach (List<KeyValuePair<string, string>> list in lists)
            {
                globalList.Add(list);
            }
        }

        public void PopulateCboList(List<ComboBox> list, params ComboBox[] cbos)
        {
            foreach (ComboBox cbo in cbos)
            {
                list.Add(cbo);
            }
        }

        public List<KeyValuePair<string, string>> LoadCSV(string csvFile, bool flippedString)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            try
            {
                using (StreamReader reader = new StreamReader(csvFile + ".csv"))
                using (CsvParser csv = new CsvParser(reader))
                {
                    while (true)
                    {
                        string[] row = csv.Read();
                        if (row == null)
                        {
                            break;
                        }
                        else
                        {
                            if (flippedString) // Some of the CSVs have the name first, some have the value first - little workaround to load either 
                            {
                                list.Add(new KeyValuePair<string, string>(row[1], row[0]));
                            }
                            else
                            {
                                list.Add(new KeyValuePair<string, string>(row[0], row[1]));
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File '" + csvFile + ".csv' not found. Please ensure this file is in the working directory and try again.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            log.Info("File '" + csvFile + ".csv' successfully loaded");
            return list;
        }

        private bool WriteMemory(uint address, string type, string write) => m.writeMemory($"0x{address:X8}", type, write);

        private byte[] ReadMemoryBytes(uint address, long length) => m.readBytes($"0x{address:X8}", length);

        private void CheckGameVersion()
        {
            // Hook process once to check game version
            int pID = m.getProcIDFromName("pcsx2");
            bool openProc = false;
            if (pID > 0)
            {
                openProc = m.OpenProcess(pID);
            }

            if (openProc)
            {
                gameVer = m.readString("0x0E24C391");

                switch (gameVer)
                {
                    case GameVersions.NTSC_U:
                        addresses = new NTSCUAddresses();
                        chkEsso.Enabled = true;
                        chkMarcos.Enabled = true;
                        chkOpel.Enabled = true;
                        MessageBox.Show("Detected NTSC-U version: " + gameVer, "Detected version: " + gameVer, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        log.Info("Detected version " + gameVer + ", addresses = " + addresses.ToString());
                        break;

                    case GameVersions.PAL:
                        addresses = new PALAddresses();
                        chkEsso.Enabled = false;
                        chkMarcos.Enabled = false;
                        chkOpel.Enabled = false;
                        MessageBox.Show("Detected PAL version: " + gameVer, "Detected version: " + gameVer, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        log.Info("Detected version " + gameVer + ", addresses = " + addresses.ToString());
                        break;

                    default:
                        MessageBox.Show("Unsupported game version detected! Please load a supported game version and rescan.", "Unsupported version: " + gameVer, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Info("Unsupported version " + gameVer);
                        break;
                }
            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            chkCamera.Checked = true;
        }

        private void nudFOV_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FOV = (int)nudFOV.Value;
            Properties.Settings.Default.Save();
        }

        private void cboTurbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTurbo.SelectedIndex != 0)
            {
                btnTurbo.Enabled = true;
            }
            else
            {
                btnTurbo.Enabled = false;
            }
        }

        private void cboSupercharger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSupercharger.SelectedIndex != 0)
            {
                btnSupercharger.Enabled = true;
            }
            else
            {
                btnSupercharger.Enabled = false;
            }
        }

        private void cboNATune_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNATune.SelectedIndex != 0)
            {
                btnNATune.Enabled = true;
            }
            else
            {
                btnNATune.Enabled = false;
            }
        }

        private void cboExhaust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboExhaust.SelectedIndex != 0)
            {
                btnExhaust.Enabled = true;
            }
            else
            {
                btnTurbo.Enabled = false;
            }
        }

        private void cboEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEngine.SelectedIndex != 0)
            {
                btnEngine.Enabled = true;
            }
            else
            {
                btnEngine.Enabled = false;
            }
        }

        private void cboDrivetrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDrivetrain.SelectedIndex != 0)
            {
                btnDrivetrain.Enabled = true;
            }
            else
            {
                btnDrivetrain.Enabled = false;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                hybridTabChanged = true;

                if (drivetrains.FindIndex(x => x.Value == selectedDrivetrain) != -1)
                {
                    cboDrivetrain.SelectedIndex = drivetrains.FindIndex(x => x.Value == selectedDrivetrain);
                }
                else
                {
                    cboDrivetrain.SelectedIndex = 0;
                    btnDrivetrain.Enabled = false;
                }

                if (engines.FindIndex(x => x.Value == selectedEngine) != -1)
                {
                    cboEngine.SelectedIndex = engines.FindIndex(x => x.Value == selectedEngine);
                }
                else
                {
                    cboEngine.SelectedIndex = 0;
                    btnEngine.Enabled = false;
                }

                if (exhausts.FindIndex(x => x.Value == selectedExhaust) != -1)
                {
                    cboExhaust.SelectedIndex = exhausts.FindIndex(x => x.Value == selectedExhaust);
                }
                else
                {
                    cboExhaust.SelectedIndex = 0;
                    btnExhaust.Enabled = false;
                }

                if (naTunes.FindIndex(x => x.Value == selectedNATune) != -1)
                {
                    cboNATune.SelectedIndex = naTunes.FindIndex(x => x.Value == selectedNATune);
                }
                else
                {
                    cboNATune.SelectedIndex = 0;
                    btnNATune.Enabled = false;
                }

                if (superchargers.FindIndex(x => x.Value == selectedSupercharger) != -1)
                {
                    cboSupercharger.SelectedIndex = superchargers.FindIndex(x => x.Value == selectedSupercharger);
                }
                else
                {
                    cboSupercharger.SelectedIndex = 0;
                    btnSupercharger.Enabled = false;
                }

                if (turbos.FindIndex(x => x.Value == selectedTurbo) != -1)
                {
                    cboTurbo.SelectedIndex = turbos.FindIndex(x => x.Value == selectedTurbo);
                }
                else
                {
                    cboTurbo.SelectedIndex = 0;
                    btnTurbo.Enabled = false;
                }
            }
        }


        private void btnPlrGenerate_Click(object sender, EventArgs e)
        {
            chkPlrCar.Checked = true;

            rnd = random.Next(cars.Count);
            plrCar = cars[rnd].Key;
            plrCarLbl = cars[rnd].Value;

            txtPlrCar.Text = plrCarLbl;
        }

        private void btnCarsGenerate_Click(object sender, EventArgs e)
        {
            chkCar.Checked = true;

            rnd = random.Next(cars.Count);
            oppCar1 = cars[rnd].Key;
            oppCarLbl1 = cars[rnd].Value;

            rnd = random.Next(cars.Count);
            oppCar2 = cars[rnd].Key;
            oppCarLbl2 = cars[rnd].Value;

            rnd = random.Next(cars.Count);
            oppCar3 = cars[rnd].Key;
            oppCarLbl3 = cars[rnd].Value;

            rnd = random.Next(cars.Count);
            oppCar4 = cars[rnd].Key;
            oppCarLbl4 = cars[rnd].Value;

            rnd = random.Next(cars.Count);
            oppCar5 = cars[rnd].Key;
            oppCarLbl5 = cars[rnd].Value;

            txtCar1.Text = oppCarLbl1;
            txtCar2.Text = oppCarLbl2;
            txtCar3.Text = oppCarLbl3;
            txtCar4.Text = oppCarLbl4;
            txtCar5.Text = oppCarLbl5;
        }

        private void btnTrackGenerate_Click(object sender, EventArgs e)
        {
            chkTrack.Checked = true;

            rnd = random.Next(tracks.Count);

            track = tracks[rnd].Key;
            trackLbl = tracks[rnd].Value;

            txtTrack.Text = trackLbl;
        }

        private void btnManualPlrApply_Click(object sender, EventArgs e)
        {
            chkPlrCar.Checked = true;

            plrCar = cars[cboPlrCar.SelectedIndex].Key;
        }

        private void btnManualAIApply_Click(object sender, EventArgs e)
        {
            chkCar.Checked = true;

            oppCar1 = cars[cboCar1.SelectedIndex].Key;
            oppCar2 = cars[cboCar2.SelectedIndex].Key;
            oppCar3 = cars[cboCar3.SelectedIndex].Key;
            oppCar4 = cars[cboCar4.SelectedIndex].Key;
            oppCar5 = cars[cboCar5.SelectedIndex].Key;
        }


        private void btnManualTrackApply_Click(object sender, EventArgs e)
        {
            chkTrack.Checked = true;

            track = tracks[cboTrack.SelectedIndex].Key;
        }

        private void btnDrivetrain_Click(object sender, EventArgs e)
        {
            drivetrain = drivetrains[cboDrivetrain.SelectedIndex].Key;
            memWrite = MakeMemorySubstring(drivetrain);
            btnDrivetrainClicked = true;
        }

        private void btnTurbo_Click(object sender, EventArgs e)
        {
            turbo = turbos[cboTurbo.SelectedIndex].Key;

            btnTurboClicked = true;
        }

        private void btnSupercharger_Click(object sender, EventArgs e)
        {
            supercharger = superchargers[cboSupercharger.SelectedIndex].Key;

            btnSuperchargerClicked = true;
        }

        private void btnNATune_Click(object sender, EventArgs e)
        {
            naTune = naTunes[cboNATune.SelectedIndex].Key;

            btnNATuneClicked = true;
        }

        private void btnExhaust_Click(object sender, EventArgs e)
        {
            exhaust = exhausts[cboExhaust.SelectedIndex].Key;

            btnExhaustClicked = true;
        }

        private void btnEngine_Click(object sender, EventArgs e)
        {
            engine = engines[cboEngine.SelectedIndex].Key;

            btnEngineClicked = true;
        }

        private void cboCameraType_SelectedIndexChanged(object sender, EventArgs e)
        {
            camType = cboCameraType.SelectedIndex;

            Properties.Settings.Default.CameraSetting = camType;
            Properties.Settings.Default.Save();
        }

        private void chkEsso_CheckedChanged(object sender, EventArgs e)
        {
            essoClicked = true;
        }

        private void chkMarcos_CheckedChanged(object sender, EventArgs e)
        {
            marcosClicked = true;
        }

        private void chkOpel_CheckedChanged(object sender, EventArgs e)
        {
            opelClicked = true;
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            CheckGameVersion();
        }
    }
}
