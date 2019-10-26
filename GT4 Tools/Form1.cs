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

namespace GT4_Random_Cars
{
    public partial class Form1 : Form
    {
        Mem m = new Mem();
        List<KeyValuePair<string, string>> cars = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, string>> tracks = new List<KeyValuePair<string, string>>();
        List<TextBox> txtCars = new List<TextBox>();
        Random random = new Random();
        int rnd = 0;
        int camType = 0;
        string oppCar1, oppCar2, oppCar3, oppCar4, oppCar5, oppCarLbl1, oppCarLbl2, oppCarLbl3, oppCarLbl4, oppCarLbl5, plrCar, plrCarLbl, track, trackLbl;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nudFOV.Value = 90; // Default game FOV
            cboCameraType.SelectedIndex = 0;

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
                using (StreamReader reader = new StreamReader("vehicles.csv"))
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
                            cars.Add(new KeyValuePair<string, string>(row[0], row[1]));
                        }
                    }
                }

                foreach (KeyValuePair<string, string> car in cars)
                {
                    cboPlrCar.Items.Add(car.Value);
                    cboCar1.Items.Add(car.Value);
                    cboCar2.Items.Add(car.Value);
                    cboCar3.Items.Add(car.Value);
                    cboCar4.Items.Add(car.Value);
                    cboCar5.Items.Add(car.Value);
                }

                cboPlrCar.SelectedIndex = 0;
                cboCar1.SelectedIndex = 0;
                cboCar2.SelectedIndex = 0;
                cboCar3.SelectedIndex = 0;
                cboCar4.SelectedIndex = 0;
                cboCar5.SelectedIndex = 0;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File 'vehicles.csv' not found. Please ensure this file is in the working directory and try again.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            try
            {
                using (StreamReader reader = new StreamReader("tracks.csv"))
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
                            tracks.Add(new KeyValuePair<string, string>(row[0], row[1]));
                        }
                    }
                }

                foreach (KeyValuePair<string, string> track in tracks)
                {
                    cboTrack.Items.Add(track.Value);
                }

                cboTrack.SelectedIndex = 0;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File 'tracks.csv' not found. Please ensure this file is in the working directory and try again.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
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

                if (openProc)
                {
                    m.writeMemory("0x21FDDCD4", "float", nudFOV.Value.ToString());
                    m.writeMemory("0x21FE1294", "float", nudFOV.Value.ToString());

                    if (camType == 1)
                    {
                        m.writeMemory("0x2034513C", "bytes", "0xFC 0x3F 0x01 0x3C"); // Set to GT3-like chase camera attachment
                    }
                    else
                    {
                        m.writeMemory("0x2034513C", "bytes", "0x80 0x3F 0x01 0x3C"); // Otherwise back to GT4 default
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
                }
            }
        }

        private void cboCameraType_SelectedIndexChanged(object sender, EventArgs e)
        {
            camType = cboCameraType.SelectedIndex;
        }
    }
}
