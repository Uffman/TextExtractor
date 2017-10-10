using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace TextExtractor
{
    public partial class FrmMain : Form
    {
        private string SourcePath { get; set; }
        private string OutputPath { get; set; }
        private int NumberOfFiles { get; set; }
        private int ProcessedFiles { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<InputData> inputFolderData = (List<InputData>)e.Argument;
            WriteFullTextFiles(inputFolderData, worker);
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Process Completed!");
            ProcessedFiles = 0;
            NumberOfFiles = 0;
            btnStart.Enabled = btnSource.Enabled = btnOutput.Enabled = cbxRecursive.Enabled = true;
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProcessing.Value = e.ProgressPercentage;
            lblProcessedFiles.Text = $"Processed files: {ProcessedFiles}";
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserSource = new FolderBrowserDialog();

            if (folderBrowserSource.ShowDialog() == DialogResult.OK)
            {
                SourcePath = folderBrowserSource.SelectedPath;
                lblSourcePath.Text = SourcePath;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserOutput = new FolderBrowserDialog();
            if (folderBrowserOutput.ShowDialog() == DialogResult.OK)
            {
                OutputPath = folderBrowserOutput.SelectedPath;
                lblOutputPath.Text = OutputPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lblOutputPath.Text) || String.IsNullOrEmpty(lblSourcePath.Text))
            {
                MessageBox.Show("Select 'Source' and 'Output paths!");
            }
            else
            {
                btnStart.Enabled = btnSource.Enabled = btnOutput.Enabled = cbxRecursive.Enabled = false;
                List<InputData> inputFolderData = ReadInputFolderData(SourcePath);

                NumberOfFiles = inputFolderData.Count;
                lblNumberOFiles.Text = $"Number of files: {NumberOfFiles}";

                bgWorker.RunWorkerAsync(inputFolderData);
            }
        }

        private List<InputData> ReadInputFolderData(string inputFolder)
        {
            // read all directories and sub-direcories
            List<string> directoriesList = new List<string>();

            if (cbxRecursive.Checked)
            {
                string[] directories = Directory.GetDirectories(inputFolder, "*.*", SearchOption.AllDirectories);
                directoriesList.AddRange(directories);
            }
            // add parent directory
            directoriesList.Add(inputFolder);

            List<InputData> inputFolderData = new List<InputData>();
            foreach (string directory in directoriesList)
            {
                String[] files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly);

                foreach (string filePath in files)
                {
                    InputData inputData = new InputData
                    {
                        FilePath = filePath,
                        FileName = Path.GetFileName(filePath),
                        SourceDirectory = directory
                    };

                    inputFolderData.Add(inputData);
                }
            }

            return inputFolderData;
        }

        private void WriteFullTextFiles(List<InputData> inputFolderData, BackgroundWorker worker)
        {
            foreach (InputData inputData in inputFolderData)
            {
                ProcessedFiles++;
                if (File.Exists(inputData.FilePath))
                {
                    // read file text
                    string readText = File.ReadAllText(inputData.FilePath);
                    string newFilePath = Path.Combine(OutputPath, inputData.FileName);
                    newFilePath += ".txt";
                    newFilePath = MakeUniqueName(newFilePath);

                    if (Directory.Exists(OutputPath))
                    {
                        // write text to new file                        
                        File.WriteAllText(newFilePath, readText);
                        
                        // calculate procentage
                        int percentComplete = (int)((float)ProcessedFiles / (float)NumberOfFiles * 100);
                        if (percentComplete > 0)
                        {
                            worker.ReportProgress(percentComplete);
                        }
                    }
                }
            }
        }

        public string MakeUniqueName(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path))
                {
                    return path;
                }
                path = Path.Combine(dir, fileName + "_" + i + fileExt);
            }
        }
    }
}
