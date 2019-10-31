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
using Memory;

namespace GT4_Tools
{
    public partial class GT4Tools : Form
    {
        Mem m = new Mem();
        List<KeyValuePair<string, string>> cars = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> tracks = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> drivetrains = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> engines = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> exhausts = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> naTunes = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> superchargers = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> turbos = new List<KeyValuePair<string, string>>();
        List<TextBox> txtCars = new List<TextBox>();
        Random random = new Random();
        int rnd = 0, camType = 0;
        string cboPopulator, memWrite, selectedDrivetrain, selectedEngine, selectedExhaust, selectedNATune, selectedSupercharger, selectedTurbo;
        string drivetrain, engine, exhaust, naTune, supercharger, turbo, oppCar1, oppCar2, oppCar3, oppCar4, oppCar5, oppCarLbl1, oppCarLbl2, oppCarLbl3, oppCarLbl4, oppCarLbl5, plrCar, plrCarLbl, track, trackLbl;
        bool btnDrivetrainClicked, btnEngineClicked, btnExhaustClicked, btnNATuneClicked, btnSuperchargerClicked, btnTurboClicked, csvsLoaded;

        public GT4Tools()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
        }

        private void GT4Tools_Load(object sender, EventArgs e)
        {
            nudFOV.Value = Properties.Settings.Default.FOV;
            cboCameraType.SelectedIndex = Properties.Settings.Default.CameraSetting;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

            foreach (TextBox textBox in grpCars.Controls.OfType<TextBox>())
            {
                txtCars.Add(textBox);
            }

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

            foreach (KeyValuePair<string, string> car in cars)
            {
                cboPlrCar.Items.Add(car.Value);
                cboCar1.Items.Add(car.Value);
                cboCar2.Items.Add(car.Value);
                cboCar3.Items.Add(car.Value);
                cboCar4.Items.Add(car.Value);
                cboCar5.Items.Add(car.Value);
            }

            foreach (KeyValuePair<string, string> track in tracks)
            {
                cboTrack.Items.Add(track.Value);
            }

            foreach (KeyValuePair<string, string> drivetrain in drivetrains)
            {
                cboDrivetrain.Items.Add(drivetrain.Value);
            }

            foreach (KeyValuePair<string, string> engine in engines)
            {
                cboEngine.Items.Add(engine.Value);
            }

            foreach (KeyValuePair<string, string> exhaust in exhausts)
            {
                cboExhaust.Items.Add(exhaust.Value);
            }

            foreach (KeyValuePair<string, string> naTune in naTunes)
            {
                cboNATune.Items.Add(naTune.Value);
            }

            foreach (KeyValuePair<string, string> supercharger in superchargers)
            {
                cboSupercharger.Items.Add(supercharger.Value);
            }

            foreach (KeyValuePair<string, string> turbo in turbos)
            {
                cboTurbo.Items.Add(turbo.Value);
            }

            cboPlrCar.SelectedIndex = 0;
            cboCar1.SelectedIndex = 0;
            cboCar2.SelectedIndex = 0;
            cboCar3.SelectedIndex = 0;
            cboCar4.SelectedIndex = 0;
            cboCar5.SelectedIndex = 0;
            cboTrack.SelectedIndex = 0;

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
                    selectedDrivetrain = GetExistingPart("0x20A1F810", drivetrains);
                    selectedEngine = GetExistingPart("0x20A1F808", engines);
                    selectedExhaust = GetExistingPart("0x20A1F8A0", exhausts);
                    selectedNATune = GetExistingPart("0x20A1F878", naTunes);
                    selectedSupercharger = GetExistingPart("0x20A1F8D8", superchargers);
                    selectedTurbo = GetExistingPart("0x20A1F880", turbos);

                    if (chkCamera.Checked)
                    {
                        m.writeMemory("0x21FDDCD4", "float", nudFOV.Value.ToString());
                        m.writeMemory("0x21FE1294", "float", nudFOV.Value.ToString());

                        if (camType == 1)
                        {
                            m.writeMemory("0x2034513C", "bytes", "0xF0 0x3F 0x01 0x3C"); // Set to GT3-like chase camera attachment
                        }
                        else
                        {
                            m.writeMemory("0x2034513C", "bytes", "0x80 0x3F 0x01 0x3C"); // Otherwise back to GT4 default
                        }
                    }

                    if (chkPlrCar.Checked)
                    {
                        m.writeMemory("0x20A0BF70", "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A0BF70", "string", plrCar);
                    }

                    if (chkTrack.Checked)
                    {
                        m.writeMemory("0x20A0BE94", "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A0BE94", "string", track);
                    }

                    if (chkCar.Checked)
                    {

                        // If generating a new set of cars, null out any existing selection
                        // This is for if the new car string is shorter than prev (e.g. "VolkswagenGolf" to "AudiTT" would result in "AudiTTagenGolf" otherwise)
                        m.writeMemory("0x20A0BFD8", "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory("0x20A0C040", "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory("0x20A0C0A8", "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory("0x20A0C110", "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");
                        m.writeMemory("0x20A0C178", "bytes", "0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A0BFD8", "string", oppCar1);
                        m.writeMemory("0x20A0C040", "string", oppCar2);
                        m.writeMemory("0x20A0C0A8", "string", oppCar3);
                        m.writeMemory("0x20A0C110", "string", oppCar4);
                        m.writeMemory("0x20A0C178", "string", oppCar5);
                    }

                    if (btnDrivetrainClicked)
                    {
                        memWrite = MakeMemorySubstring(drivetrain);
                        m.writeMemory("0x20A1F810", "bytes", "0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A1F810", "bytes", memWrite);

                        btnDrivetrainClicked = false;
                    }

                    if (btnEngineClicked)
                    {
                        memWrite = MakeMemorySubstring(engine);
                        m.writeMemory("0x20A1F808", "bytes", "0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A1F808", "bytes", memWrite);

                        btnEngineClicked = false;
                    }

                    if (btnExhaustClicked)
                    {
                        memWrite = MakeMemorySubstring(exhaust);
                        m.writeMemory("0x20A1F8A0", "bytes", "0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A1F8A0", "bytes", memWrite);

                        btnExhaustClicked = false;
                    }

                    if (btnNATuneClicked)
                    {
                        memWrite = MakeMemorySubstring(naTune);
                        m.writeMemory("0x20A1F878", "bytes", "0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A1F878", "bytes", memWrite);

                        btnNATuneClicked = false;
                    }

                    if (btnSuperchargerClicked)
                    {
                        memWrite = MakeMemorySubstring(supercharger);
                        m.writeMemory("0x20A1F8D8", "bytes", "0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A1F8D8", "bytes", memWrite);

                        btnSuperchargerClicked = false;
                    }

                    if (btnTurboClicked)
                    {
                        memWrite = MakeMemorySubstring(turbo);
                        m.writeMemory("0x20A1F880", "bytes", "0x00 0x00 0x00 0x00");

                        m.writeMemory("0x20A1F880", "bytes", memWrite);

                        btnTurboClicked = false;
                    }
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

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public string GetExistingPart(string memAddress, List<KeyValuePair<string, string>> listToSearch)
        {
            // Read the memory of the existing part, flip the two bytes (e.g. 1234 -> 3412)
            cboPopulator = ByteArrayToString(m.readBytes(memAddress, 4));
            cboPopulator = cboPopulator.Substring(2, 2) + cboPopulator.Substring(0, 2);
            return listToSearch.FirstOrDefault(x => x.Key == cboPopulator).Value;
        }

        public string MakeMemorySubstring(string partString)
        {
            // Flip endianness of byte pair (e.g. 1234 -> 0x34 0x12)
            string memAddr1 = "0x" + partString.Substring(2, 2);
            string memAddr2 = "0x" + partString.Substring(0, 2);

            return memAddr1 + " " + memAddr2;
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

            return list;
        }
    }
}
