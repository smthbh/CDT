using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace CDT
{
    public partial class Form1 : Form
    {
        byte count = 0;
        int count2 = 1;
        int oldval = 0;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            about = new AboutBox1();
            settings = new Settingsform();
        }
        AboutBox1 about;
        Settingsform settings;
        Form3 helpform;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + "        Ver:  " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            textBox1.Text = Properties.Settings.Default.UsePort;
            textBox2.Text = Properties.Settings.Default.UseBaud.ToString();
            dataGridView1.RowCount = 24;
            dataGridView1.Rows[0].Cells[1].Value = "1";
            dataGridView1.Rows[0].Cells[2].Value = "V5";
            dataGridView1.Rows[0].Cells[3].Value = "";
            dataGridView1.Rows[0].Visible = false;


            dataGridView1.Rows[1].Cells[1].Value = "2";
            dataGridView1.Rows[1].Cells[2].Value = "V51";
            dataGridView1.Rows[1].Cells[3].Value = "Oxygen sensor voltage";

            dataGridView1.Rows[2].Cells[1].Value = "5";
            dataGridView1.Rows[2].Cells[2].Value = "T";
            dataGridView1.Rows[2].Cells[3].Value = "Coolant temperature";

            dataGridView1.Rows[3].Cells[1].Value = "6";
            dataGridView1.Rows[3].Cells[2].Value = "V5";
            dataGridView1.Rows[3].Cells[3].Value = "Coolant temperature sensor voltage";

            dataGridView1.Rows[4].Cells[1].Value = "7";
            dataGridView1.Rows[4].Cells[2].Value = "V5";
            dataGridView1.Rows[4].Cells[3].Value = "TPS Voltage";

            dataGridView1.Rows[5].Cells[1].Value = "8";
            dataGridView1.Rows[5].Cells[2].Value = "V5";
            dataGridView1.Rows[5].Cells[3].Value = "Minimum TPS Voltage";

            dataGridView1.Rows[6].Cells[1].Value = "10";
            dataGridView1.Rows[6].Cells[2].Value = "V12";
            dataGridView1.Rows[6].Cells[3].Value = "Onboard Voltage";

            dataGridView1.Rows[7].Cells[1].Value = "11";
            dataGridView1.Rows[7].Cells[2].Value = "PSI";
            dataGridView1.Rows[7].Cells[3].Value = "MAP Value";

            dataGridView1.Rows[8].Cells[1].Value = "12";
            dataGridView1.Rows[8].Cells[2].Value = "%";
            dataGridView1.Rows[8].Cells[3].Value = "AIS Position Target";

            dataGridView1.Rows[9].Cells[1].Value = "14";
            dataGridView1.Rows[9].Cells[2].Value = "";
            dataGridView1.Rows[9].Cells[3].Value = "Adaptive Fuel Factor";

            dataGridView1.Rows[10].Cells[1].Value = "15";
            dataGridView1.Rows[10].Cells[2].Value = "PSI";
            dataGridView1.Rows[10].Cells[3].Value = "Barometric Pressure";

            dataGridView1.Rows[11].Cells[1].Value = "1";
            dataGridView1.Rows[11].Cells[2].Value = "RPM2";
            dataGridView1.Rows[11].Cells[3].Value = "Engine RPM";
            dataGridView1.Rows[11].Cells[5].Value = "22";

            dataGridView1.Rows[12].Cells[1].Value = "3";
            dataGridView1.Rows[12].Cells[2].Value = "RPM2";
            dataGridView1.Rows[12].Cells[3].Value = "Target Engine RPM";
            dataGridView1.Rows[12].Cells[5].Value = "22";

            dataGridView1.Rows[13].Cells[1].Value = "21";
            dataGridView1.Rows[13].Cells[2].Value = "ADV";
            dataGridView1.Rows[13].Cells[3].Value = "Spark Advance";

            dataGridView1.Rows[14].Cells[1].Value = "27";
            dataGridView1.Rows[14].Cells[2].Value = "T";
            dataGridView1.Rows[14].Cells[3].Value = "Intake Air Temperature";

            dataGridView1.Rows[15].Cells[1].Value = "28";
            dataGridView1.Rows[15].Cells[2].Value = "V5";
            dataGridView1.Rows[15].Cells[3].Value = "IAT Voltage";

            dataGridView1.Rows[16].Cells[1].Value = "29";
            dataGridView1.Rows[16].Cells[2].Value = "Kmh";
            dataGridView1.Rows[16].Cells[3].Value = "Speed Control Target Speed";

            dataGridView1.Rows[17].Cells[1].Value = "32";
            dataGridView1.Rows[17].Cells[2].Value = "BIN";
            dataGridView1.Rows[17].Cells[3].Value = "Speed Control System Flags";

            dataGridView1.Rows[18].Cells[1].Value = "36";
            dataGridView1.Rows[18].Cells[2].Value = "V12";
            dataGridView1.Rows[18].Cells[3].Value = "Target Battery Charge Voltage";

            dataGridView1.Rows[19].Cells[1].Value = "39";
            dataGridView1.Rows[19].Cells[2].Value = "BIN";
            dataGridView1.Rows[19].Cells[3].Value = "Immo Flags";

            dataGridView1.Rows[20].Cells[1].Value = "64";
            dataGridView1.Rows[20].Cells[2].Value = "V5";
            dataGridView1.Rows[20].Cells[3].Value = "MAP Sensor Voltage";

            dataGridView1.Rows[21].Cells[1].Value = "65";
            dataGridView1.Rows[21].Cells[2].Value = "Kmh";
            dataGridView1.Rows[21].Cells[3].Value = "Vehicle Speed";

            dataGridView1.Rows[22].Cells[1].Value = "66";
            dataGridView1.Rows[22].Cells[2].Value = "BIN";
            dataGridView1.Rows[22].Cells[3].Value = "Oxygen Sensor Flags";

            dataGridView1.Rows[23].Cells[1].Value = "2";
            dataGridView1.Rows[23].Cells[2].Value = "MS2";
            dataGridView1.Rows[23].Cells[3].Value = "Injectors Pulsewidth";
            dataGridView1.Rows[23].Cells[5].Value = "22";

            dataGridView1.Refresh();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = (Image)bmp;
            for (int f = 0; f < dataGridView1.RowCount; f++)
            {
                comboBox1.Items.Add(dataGridView1.Rows[f].Cells[3].Value);
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = Properties.Settings.Default.UsePort;
            serialPort1.BaudRate = Convert.ToInt32(Properties.Settings.Default.UseBaud);
            serialPort1.Parity = 0;
            serialPort1.DataBits = 8;
            try
            {
                serialPort1.Open();
                textBox7.Text = "Opened";
            } catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                textBox7.Text = "XXX";
            }
            serialPort1.ReadTimeout = 500;
            if (sendbytetosci(16))
            {
                textBox1.Text = Properties.Settings.Default.UsePort;
                textBox2.Text = Properties.Settings.Default.UseBaud.ToString();
                toolStripStatusLabel1.Text = Properties.Settings.Default.UsePort + ":" + Properties.Settings.Default.UseBaud.ToString();
                connectToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
                settingsToolStripMenuItem.Enabled = false;
                tabControl1.Enabled = true;
                linkLabel1.Visible = true;
                textBox3.Text = "Received!";


                toolStripStatusLabel2.Text = "SBEC connected!";

                System.Threading.Thread.Sleep(200);
                byte[] errorlist;
                errorlist = new byte[serialPort1.BytesToRead];
                serialPort1.Read(errorlist, 0, serialPort1.BytesToRead);
                byte idbyte1 = 0;
                byte idbyte2 = 0;
                byte idbyte3 = 0;
                byte idbyte4 = 0;
                sendbytetosci(0x16);
                sendbytetosci(0x80);
                idbyte1 = readbytefromsci();
                idbyte2 = readbytefromsci();
                idbyte3 = readbytefromsci();
                idbyte4 = readbytefromsci();
                sbecid.Text = idbyte1.ToString("X2") + idbyte2.ToString("X2") + idbyte3.ToString("X2") + idbyte4.ToString("X2");

                byte inbyte = 0;
                while (serialPort1.BytesToRead > 0)
                {
                    inbyte = readbytefromsci();
                }
                sendbytetosci(0x16);
                sendbytetosci(0x81);
                idbyte1 = readbytefromsci();
                idbyte2 = readbytefromsci();
                idbyte3 = readbytefromsci();
                idbyte4 = readbytefromsci();
                modelyear.Text = "9"+Convert.ToString(idbyte3-(16*(idbyte3/15)));

                inbyte = 0;
                while (serialPort1.BytesToRead > 0)
                {
                    inbyte = readbytefromsci();
                }

                sendbytetosci(0x15);
                sendbytetosci(0x80);
                sendbytetosci(0x11);
                idbyte4 = readbytefromsci();
                bodytype.Text = idbyte4.ToString("X2");
                if (idbyte4 == 1) bodytype.Text = "YJ";
                if (idbyte4 == 0) bodytype.Text = "ZJ";
                if (idbyte4 == 2) bodytype.Text = "XJ";

                sendbytetosci(0x15);
                sendbytetosci(0x80);
                sendbytetosci(0x12);
                idbyte4 = readbytefromsci();
                enginetype.Text = idbyte4.ToString("X2");
                if (idbyte4 == 5) enginetype.Text = "4.0L";
                if (idbyte4 == 8) enginetype.Text = "5.2L";
                if (idbyte4 == 1) enginetype.Text = "2.5L";

                sendbytetosci(0x15);
                sendbytetosci(0x80);
                sendbytetosci(0x13);
                idbyte4 = readbytefromsci();
                //aircondition.Text = "(" + idbyte4.ToString("X2") + ") - ";
                if (((idbyte4 >> 5) & 1) == 1) transtype.Text = "AT"; else transtype.Text = "MT";
                if (((idbyte4 >> 7) & 1) == 1) aircondition.Text = "Yes"; else aircondition.Text = "No";

                inbyte = 0;
                while (serialPort1.BytesToRead > 0)
                {
                    inbyte = readbytefromsci();
                }

                sendbytetosci(0x15);                                                      //Чтение иммобилайзера
                sendbytetosci(0xb6);
                sendbytetosci(0x12);
                idbyte1 = readbytefromsci();
                if (idbyte1 == 0xff)
                {
                    textBox13.Text = "Absent";
                    textBox20.Text = "Absent";
                }
                if (idbyte1 == 0x4e)
                {
                    textBox13.Text = "Swiched off";
                    textBox20.Text = "Swiched off";
                }
                if (idbyte1 == 0x4c)
                {
                    textBox13.Text = "Enabled";
                    textBox20.Text = "Enabled";
                }

                sendbytetosci(0x15);                                                              // spark advance read
                sendbytetosci(0xb6);
                sendbytetosci(0x14);
                idbyte1 = readbytefromsci();
                if (idbyte1 == 255) idbyte1 = 0;
                sendbytetosci(0x15);
                sendbytetosci(0xb6);
                sendbytetosci(0x15);
                idbyte2 = readbytefromsci();
                textBox14.Text = "0";
                textBox15.Text = "0";
                if (idbyte1 < 128)
                {
                    float idb1 = idbyte1;
                    float adv = idb1 / 2;
                    if (idbyte1 > 0)
                    {
                        textBox14.Text = "+ " + adv.ToString();
                        textBox15.Text = "+ " + adv.ToString();

                    }
                }
                else
                {
                    float idb1 = idbyte1;
                    float adv = (256 - idb1) / 2;
                    textBox14.Text = "- " + adv.ToString();
                    textBox15.Text = "- " + adv.ToString();
                }
                if (idbyte1 + idbyte2 != 255)
                {
                    textBox14.Text = "EEPROM Data Error!";
                    textBox15.Text = "EEPROM Data Error!";
                }

                sendbytetosci(0x15);                                                        // alternator voltage read
                sendbytetosci(0xb7);
                sendbytetosci(0xe0);
                idbyte1 = readbytefromsci();
                sendbytetosci(0x15);
                sendbytetosci(0xb7);
                sendbytetosci(0xe1);
                idbyte2 = readbytefromsci();
                textBox18.Text = idbyte1.ToString();
                textBox19.Text = idbyte1.ToString();
                if ((idbyte1 + idbyte2) % 255 > 1)
                {
                    textBox18.Text = "EEPROM Data Error!";
                    textBox19.Text = "EEPROM Data Error!";
                }

                while (serialPort1.BytesToRead > 0)
                {
                    inbyte = readbytefromsci();
                }

                double mileage = 0;                                                   //mileage read
                for (int f = 0; f <= 7; f++)
                {
                    sendbytetosci(0x15);
                    sendbytetosci(0xb6);
                    idbyte1 = Convert.ToByte(f * 2);
                    sendbytetosci(idbyte1);
                    idbyte1 = readbytefromsci();
                    LogBox.AppendText(idbyte1.ToString());
                    sendbytetosci(0x15);
                    sendbytetosci(0xb6);
                    idbyte2 = Convert.ToByte(f * 2 + 1);
                    LogBox.AppendText(idbyte2.ToString());
                    sendbytetosci(idbyte2);
                    idbyte2 = readbytefromsci();
                    mileage = mileage + idbyte1 * 256;
                    mileage = mileage + idbyte2;
                }

                mileage = mileage * 1.61;
                textBox8.Text = mileage.ToString()+" Km";
                textBox17.Text = "";
                byte[] readedbyte={0};
                for (byte f = 2; f <= 18; f++)
                {
                    sendbytetosci(0x15);
                    sendbytetosci(0xb6);
                    sendbytetosci(Convert.ToByte(0xb0+f));
                    readedbyte[0]=readbytefromsci();
                    if (readedbyte[0]!=0xff)
                        textBox17.AppendText(Encoding.ASCII.GetString(readedbyte));
                }
                textBox21.Text = textBox17.Text;
                readerrors();

            }
            else
            {
                serialPort1.Close();
                textBox7.Text = "Closed";
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            if (true)
                textBox7.Text = "Closed";
            connectToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            settingsToolStripMenuItem.Enabled = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Enabled = false;
            linkLabel1.Visible = false;
            textBox3.Text = "";
            bodytype.Text = "";
            sbecid.Text = "";
            aircondition.Text = "";
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";

        }
        public Boolean sendbytetosci(byte b)
        {
            if (serialPort1.IsOpen)
            {
                byte[] b1 = { b };
                serialPort1.Write(b1, 0, 1);
                LogBox.AppendText("Send: " + b1[0].ToString("X2"));
                int comecho = 0;
                try
                {
                    comecho = serialPort1.ReadByte();
                    while (comecho != b)
                    {
                        comecho = serialPort1.ReadByte();
                    }
                }
                catch (TimeoutException)
                {
                    toolStripStatusLabel2.Text = "Connection timeout!";
                }

                LogBox.AppendText(" Echo: " + comecho.ToString("X2") + "\n");
                if (comecho == b)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Byte readbytefromsci()
        {
            if (serialPort1.IsOpen)
            {
                int comecho = 0;
                try
                {
                    comecho = serialPort1.ReadByte();
                }
                catch (TimeoutException)
                {
                    toolStripStatusLabel2.Text = "Connection timeout!";
                }

                LogBox.AppendText("Receive: " + comecho.ToString("X2") + "\n");
                return Convert.ToByte(comecho);
            }
            else
            {
                return 0;
            }
        }

        private void saveFirmwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(sbecid.Text + ".bin", FileMode.Create, FileAccess.Write);
                //fs.Seek(55, SeekOrigin.Begin);
                byte[] by = { 0 };
                if (true)
                {
                    toolStripStatusLabel3.Text = "Wait... Saving data to " + sbecid.Text + ".bin";
                }
                for (int addrh = 0x80; addrh <= 0xff; addrh++)
                {
                    for (int addrl = 0; addrl <= 0xff; addrl++)
                    {
                        toolStripStatusLabel2.Text = "Addr: 0x" + addrh.ToString("X2") + addrl.ToString("X2");
                        statusStrip1.Refresh();
                        sendbytetosci(0x15);
                        sendbytetosci(Convert.ToByte(addrh));
                        sendbytetosci(Convert.ToByte(addrl));
                        by[0] = readbytefromsci();
                        if (addrh == 0xb6) by[0] = 0xff;
                        if (addrh == 0xb7) by[0] = 0xff;
                        fs.Write(by, 0, 1); // запись байт
                    }
                    toolStripProgressBar1.Value = addrh;
                }

                fs.Dispose(); // освобождаем ресурсы
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message); return;
            }
            toolStripStatusLabel3.Text = "";
            toolStripStatusLabel2.Text = "";
            toolStripProgressBar1.Value = 128;
        }

        private void saveEEPROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(sbecid.Text + "-EEPROM.bin", FileMode.Create, FileAccess.Write);
                byte[] by = { 0 };
                if (true)
                {
                    toolStripStatusLabel3.Text = "Wait... Saving EEPROM to " + sbecid.Text + "-EEPROM.bin";
                }
                for (int addrh = 0xb6; addrh <= 0xb7; addrh++)
                {
                    for (int addrl = 0; addrl <= 0xff; addrl++)
                    {
                        toolStripStatusLabel2.Text = "Addr: 0x" + addrh.ToString("X2") + addrl.ToString("X2");
                        statusStrip1.Refresh();
                        sendbytetosci(0x15);
                        sendbytetosci(Convert.ToByte(addrh));
                        sendbytetosci(Convert.ToByte(addrl));
                        by[0] = readbytefromsci();//Convert.ToByte(serialPort1.ReadByte());
                        fs.Write(by, 0, 1); // запись байт
                        toolStripProgressBar1.Value = 128+addrl/2;
                    }

                }

                fs.Dispose(); // освобождаем ресурсы
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message); return;
            }
            toolStripStatusLabel3.Text = "";
            toolStripStatusLabel2.Text = "";
            toolStripProgressBar1.Value = 128;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            readerrors();
        }

        private void readerrors()
        {
            textBox9.Clear();
            textBox16.Clear();
            sendbytetosci(16);
            System.Threading.Thread.Sleep(200);
            byte er = 0;
            string err = "";
            int errorcount = serialPort1.BytesToRead;
            errorcount--;
            for (int f = 0; f < errorcount; f++)
            {
                er = readbytefromsci();
                textBox16.AppendText(er.ToString("X2") + " ");
                {
                    err = er.ToString("X2") + " Unknown code. Please send me email if you know";
                    if (er == 0x28) err = "No crank reference signal detected during engine cranking";
                    if (er == 0x27) err = "P1297 No diff recogn betw the eng MAP read and the (atmospheric) read from start-up";
                    if (er == 0x24) err = "P0107 MAP sensor input below minimum acceptable voltage";
                    if (er == 0x25) err = "P0108 MAP sensor input above maximum acceptable voltage";
                    if (er == 0x87) err = "P1296 5 volt output to MAP sensor open (No 5 volts to MAP)";
                    if (er == 0x23) err = "P0500 No vehicle speed sensor signal detected during road load conditions";
                    if (er == 0xa6) err = "P0720 Low output of speed sensor circuit above 15 MPH";
                    if (er == 0x80) err = "P0125 Engine does not reach 50C degrees within 5 minutes with a vehicle speed signal";
                    if (er == 0x3e) err = "P0132 O2 sensor shorted to voltage (voltage higher than normal operating range)";
                    if (er == 0x66) err = "P0132 O2 sens resp slower than min requir switch freq or does not go above .65 volts";
                    if (er == 0x67) err = "P0135 O2 sensor heating element malfunction (sensor heater failure)";
                    if (er == 0x9b) err = "P0131 O2 sensor shorted to ground (tested after key off and at start to run)";
                    if (er == 0x1e) err = "P0117 Engine coolant temperature sensor input below minimum acceptable voltage";
                    if (er == 0x1f) err = "P0118 Engine coolant temperature sensor input above the maximum acceptable voltage";
                    if (er == 0x39) err = "P0112 Intake air temperature sensor input below minimum acceptable voltage";
                    if (er == 0x3a) err = "P0113 Intake air temperature sensor input above maximum acceptable voltage";
                    if (er == 0x1a) err = "P0122 Throttle Position Sensor (TPS) input below minimum acceptable voltage";
                    if (er == 0x1b) err = "P0123 Throttle Position Sensor (TPS) input above maximum acceptable voltage";
                    if (er == 0x84) err = "P0121 Throttle Position Sensor (TPS) does not agree with Mass Air Flow Sensor (MAP)";
                    if (er == 0x19) err = "P0505 Idle Air Control Motor has a shorted or open condition in one or more circuits";
                    if (er == 0x8a) err = "P1294 Actual idle speed does not equal target idle speed";
                    if (er == 0x15) err = "P0201 Fuel Injector #1 output driver does not respond to control signal";
                    if (er == 0x14) err = "P0202 Fuel Injector #2 output driver does not respond to control signal";
                    if (er == 0x13) err = "P0203 Fuel Injector #3 output driver does not respond to control signal";
                    if (er == 0x3d) err = "P0204 Fuel Injector #4 output driver does not respond to control signal";
                    if (er == 0x45) err = "P0205 Fuel Injector #5 output driver does not respond to control signal";
                    if (er == 0x46) err = "P0206 Fuel Injector #6 output driver does not respond to control signal";
                    if (er == 0x4f) err = "P0207 Fuel Injector #7 output driver does not respond to control signal";
                    if (er == 0x50) err = "P0208 Fuel Injector #8 output driver does not respond to control signal";
                    if (er == 0x12) err = "P0443 An open or shorted condition detected in the duty cycle purge solenoid circuit";
                    if (er == 0x71) err = "P0441 Insufficient or excessive vapor flow detected during evaporative emission system operation";
                    if (er == 0x10) err = "A/C clutch has an open or shorted condition";
                    if (er == 0x0f) err = "open or short condition detect in the Speed Contr vaccum or vent sol circuits";
                    if (er == 0x0c) err = "P0743 Short or open condition in TC part-throttle unlock solenoid";
                    if (er == 0x0b) err = "Generator field not switching properly (alternator)";
                    if (er == 0x0a) err = "Fuel pump auto shutdown relay control circuit fault detected";
                    if (er == 0x2c) err = "No ASD relay output voltage at PCM";
                    if (er == 0x99) err = "P1493 Battery temperature sensor voltage too low";
                    if (er == 0x9a) err = "P1492 Battery temperature sensor voltage too high";
                    if (er == 0x32) err = "P0753 Transmission 3/4 overdrive solenoid circuit";
                    if (er == 0x06) err = "Alternator charging system voltage too high";
                    if (er == 0x05) err = "Alternator charging system voltage too low; no change in voltage during active test of generator output";
                    if (er == 0x77) err = "P0171 A lean air/fuel mixture has been indicated by an abnormally rich corrrection factor";
                    if (er == 0x76) err = "P0171 A rich air/fuel mixture has been indicated by an abnormally lean corrrection factor";
                    if (er == 0x01) err = "No camshaft signal";
                    if (er == 0x31) err = "P1698 PCM Failure, EEPROM write denied";
                    if (er == 0x73) err = "P0551 (2.5L Only) Power steering switch failure (high pressure at high speed)";
                    if (er == 0xfe) err = "End of DTC list";
                    if (er == 0x0e) err = "P1491 Radiator fan control relay circuit fault";
                }
                textBox9.AppendText(err +Environment.NewLine);
                
            }
            er = readbytefromsci();
            textBox16.AppendText(er.ToString("X2") + " ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte result = 0;
            for (int f = 0; f < 25; f++)
            {
                sendbytetosci(0x17);
                result = readbytefromsci();
            }
            System.Threading.Thread.Sleep(200);
            readerrors();
        }


        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)               //Tests
        {
            //label14.Text = listBox1.SelectedIndex.ToString();           
            sendbytetosci(0x13);
            sendbytetosci(Convert.ToByte(listBox1.SelectedIndex));
            byte result = readbytefromsci();
            if (result == Convert.ToByte(listBox1.SelectedIndex)) label14.Visible = true;
            else label15.Visible = true;
            listBox1.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)                              //Stop tests
        {
            //byte inbyte = 0;
            while (serialPort1.BytesToRead > 0)
            {
                //inbyte = readbytefromsci();
                serialPort1.DiscardInBuffer();
            }
            sendbytetosci(0x0);
            sendbytetosci(0x13);
            sendbytetosci(0x0);
            sendbytetosci(0x13);
            sendbytetosci(0x0);
            //inbyte = 0;
            while (serialPort1.BytesToRead > 0)
            {
                //inbyte = readbytefromsci();
                serialPort1.DiscardInBuffer();
            }
            //button3.Enabled = false;
            listBox1.Enabled = true;
            label14.Visible = false;
            label15.Visible = false;
            button19.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sendbytetosci(0x15);
            sendbytetosci(0xb6);
            sendbytetosci(0x14);
            byte advbyte1 = readbytefromsci();
            sendbytetosci(0x15);
            sendbytetosci(0xb6);
            sendbytetosci(0x15);
            byte advbyte2 = readbytefromsci();
            if ((advbyte1 + advbyte2) % 255 < 2)
            {
                advbyte1--;
                advbyte2++;
                byte result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x14);
                    sendbytetosci(advbyte1);
                    result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x15);
                    sendbytetosci(advbyte2);
                    result = readbytefromsci();
                }
            }
            else
            {
                byte result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x14);
                    sendbytetosci(0);
                    result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x15);
                    sendbytetosci(0xff);
                    result = readbytefromsci();
                }
            }
            System.Threading.Thread.Sleep(200);
            sendbytetosci(0x15);
            sendbytetosci(0xb6);
            sendbytetosci(0x14);
            byte idbyte1 = readbytefromsci();
            sendbytetosci(0x15);
            sendbytetosci(0xb6);
            sendbytetosci(0x15);
            byte idbyte2 = readbytefromsci();
            textBox14.Text = "0";
            textBox15.Text = "0";
            if (idbyte1 < 128)
            {
                float idb1 = idbyte1;
                float adv = idb1 / 2;
                if (idbyte1 > 0)
                {
                    textBox14.Text = "+ " + adv.ToString();
                    textBox15.Text = "+ " + adv.ToString();

                }
            }
            else
            {
                float idb1 = idbyte1;
                float adv = (256 - idb1) / 2;
                textBox14.Text = "- " + adv.ToString();
                textBox15.Text = "- " + adv.ToString();
            }
            if ((idbyte1 + idbyte2) % 255 > 1)
            {
                textBox14.Text = "Ошибка в EEPROM!";
                textBox15.Text = "Ошибка в EEPROM!";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sendbytetosci(0x15);
            sendbytetosci(0xb6);
            sendbytetosci(0x14);
            byte advbyte1 = readbytefromsci();
            if (advbyte1 == 255) advbyte1 = 0;
            sendbytetosci(0x15);
            sendbytetosci(0xb6);
            sendbytetosci(0x15);
            byte advbyte2 = readbytefromsci();
            if (advbyte1 + advbyte2 == 255)
            {
                advbyte1++;
                advbyte2--;
                byte result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x14);
                    sendbytetosci(advbyte1);
                    result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x15);
                    sendbytetosci(advbyte2);
                    result = readbytefromsci();
                }
            }
            else
            {
                byte result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x14);
                    sendbytetosci(0);
                    result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(0x15);
                    sendbytetosci(0xff);
                    result = readbytefromsci();
                }
            }
            System.Threading.Thread.Sleep(200);
                sendbytetosci(0x15);
                sendbytetosci(0xb6);
                sendbytetosci(0x14);
                byte idbyte1 = readbytefromsci();
                sendbytetosci(0x15);
                sendbytetosci(0xb6);
                sendbytetosci(0x15);
                byte idbyte2 = readbytefromsci();
                textBox14.Text = "0";
                textBox15.Text = "0";
                if (idbyte1 < 128)
                {
                    float idb1 = idbyte1;
                    float adv = idb1 / 2;
                    if (idbyte1 > 0)
                    {
                        textBox14.Text = "+ " + adv.ToString();
                        textBox15.Text = "+ " + adv.ToString();

                    }
                }
                else
                {
                    float idb1 = idbyte1;
                    float adv = (256 - idb1) / 2;
                    textBox14.Text = "- " + adv.ToString();
                    textBox15.Text = "- " + adv.ToString();
                }
                if ((idbyte1 + idbyte2) % 255 > 1)
                {
                    textBox14.Text = "Ошибка в EEPROM!";
                    textBox15.Text = "Ошибка в EEPROM!";
                }
        }

        private void label12_DoubleClick(object sender, EventArgs e)
        {
            LogBox.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label18.Text = "";
            sendbytetosci(0x23);
            sendbytetosci(0x04);
            byte result = readbytefromsci();
            if (result == 0xf0) label18.Text = "Выполнено";
            else label18.Text = "Ошибка" + result.ToString("X2");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label18.Text = "";
            sendbytetosci(0x23);
            sendbytetosci(0x02);
            byte result = readbytefromsci();
            if (result == 0xf0) label18.Text = "Выполнено";
            else label18.Text = "Ошибка" + result.ToString("X2");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label18.Text = "";
            //sendbytetosci(0x23);
            //sendbytetosci(0x01);
            //byte result = readbytefromsci();
            //if (result == 0xf0) label18.Text = "Выполнено";
            //else label18.Text = "Ошибка" + result.ToString("X2");
            for (byte f = 0; f < 255; f++)
            {
                byte result = 0;
                while (result != 0xe2)
                {
                    sendbytetosci(0x1c);
                    sendbytetosci(f);
                    sendbytetosci(0);
                    result = readbytefromsci();
                }                
            }
            label18.Text = "Выполнено";
        }

        private void label18_DoubleClick(object sender, EventArgs e)
        {
            button8.Enabled = true;
        }


        private void button9_Click(object sender, EventArgs e)
        {
            label18.Text = "";
            byte result = 0;
            while (result != 0xe2)
            {
                sendbytetosci(0x1c);
                sendbytetosci(0x10);
                sendbytetosci(0xff);
                result = readbytefromsci();
            }
            result = 0;
            while (result != 0xe2)
            {
                sendbytetosci(0x1c);
                sendbytetosci(0x11);
                sendbytetosci(0xff);
                result = readbytefromsci();
            }
            label18.Text = "Выполнено";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe0);
            byte advbyte1 = readbytefromsci();
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe1);
            byte advbyte2 = readbytefromsci();
            if ((advbyte1 + advbyte2) % 255 < 2)
            {
                advbyte1--;
                advbyte2++;
                byte result = 0;
                while (result != 0xe2)
                {
                    //sendbytetosci(0x1c);
                    //sendbytetosci(0x14);                             //как записать в еепром выше 256?
                    // sendbytetosci(advbyte1);
                    // result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    // sendbytetosci(0x1c);
                    // sendbytetosci(0x15);
                    // sendbytetosci(advbyte2);
                    // result = readbytefromsci();
                }
            }
            else
            {
                byte result = 0;
                while (result != 0xe2)
                {
                    //     sendbytetosci(0x1c);
                    //     sendbytetosci(0x14);
                    //     sendbytetosci(0);
                    //     result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    //    sendbytetosci(0x1c);
                    //    sendbytetosci(0x15);
                    //    sendbytetosci(0xff);
                    //    result = readbytefromsci();
                }
            }
            System.Threading.Thread.Sleep(200);
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe0);
            byte idbyte1 = readbytefromsci();
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe1);
            byte idbyte2 = readbytefromsci();
            textBox18.Text = idbyte1.ToString();
            textBox19.Text = idbyte1.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe0);
            byte advbyte1 = readbytefromsci();
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe1);
            byte advbyte2 = readbytefromsci();
            if ((advbyte1 + advbyte2) % 255 < 2)
            {
                advbyte1++;
                advbyte2--;
                byte result = 0;
                while (result != 0xe2)
                {
                    //sendbytetosci(0x1c);
                    //sendbytetosci(0x14);                                            //как записать в еепром выше 256?
                    // sendbytetosci(advbyte1);
                    // result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    // sendbytetosci(0x1c);
                    // sendbytetosci(0x15);
                    // sendbytetosci(advbyte2);
                    // result = readbytefromsci();
                }
            }
            else
            {
                byte result = 0;
                while (result != 0xe2)
                {
                    //     sendbytetosci(0x1c);
                    //     sendbytetosci(0x14);
                    //     sendbytetosci(0);
                    //     result = readbytefromsci();
                }
                result = 0;
                while (result != 0xe2)
                {
                    //    sendbytetosci(0x1c);
                    //    sendbytetosci(0x15);
                    //    sendbytetosci(0xff);
                    //    result = readbytefromsci();
                }
            }
            System.Threading.Thread.Sleep(200);
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe0);
            byte idbyte1 = readbytefromsci();
            sendbytetosci(0x15);
            sendbytetosci(0xb7);
            sendbytetosci(0xe1);
            byte idbyte2 = readbytefromsci();
            textBox18.Text = idbyte1.ToString();
            textBox19.Text = idbyte1.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            byte result = 0;
            while (result != 0xe2)
            {
                label18.Text = "";
                sendbytetosci(0x1c);
                sendbytetosci(0x12);
                sendbytetosci(0x4e);
                result = readbytefromsci();
            }
            sendbytetosci(0x15);                                                      //Чтение иммобилайзера
            sendbytetosci(0xb6);
            sendbytetosci(0x12);
            byte idbyte1 = readbytefromsci();
            if (idbyte1 == 0xff)
            {
                textBox13.Text = "Отсутствует";
                textBox20.Text = "Отсутствует";
            }
            if (idbyte1 == 0x4e)
            {
                textBox13.Text = "есть, отключен";
                textBox20.Text = "есть, отключен";
            }
            if (idbyte1 == 0x4c)
            {
                textBox13.Text = "Задействован";
                textBox20.Text = "Задействован";
            }
            label18.Text = "Выполнено";

        }

        private void button13_Click(object sender, EventArgs e)
        {
            byte result = 0;
            while (result != 0xe2)
            {
                label18.Text = "";
                sendbytetosci(0x1c);
                sendbytetosci(0x12);
                sendbytetosci(0x4c);
                result = readbytefromsci();
            }
            sendbytetosci(0x15);                                                      //Чтение иммобилайзера
            sendbytetosci(0xb6);
            sendbytetosci(0x12);
            byte idbyte1 = readbytefromsci();
            if (idbyte1 == 0xff)
            {
                textBox13.Text = "Отсутствует";
                textBox20.Text = "Отсутствует";
            }
            if (idbyte1 == 0x4e)
            {
                textBox13.Text = "есть, отключен";
                textBox20.Text = "есть, отключен";
            }
            if (idbyte1 == 0x4c)
            {
                textBox13.Text = "Задействован";
                textBox20.Text = "Задействован";
            }
            label18.Text = "Выполнено";


        }

        private void button15_Click(object sender, EventArgs e)
        {
            byte result = 0;
            while (result != 0xe2)
            {
                label18.Text = "";
                sendbytetosci(0x1c);
                sendbytetosci(0x12);
                sendbytetosci(0xff);
                result = readbytefromsci();
            }
            sendbytetosci(0x15);                                                      //Чтение иммобилайзера
            sendbytetosci(0xb6);
            sendbytetosci(0x12);
            byte idbyte1 = readbytefromsci();
            if (idbyte1 == 0xff)
            {
                textBox13.Text = "Отсутствует";
                textBox20.Text = "Отсутствует";
            }
            if (idbyte1 == 0x4e)
            {
                textBox13.Text = "есть, отключен";
                textBox20.Text = "есть, отключен";
            }
            if (idbyte1 == 0x4c)
            {
                textBox13.Text = "Задействован";
                textBox20.Text = "Задействован";
            }
            label18.Text = "Выполнено";
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpform = new Form3();
            helpform.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int inbyte = 0;
            timer1.Enabled = false;
            if (tabControl1.SelectedIndex == 2)
            {
                if (dataGridView1.Rows[count].Cells[0].FormattedValue.ToString() == "True")
                {
                    serialPort1.DiscardInBuffer();
                    if (dataGridView1.Rows[count].Cells[5].Value == "22")
                    {
                        sendbytetosci(0x22);
                        serialPort1.DiscardInBuffer();
                        sendbytetosci(Convert.ToByte(dataGridView1.Rows[count].Cells[1].Value));
                        inbyte = readbytefromsci() * 255;
                        inbyte = inbyte + readbytefromsci();
                    } else
                    {
                        sendbytetosci(0x14);
                        serialPort1.DiscardInBuffer();
                        sendbytetosci(Convert.ToByte(dataGridView1.Rows[count].Cells[1].Value));
                        inbyte = readbytefromsci();
                    }
                    dataGridView1.Rows[count].Cells[4].Value = inbyte.ToString();
                    if (dataGridView1.Rows[count].Cells[2].Value == "BIN") dataGridView1.Rows[count].Cells[4].Value = Convert.ToString(inbyte, 2).PadLeft(8, '0');
                    if (dataGridView1.Rows[count].Cells[2].Value == "V5")
                    {
                        double val = 0;
                        val = (5.0 * inbyte) / 255.0;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F2") + " Вольт";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "V51")
                    {
                        double val = 0;
                        val = (5.0 * inbyte) / 255.0;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F2") + " Вольт";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "V12")
                    {
                        double val = 0;
                        val = inbyte / 16.0;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F2") + " Вольт";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "Kmh")
                    {
                        double val = 0;
                        //val = ((1024.0 * inbyte) / 65535.0) * 1.61;
                        val = inbyte * 1.61;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F1") + " Км/ч";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "T")
                    {
                        double val = 0;
                        val = ((460.0 * inbyte) / 255.0) - 200;
                        val = (val - 32) * 0.5556;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F2") + " Град. С";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "%")
                    {
                        double val = 0;
                        val = (100.0 * inbyte) / 255.0;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F0") + " %";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "PSI")
                    {
                        double val = 0;
                        val = (29.4 * inbyte) / 255.0;
                        if (val < 14.7)
                        {
                            val = 14.7 - val;
                            dataGridView1.Rows[count].Cells[4].Value = "-" + val.ToString("F2") + " PSI";
                        }
                        else
                        {
                            val = val - 14.7;
                            dataGridView1.Rows[count].Cells[4].Value = val.ToString("F2") + " PSI";
                        }
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "RPM2")
                    {
                        double val = 0;
                        val = (8192 * inbyte) / 65535.0;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F0") + " Об/Мин";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "MS2")
                    {
                        double val = 0;
                        //val = (49152 * inbyte) / 65535.0;
                        val = inbyte / 255.0;
                        dataGridView1.Rows[count].Cells[4].Value = val.ToString("F2") + " Мс";
                    }
                    if (dataGridView1.Rows[count].Cells[2].Value == "ADV")
                    {
                        double val = 0;
                        val = inbyte / 2;
                        dataGridView1.Rows[count].Cells[4].Value = "-" + val.ToString("F2") + " Град.";
                    }
                    toolStripStatusLabel2.Text = count.ToString();
                    while (serialPort1.BytesToRead > 0)
                    {
                        inbyte = readbytefromsci();
                    }
                    sendbytetosci(0x14);
                    sendbytetosci(3);
                    while (serialPort1.BytesToRead > 0)
                    {
                        inbyte = readbytefromsci();
                    }
                }
                if (count < dataGridView1.RowCount) count++;
                bool good = false;
                while (good != true)
                {
                    if (count < dataGridView1.RowCount)
                    {
                        if (dataGridView1.Rows[count].Cells[0].FormattedValue.ToString() == "True") good = true;
                        else count++;
                    }
                    if (count == dataGridView1.RowCount) good = true;
                }
                if (count == dataGridView1.RowCount)
                {
                    count = 0;
                    dataGridView1.Refresh();
                }
            }
            if (tabControl1.SelectedIndex == 3)
            {
                if (comboBox1.Text != "")
                {
                    if (serialPort1.BytesToRead > 0)
                    {
                        double val = readbytefromsci();
                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[5].Value == "22")
                        {
                            val = val * 255;
                            val = val + readbytefromsci();
                            val = val / 255.0;
                        }
                        if (count2 == 1) oldval = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 255.0 * val + 20)));
                        double tempval = val;
                        {
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "BIN") 
                                label25.Text = Convert.ToString(Convert.ToByte(val), 2).PadLeft(8, '0');
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V5")
                            {
                                //val = (5.0 * val) / 255.0;
                                val = val / 51;
                                label25.Text = val.ToString("F2") + " Вольт";
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V51")
                            {
                                //val = (5.0 * val) / 255.0;
                                val = val / 51;
                                label25.Text = val.ToString("F2") + " Вольт";
                                tempval = tempval * 5;
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V12")
                            {
                                val = val / 16.0;
                                label25.Text = val.ToString("F2") + " Вольт";
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "Kmh")
                            {
                                val = val * 1.61;
                                label25.Text = val.ToString("F1") + " Км/ч";
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "T")
                            {
                                val = ((460.0 * val) / 255.0) - 200;
                                val = (val - 32) * 0.5556;
                                label25.Text = val.ToString("F2") + " Град. С";
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "%")
                            {
                                val = (100.0 * val) / 255.0;
                                label25.Text = val.ToString("F0") + " %";
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "PSI")
                            {
                                val = (29.4 * val) / 255.0;
                                if (val < 14.7)
                                {
                                    val = 14.7 - val;
                                    label25.Text = "-" + val.ToString("F2") + " PSI";
                                }
                                else
                                {
                                    val = val - 14.7;
                                    label25.Text = val.ToString("F2") + " PSI";
                                }
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "RPM2")
                            {
                                val = (8192 * val) / 255.0;
                                label25.Text = val.ToString("F0") + " Об/Мин";
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "MS2")
                            {
                                //val = val / 255.0;
                                label25.Text = val.ToString("F2") + " Мс";
                            }
                            if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "ADV")
                            {
                                val = val / 2;
                                label25.Text = "-" + val.ToString("F2") + " Град.";
                            }


                        }


                        val = tempval;
                        if (val == 0) val = 1;
                        if (oldval == 0) oldval = 1;
                        //if (oldval >= bmp.Height) oldval = bmp.Height - 1;
                        int midval = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 255.0 * val)));
                        if (midval == 0) midval = 1;
                        if (midval >= bmp.Height) midval = bmp.Height-1;
                        bmp.SetPixel(count2 - 1, oldval, Color.Black);
                        if (oldval+1<bmp.Height) bmp.SetPixel(count2 - 1, oldval + 1, Color.Black);
                        while (midval != oldval)
                        {
                            if (midval > oldval) midval--;
                            if (midval < oldval) midval++;
                            //bmp.SetPixel(count2 - 1, midval, Color.Black);
                            bmp.SetPixel(count2, midval, Color.Black);
                        }
                        pictureBox1.Refresh();
                        count2++;
                        oldval = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 255.0 * val + 0)));

                        if (count2 == bmp.Width - 1)
                        {
                            count2 = 80;
                            if (checkBox2.Checked) scrshot();
                            if (checkBox1.Checked)
                            {
                                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                                pictureBox1.Image = (Image)bmp;
                                for (int f = 40; f < bmp.Width - 1; f++)
                                {
                                    bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) + 1.0))), Color.Red);
                                    bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - 1.0)), Color.Blue);
                                    bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 + 1))), Color.Gray);
                                    bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 2.5 + 1))), Color.Gray);
                                    bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 3 + 1))), Color.Gray);
                                    bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 4 + 1))), Color.Gray);
                                }
                                level0.Left = 2;
                                level0.Top = Convert.ToInt16(Math.Floor(bmp.Height - 8.0));
                                level1.Left = 2;
                                level1.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 + 1)));
                                level2.Left = 2;
                                level2.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 2.5 + 1)));
                                level3.Left = 2;
                                level3.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 3 + 1)));
                                level4.Left = 2;
                                level4.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 4 + 1)));
                                level5.Left = 2;
                                level5.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) + 1.0)));

                                for (int f = 0; f < 6; f++)
                                {
                                    val = f * 255 / 5;
                                    string txtval = "";
                                    {
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "") txtval = val.ToString();
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "BIN") txtval = Convert.ToString(Convert.ToByte(val), 2).PadLeft(8, '0');
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V5")
                                        {
                                            val = (5.0 * val) / 255.0;
                                            txtval = val.ToString("F2") + " Вольт";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V51")
                                        {
                                            val = val / 255.0;
                                            txtval = val.ToString("F2") + " Вольт";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V12")
                                        {
                                            val = val / 16.0;
                                            txtval = val.ToString("F2") + " Вольт";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "Kmh")
                                        {
                                            val = val * 1.61;
                                            txtval = val.ToString("F1") + " Км/ч";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "T")
                                        {
                                            val = ((460.0 * val) / 255.0) - 200;
                                            val = (val - 32) * 0.5556;
                                            txtval = val.ToString("F2") + " Град. С";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "%")
                                        {
                                            val = (100.0 * val) / 255.0;
                                            txtval = val.ToString("F0") + " %";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "PSI")
                                        {
                                            val = (29.4 * val) / 255.0;
                                            if (val < 14.7)
                                            {
                                                val = 14.7 - val;
                                                txtval = "-" + val.ToString("F2") + " PSI";
                                            }
                                            else
                                            {
                                                val = val - 14.7;
                                                txtval = val.ToString("F2") + " PSI";
                                            }
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "RPM2")
                                        {
                                            val = (8192 * val) / 255.0;
                                            txtval = val.ToString("F0") + " Об/Мин";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "MS2")
                                        {
                                            //val = val / 255.0;
                                            txtval = val.ToString("F0") + " Мс";
                                        }
                                        if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "ADV")
                                        {
                                            val = val / 2;
                                            txtval = "-" + val.ToString("F0") + " Град.";
                                        }
                                    }
                                    if (f == 0) level0.Text = txtval;
                                    if (f == 1) level1.Text = txtval;
                                    if (f == 2) level2.Text = txtval;
                                    if (f == 3) level3.Text = txtval;
                                    if (f == 4) level4.Text = txtval;
                                    if (f == 5) level5.Text = txtval;
                                }
                            }
                        }
                        while (serialPort1.BytesToRead > 1)
                        {
                            inbyte = readbytefromsci();
                           // inbyte = readbytefromsci();

                        }
                    }
                }
            }
            timer1.Enabled = true;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.DiscardInBuffer();
            if (comboBox1.Text != "")
            {
                if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[5].Value == "22") sendbytetosci(0x22);
                else sendbytetosci(0x14);
                serialPort1.DiscardInBuffer();
                sendbytetosci(Convert.ToByte(dataGridView1.Rows[comboBox1.SelectedIndex].Cells[1].Value));
                comboBox1.Enabled = false;
                timer1.Interval = 10;
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = (Image)bmp;
                count2 = bmp.Width - 2;//1;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            timer1.Interval = 30;
            comboBox1.Enabled = true;
            serialPort1.DiscardInBuffer();
            sendbytetosci(0x14);
            sendbytetosci(3);
            
            while (serialPort1.BytesToRead > 0)
            {
                readbytefromsci();
            }
            sendbytetosci(0x14);
            sendbytetosci(3);
            while (serialPort1.BytesToRead > 0)
            {
                readbytefromsci();
            }
            comboBox1.Text = "";
            count2 = 1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Enabled == false)
            {
                timer1.Interval = 30;
                comboBox1.Enabled = true;
                serialPort1.DiscardInBuffer();
                sendbytetosci(0x14);
                sendbytetosci(3);
                while (serialPort1.BytesToRead > 0)
                {
                    readbytefromsci();
                }
                sendbytetosci(0x14);
                sendbytetosci(3);
                while (serialPort1.BytesToRead > 0)
                {
                    readbytefromsci();
                }
                comboBox1.Text = "";
                count2 = 1;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = (Image)bmp;
            if (comboBox1.Text!="")
            {
            for (int f = 1; f < bmp.Width - 1; f++)
            {
                bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) + 1.0))), Color.Red);
                bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - 1.0)), Color.Blue);
                bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 + 1))), Color.Gray);
                bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 2.5 + 1))), Color.Gray);
                bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 3 + 1))), Color.Gray);
                bmp.SetPixel(f, Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 4 + 1))), Color.Gray);
            }
            level0.Left = 2;
            level0.Top = Convert.ToInt16(Math.Floor(bmp.Height - 8.0));
            level1.Left = 2;
            level1.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 + 1)));
            level2.Left = 2;
            level2.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 2.5 + 1)));
            level3.Left = 2;
            level3.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 3 + 1)));
            level4.Left = 2;
            level4.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) / 5.0 * 4 + 1)));
            level5.Left = 2;
            level5.Top = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) + 1.0)));

            for (int f = 0; f < 6; f++)
            {
                double val = f * 255 / 5;
                string txtval = "";
                {
                    //if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V5") txtval = val.ToString();
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V5")
                    {
                        val = (5.0 * val) / 255.0;
                        txtval = val.ToString("F2") + " Вольт";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V51")
                    {
                        val = val / 255.0;
                        txtval = val.ToString("F2") + " Вольт";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "V12")
                    {
                        val = val / 16.0;
                        txtval = val.ToString("F2") + " Вольт";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "Kmh")
                    {
                        val = val * 1.61;
                        txtval = val.ToString("F1") + " Км/ч";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "T")
                    {
                        val = ((460.0 * val) / 255.0) - 200;
                        val = (val - 32) * 0.5556;
                        txtval = val.ToString("F2") + " Град. С";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "%")
                    {
                        val = (100.0 * val) / 255.0;
                        txtval = val.ToString("F0") + " %";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "PSI")
                    {
                        val = (29.4 * val) / 255.0;
                        if (val < 14.7)
                        {
                            val = 14.7 - val;
                            txtval = "-" + val.ToString("F2") + " PSI";
                        }
                        else
                        {
                            val = val - 14.7;
                            txtval = val.ToString("F2") + " PSI";
                        }
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "RPM2")
                    {
                        val = (8192 * val) / 255.0;
                        txtval = val.ToString("F0") + " Об/Мин";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "MS2")
                    {
                        //val = val / 255.0;
                        txtval = val.ToString("F0") + " Мс";
                    }
                    if (dataGridView1.Rows[comboBox1.SelectedIndex].Cells[2].Value == "ADV")
                    {
                        val = val / 2;
                        txtval = "-" + val.ToString("F0") + " Град.";
                    }
                }
                if (f == 0) level0.Text = txtval;
                if (f == 1) level1.Text = txtval;
                if (f == 2) level2.Text = txtval;
                if (f == 3) level3.Text = txtval;
                if (f == 4) level4.Text = txtval;
                if (f == 5) level5.Text = txtval;
            }        
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = (Image)bmp;
            count2 = 1;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            sendbytetosci(0x19);
            sendbytetosci(Convert.ToByte(numericUpDown1.Value / 8));
            listBox1.Enabled = false;
            button3.Enabled = true;
            button19.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 3 & !comboBox1.Enabled & checkBox3.Checked)
            
                //if (!comboBox1.Enabled)
                {
                    for (int f = Convert.ToInt16(Math.Floor(bmp.Height - ((bmp.Height - 30) + 1.0))); f < Convert.ToInt16(Math.Floor(bmp.Height - 1.0)); f++)
                    {
                        bmp.SetPixel(count2, f, Color.Gray);

                    }
                }
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            scrshot();
        }
        public void scrshot()
        {
            Bitmap bmpScreenShot = new Bitmap(pictureBox1.Width,pictureBox1.Height-21);
            Graphics gfx = Graphics.FromImage((Image)bmpScreenShot);
            //System.Drawing.Point point = new System.Drawing.Point(0, 0);
            System.Drawing.Point point = pictureBox1.PointToScreen(pictureBox1.Location);
            gfx.CopyFromScreen(point, new Point(0, 0), new Size(pictureBox1.Width, pictureBox1.Height-21));
            ImageCodecInfo icJPG = getCodecInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmpScreenShot.Save(DateTime.Now.ToString(@"dd\_MM\_yyyy h\_mm\_ss tt") + ".jpg", icJPG, myEncoderParameters);
            toolStripStatusLabel3.Text = "Экран сохранен в файл " + DateTime.Now.ToString(@"dd\_MM\_yyyy h\_mm\_ss tt") + ".jpg";
        }
        private ImageCodecInfo getCodecInfo(string mt)
        {
            ImageCodecInfo[] ici = ImageCodecInfo.GetImageEncoders();
            int idx = 0;
            for (int ii = 0; ii < ici.Length; ii++)
            {
                if (ici[ii].MimeType == mt)
                {
                    idx = ii;
                    break;
                }
            }
            return ici[idx];
        
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                if (!button19.Enabled)
                {
                    sendbytetosci(0x19);
                    sendbytetosci(Convert.ToByte(numericUpDown1.Value / 8));
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Card number for donadions: 4276 5500 4117 1904");
            //System.Diagnostics.Process.Start("www.paypal.me/chryslerdiagnost");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Card number for donations: 4276 5500 4117 1904");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Language switching disabled - application now uses English only
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EndEdit();
            dataGridView1.ClearSelection();
        }

        private void MakeScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // запоминаем размеры контрола
            Size szCurrent = this.Size;

            //ресайзим контрол до возможного максимума перед скриншотом
            this.AutoSize = true;

            //создаем картинку нужных размеров
            Bitmap bmp2 = new Bitmap(this.Width, this.Height);

            //копируем изображение нужного контрола в bmp
            this.DrawToBitmap(bmp2, new Rectangle(new Point(), this.Size));

            //возвращаем изначальные настройки контрола
            this.AutoSize = false;
            this.Size = szCurrent;
            bmp2.Save(DateTime.Now.ToString(@"dd\_MM\_yyyy h\_mm\_ss tt") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Изображение сохранено в файл: "+ DateTime.Now.ToString(@"dd\_MM\_yyyy h\_mm\_ss tt") + ".jpg в папке этого приложения.");
        }
    }
}
