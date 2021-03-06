
namespace listenandplay
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnstop = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ignoretxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsilence = new System.Windows.Forms.TextBox();
            this.txtdelay = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 458);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1104, 113);
            this.progressBar1.TabIndex = 0;
            // 
            // btnstop
            // 
            this.btnstop.Location = new System.Drawing.Point(556, 302);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(144, 47);
            this.btnstop.TabIndex = 2;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(175, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(543, 33);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Select Input Device";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mic devices";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "0";
            // 
            // ignoretxt
            // 
            this.ignoretxt.Location = new System.Drawing.Point(40, 318);
            this.ignoretxt.Name = "ignoretxt";
            this.ignoretxt.Size = new System.Drawing.Size(164, 31);
            this.ignoretxt.TabIndex = 7;
            this.ignoretxt.Text = "0";
            this.ignoretxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ignoretxt_KeyPress);
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Level to Ignore";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Silence Time (ms): ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Delay Time(ms):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Select wav file";
            // 
            // txtsilence
            // 
            this.txtsilence.Location = new System.Drawing.Point(40, 148);
            this.txtsilence.Name = "txtsilence";
            this.txtsilence.Size = new System.Drawing.Size(198, 31);
            this.txtsilence.TabIndex = 12;
            this.txtsilence.Text = "20";
            this.txtsilence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsilence_KeyPress);
            // 
            // txtdelay
            // 
            this.txtdelay.Location = new System.Drawing.Point(314, 148);
            this.txtdelay.Name = "txtdelay";
            this.txtdelay.Size = new System.Drawing.Size(146, 31);
            this.txtdelay.TabIndex = 13;
            this.txtdelay.Text = "80";
            this.txtdelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdelay_KeyPress);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(254, 302);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(223, 47);
            this.btnListen.TabIndex = 14;
            this.btnListen.Text = "Set Level && Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "waw,mp3";
            this.openFileDialog1.Filter = "wav files (*.wav)|*.wav";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Select voice to play";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 15;
            this.button1.Text = "Select Voice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblstatus
            // 
            this.lblstatus.Location = new System.Drawing.Point(40, 608);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.ReadOnly = true;
            this.lblstatus.Size = new System.Drawing.Size(1104, 182);
            this.lblstatus.TabIndex = 17;
            this.lblstatus.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 802);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtdelay);
            this.Controls.Add(this.txtsilence);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ignoretxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnstop);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1296, 873);
            this.MinimumSize = new System.Drawing.Size(1296, 873);
            this.Name = "Form1";
            this.Text = "Listen and Play V1.4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ignoretxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsilence;
        private System.Windows.Forms.TextBox txtdelay;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.RichTextBox lblstatus;
    }
}

