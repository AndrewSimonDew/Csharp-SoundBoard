using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Net;
using System.Security.Policy;

namespace SoundBoard
{
    public partial class Form1 : Form
    {
        private Rectangle PlayOriginalR;
        private Rectangle SoundOriginalR;
        private Rectangle ComboOriginalR;
        private Rectangle StopOriginalR;
        private Rectangle AutoStopOriginalR;
        private Rectangle originalFormSize;
        private WaveOut waveOut;
        private WaveOut micWaveOut;
        static WasapiCapture capture;
        static BufferedWaveProvider buffer;
        private int index = 100;
        private bool isPlaying = false;
        private bool aStop = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            PlayOriginalR = new Rectangle(Play.Location.X, Play.Location.Y, Play.Width, Play.Height);
            SoundOriginalR = new Rectangle(newSound.Location.X, newSound.Location.Y, newSound.Width, newSound.Height);
            ComboOriginalR = new Rectangle(Sounds.Location.X, Sounds.Location.Y, Sounds.Width, Sounds.Height);
            StopOriginalR = new Rectangle(stop.Location.X, stop.Location.Y, stop.Width, stop.Height);
            AutoStopOriginalR = new Rectangle(autoStop.Location.X, autoStop.Location.Y, autoStop.Width, autoStop.Height);
            for (int idx = 0; idx < NAudio.Wave.WaveOut.DeviceCount; ++idx)
            {
                string devName = NAudio.Wave.WaveOut.GetCapabilities(idx).ProductName;

                if (devName.StartsWith("CABLE"))
                {
                    index = idx;
                    break;
                }
            }
            if (index == 100)
            {
                var result = MessageBox.Show("Le Kell Töltsed A VB Audio Cable-t! Le szeretnéd tölteni most?", "VB Audio Cable", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                //You Must Download VB Audio Cable!
                if (result == DialogResult.Yes)
                {
                    using (WebClient webClient = new WebClient())
                        try
                        {
                            webClient.DownloadFile("http://download.vb-audio.com/Download_CABLE/VBCABLE_Driver_Pack43.zip", "VBCable.zip");
                            MessageBox.Show("A Fájl Sikeresen letöltött!","Fájl!");//Download Succesful!
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error volt a fájl letöltése Közben!" + ex.Message,"Fájl");//Download Unsuccesful
                        }
                    }
                this.Close();
            }
            waveOut = new NAudio.Wave.WaveOut() { DeviceNumber = index };
            capture = new WasapiCapture();
            micWaveOut = new NAudio.Wave.WaveOut { DeviceNumber = index };
            capture.WaveFormat = new WaveFormat(44100, 16, 1);

            capture.DataAvailable += (sender, e) =>
            {
                buffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
            };
            buffer = new BufferedWaveProvider(capture.WaveFormat);
            buffer.BufferDuration = TimeSpan.FromSeconds(5);
            micWaveOut.Volume = 1.0f;
            capture.StartRecording();
            micWaveOut.Init(buffer);
            micWaveOut.Play();
        }




        private void Play_Click(object sender, EventArgs e)
        {
            if (Sounds.SelectedItem != null)
            {
                var reader = new NAudio.Wave.Mp3FileReader(Sounds.SelectedItem.ToString());
                if (isPlaying && aStop)
                {
                    waveOut.Dispose();
                    waveOut = new NAudio.Wave.WaveOut() { DeviceNumber = index };
                }
                waveOut.Init(reader);
                waveOut.Play();
                isPlaying = true;
            }
        }

        private void Selected(object sender, EventArgs e)
        {
            try
            {
                string path = Sounds.SelectedItem.ToString();
                var reader = new NAudio.Wave.Mp3FileReader(path);
                if(isPlaying && aStop)
                {
                    waveOut.Dispose();
                    waveOut = new NAudio.Wave.WaveOut() { DeviceNumber = index };
                }
                waveOut.Init(reader);
                waveOut.Play();
                isPlaying = true;
            }
            catch { }
        }

        private void Add(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Új Hang Kiválasztása";//Select A new Sound
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = true;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string[] paths = ofd.FileNames;
                foreach(string path in paths)
                {
                    if (path.EndsWith(".mp3"))
                    {
                        string name = Path.GetFileName(path).Replace(".mp3", "");
                        Sounds.Items.Add(path);
                    }
                    else
                    {
                        MessageBox.Show("Kérlek mp3 formátmú fájl(oka)t Válassz ki!","Új Hang");// You Must select an mp3 File!
                    }
                }
                
            }
        }
        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeControl(PlayOriginalR, Play);
            resizeControl(SoundOriginalR, newSound);
            resizeControl(ComboOriginalR, Sounds);
            resizeControl(StopOriginalR, stop);
            resizeControl(AutoStopOriginalR, autoStop);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                isPlaying = false;
                waveOut.Stop();
            }
        }



        private void autoStop_Click(object sender, EventArgs e)
        {
            if (autoStop.Text == "Hang Megállítása Új hang lejátszásakor(Be)")//Stop Sound When playing a new sound(On)
            {
                autoStop.Text = "Hang Megállítása Új hang lejátszásakor(Ki)";//Stop Sound When playing a new sound(Off)
                aStop = false;
            }
            else
            {
                autoStop.Text = "Hang Megállítása Új hang lejátszásakor(Be)";//Stop Sound When playing a new sound(On)
                aStop = true;
            }
        }

    }
}