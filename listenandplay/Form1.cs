using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listenandplay
{
    public partial class Form1 : Form
    {
        private WaveIn recorder;

        private WaveOutEvent player;
        private bool listining = false;
        private Stopwatch stopWatch;
        private int silince, delay;
        private string voicePath;
        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var device = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            comboBox1.Items.AddRange(device.ToArray());
            stopWatch = new Stopwatch();

            player = new WaveOutEvent();



        }



        private void button1_Click(object sender, EventArgs e)
        {
            recorder = new WaveIn();
            recorder.StartRecording();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int ignore = 0;
                int.TryParse(ignoretxt.Text, out ignore);
                var device = (MMDevice)comboBox1.SelectedItem;
                device.AudioEndpointVolume.Mute = false;
                var devicevalue = (int)Math.Round(device.AudioMeterInformation.MasterPeakValue * 100);
                if (devicevalue > 0)
                {
                    label3.Text = ((devicevalue - ignore) < 0 ? 0 : devicevalue - ignore).ToString();
                    if (listining)
                    {


                        if ((devicevalue - ignore) > 0)
                        {
                            lblstatus.Text = "Voice detected.Waiting for the voice to stop.";
                            stopWatch.Stop();
                        }
                        else
                        {
                            lblstatus.Text = "Silence detected. The silence countdown is started.";
                            stopWatch.Start();


                        }
                        TimeSpan ts = stopWatch.Elapsed;

                        if (ts.Seconds > silince)
                        {
                            //wait delay time and play music
                            stopWatch.Stop();
                            stopWatch.Reset();
                            lblstatus.Text = "Delay time countdown is starting. The application will play selected voice after " + delay + " second " ;
                            Thread.Sleep(delay * 1000);
                            playVoice();
                        }
                    }

                }
                progressBar1.Value = (devicevalue - ignore) < 0 ? 0 : devicevalue - ignore;
            }
        }

        private void playVoice()
        {
            WaveStream mainOutputStream = new WaveFileReader(voicePath);
            WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);

            player.Init(volumeStream);

            player.Play();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
            recorder.StopRecording();
            ignoretxt.Enabled = true;
            txtdelay.Enabled = true;
            txtsilence.Enabled = true;
            button1.Enabled = true;
            listining = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label7.Text = "Voice for Play : " + (string.IsNullOrEmpty(openFileDialog1.FileName) ? "You have to select voice file" : openFileDialog1.FileName);
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                btnListen.Enabled = false;
            }
            else
            {

                btnListen.Enabled = true;
                voicePath = openFileDialog1.FileName;
               
            }
        }

        private void txtsilence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtdelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ignoretxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(voicePath))
            {
                label7.Text = "Voice for Play : " + "You have to select voice file";
            }
            else
            {
                ignoretxt.Enabled = false;
                txtdelay.Enabled = false;
                txtsilence.Enabled = false;
                button1.Enabled = false;
                listining = true;
                silince = int.Parse(txtsilence.Text);
                delay = int.Parse(txtdelay.Text);
            }
           
        }
    }
}
