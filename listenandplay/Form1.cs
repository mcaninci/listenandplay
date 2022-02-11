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
        private Task playThread;
        private WaveOutEvent player;
        private bool listining = false;
        private Stopwatch stopWatch;
        private Stopwatch stopWatchDelay;
        private int silince, delay;
        private string voicePath;
        private CancellationTokenSource cancellationToken;
        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var device = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            comboBox1.Items.AddRange(device.ToArray());
            stopWatch = new Stopwatch();
            stopWatchDelay = new Stopwatch();
            player = new WaveOutEvent();
            cancellationToken = new CancellationTokenSource();



        }

        int statusflag = -1;
        bool firstVoice = false;
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
                        if (statusflag == -1)
                        {
                            lblstatus.AppendText("\nWaiting for the voice.");
                            statusflag = 0;
                        }

                        if ((devicevalue - ignore) > 0)
                        {
                            firstVoice = true;
                            if (statusflag != 1)
                            {
                                lblstatus.AppendText("\nSound Detected");
                                statusflag = 1;
                            }

                            stopWatch.Stop();
                        }
                        else if (firstVoice && (devicevalue - ignore) < 0)
                        {
                            if (statusflag != 2)
                            {
                                lblstatus.AppendText("\nSound has ended.");
                                statusflag = 2;
                            }


                            stopWatch.Start();


                        }
                        TimeSpan ts = stopWatch.Elapsed;

                        if (ts.Milliseconds > silince)
                        {
                            recorder.StopRecording();
                         
                            listining = false;

                            firstVoice = false;
                            statusflag = -1;
                            //wait delay time and play music
                            stopWatch.Stop();
                            stopWatch.Reset();
                        
                            if (statusflag != 3)
                            {
                                this.lblstatus.AppendText("\nDelay started");
                                statusflag = 3;
                            }
                       
                            playThread = Task.Run(async () =>
                                              {
                                                  if (!cancellationToken.IsCancellationRequested)
                                                  {
                                                      Thread.Sleep(delay);
                                                      
                                                      playVoice();

                                                      this.lblstatus.BeginInvoke((MethodInvoker)delegate ()
                                                     {
                                                      if (statusflag != 4)
                                                      {
                                                          this.lblstatus.AppendText("\nWave File Playing");
                                                          statusflag = 4;
                                                      }

                                                         });
                                                   
                                                  }


                                              }, cancellationToken.Token);
                           


                        }
                    }

                }
                progressBar1.Value = (devicevalue - ignore) < 0 ? 0 : devicevalue - ignore;
            }
        }


        private void playVoice()
        {
            timer1.Stop();
            WaveStream mainOutputStream = new WaveFileReader(voicePath);
            WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);
            volumeStream.PadWithZeroes = false;
            player = new WaveOutEvent();
            player.Init(volumeStream);
          
            player.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioOutput_PlaybackStopped);
            player.Play();
          

        }

        private  void audioOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            recorder.StartRecording();
            this.lblstatus.BeginInvoke((MethodInvoker)delegate () { Thread.Sleep(1000); this.lblstatus.Clear();  timer1.Start();});
          
            firstVoice = false;
            statusflag = -1;
            listining = true;
            

        }

        #region UI button config
        private void button2_Click(object sender, EventArgs e)
        {
            cancellationToken.Cancel();
            player.Stop();
            //recorder.StopRecording();
            //comboBox1.Text = "Select Microphone Item";
            ignoretxt.Enabled = true;
            txtdelay.Enabled = true;
            txtsilence.Enabled = true;
            button1.Enabled = true;
            lblstatus.Clear();
            progressBar1.Value = 0;
            listining = false;
            firstVoice = false;
            statusflag = -1;
     
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label7.Text = "Selected wav file : " + (string.IsNullOrEmpty(openFileDialog1.FileName) ? "You have to select voice file" : openFileDialog1.FileName);
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            recorder = new WaveIn();
            recorder.StartRecording();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(voicePath))
            {
                label7.Text = "Voice for Play : " + "You have to select voice file";
            }
            else
            {
                cancellationToken = new CancellationTokenSource();
                ignoretxt.Enabled = false;
                txtdelay.Enabled = false;
                txtsilence.Enabled = false;
                button1.Enabled = false;

                listining = true;
                silince = int.Parse(txtsilence.Text);
                delay = int.Parse(txtdelay.Text);
            }

        }
        #endregion
    }
}
