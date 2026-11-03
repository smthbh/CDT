using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace CDT
{
    public partial class Settingsform : Form
    {
        public Settingsform()
        {
            InitializeComponent();
        }

         private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comports.Items.Clear();
            comports.Items.AddRange(SerialPort.GetPortNames());
            comports.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UsePort=comports.Text;
            Properties.Settings.Default.UseBaud=baudrate.Value;
            Properties.Settings.Default.Save();
            this.Hide();
        }

        private void Settingsform_Load(object sender, EventArgs e)
        {
            comports.Text = Properties.Settings.Default.UsePort;
            baudrate.Value = Properties.Settings.Default.UseBaud;
            if (Properties.Settings.Default.Languageru == false)
            {
                this.Text = "Connection settings";
                label1.Text = "Com port:";
                label2.Text = "Baud rate:";
                button1.Text = "Save";
                button2.Text = "Cancel";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            comports.Text = Properties.Settings.Default.UsePort;
            baudrate.Value = Properties.Settings.Default.UseBaud;
        }
    }
}
