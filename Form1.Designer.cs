namespace SoundBoard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Play = new System.Windows.Forms.Button();
            this.Sounds = new System.Windows.Forms.ListBox();
            this.newSound = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.autoStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(12, 12);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(106, 42);
            this.Play.TabIndex = 1;
            this.Play.Text = "Lejátszás";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Sounds
            // 
            this.Sounds.FormattingEnabled = true;
            this.Sounds.ItemHeight = 15;
            this.Sounds.Location = new System.Drawing.Point(12, 64);
            this.Sounds.Name = "Sounds";
            this.Sounds.Size = new System.Drawing.Size(782, 364);
            this.Sounds.TabIndex = 2;
            this.Sounds.Click += new System.EventHandler(this.Selected);
            this.Sounds.DoubleClick += new System.EventHandler(this.Sounds_DoubleClick);
            // 
            // newSound
            // 
            this.newSound.Location = new System.Drawing.Point(124, 12);
            this.newSound.Name = "newSound";
            this.newSound.Size = new System.Drawing.Size(106, 42);
            this.newSound.TabIndex = 3;
            this.newSound.Text = "Új hang";
            this.newSound.UseVisualStyleBackColor = true;
            this.newSound.Click += new System.EventHandler(this.Add);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(236, 12);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(106, 42);
            this.stop.TabIndex = 4;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // autoStop
            // 
            this.autoStop.Location = new System.Drawing.Point(348, 12);
            this.autoStop.Name = "autoStop";
            this.autoStop.Size = new System.Drawing.Size(135, 42);
            this.autoStop.TabIndex = 5;
            this.autoStop.Text = "Hang Megállítása Új hang lejátszásakor(Be)";
            this.autoStop.UseVisualStyleBackColor = true;
            this.autoStop.Click += new System.EventHandler(this.autoStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 440);
            this.Controls.Add(this.autoStop);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.newSound);
            this.Controls.Add(this.Sounds);
            this.Controls.Add(this.Play);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoundBoard(By:AndrewDEV#1357)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private Button Play;
        private ListBox Sounds;
        private Button newSound;
        private Button stop;
        private Button autoStop;
    }
}