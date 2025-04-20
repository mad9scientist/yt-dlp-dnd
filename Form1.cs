using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yt_dlp_dnd 
{
    public partial class Form1 : Form
    {
    
        private string ytDlpPath;
        private string ffmpegPath;
        private string downloadFolder;
        
        public Form1()
        {
            InitializeComponent();
            LoadConfig();

            // Enable drag-and-drop
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private async void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string url = null;

            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                url = e.Data.GetData(DataFormats.Text).ToString();
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && Path.GetExtension(files[0]).Equals(".url", StringComparison.OrdinalIgnoreCase))
                {
                    url = ExtractUrlFromShortcut(files[0]);
                }
            }

            if (!string.IsNullOrEmpty(url))
            {
                await RunYtDlp(url);
            }
            else
            {
                MessageBox.Show("Could not get a valid URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtractUrlFromShortcut(string path)
        {
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (line.StartsWith("URL=", StringComparison.OrdinalIgnoreCase))
                {
                    return line.Substring(4).Trim();
                }
            }
            return null;
        }

        private async Task RunYtDlp(string url)
        {

            await Task.Run(() =>
            {
                this.Invoke(() => {
                    progressBar.Visible = true;
                    // outputTextBox.Clear();
                    // outputTextBox.AppendText($"Starting download: {url}{Environment.NewLine}");
                });

                var psi = new ProcessStartInfo
                {
                    FileName = ytDlpPath,
                    Arguments = $"\"{url}\" -o \"{Path.Combine(downloadFolder, "%(title)s.%(ext)s")}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                try
                {
                    var process = Process.Start(psi);
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    this.Invoke(() => 
                    {
                        progressBar.Visible = false;
                        ShowToast("Download Complete", $"Video downloaded:\n{url}");
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to run yt-dlp:\n" + ex.Message);
                }
            });
        }

        private void ShowToast(string title, string message)
        {
            NotifyIcon ni = new NotifyIcon
            {
                BalloonTipTitle = title,
                BalloonTipText = message,
                Visible = true,
                Icon = SystemIcons.Information
            };

            ni.ShowBalloonTip(3000);
            Task.Delay(5000).ContinueWith(_ => ni.Dispose());
        }
        private void LoadConfig()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
            var ini = new IniFile(configPath);

            ytDlpPath       = ini.Read("Paths", "yt_dlp", "yt-dlp");
            ffmpegPath      = ini.Read("Paths", "ffmpeg", "ffmpeg");
            downloadFolder  = ini.Read("Output", "download_folder", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}