using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PESRFullTextSearch
{
    public partial class Form1 : Form
    {
        private string SourcePath { get; set; }
        private string OutputPath { get; set; }

        public Form1()
        {
            InitializeComponent();
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
            List<InputData> inputFolderData = ReadInputFolderData(SourcePath);
            lblNumberOFiles.Text += inputFolderData.Count;
            WriteFullTextFiles(inputFolderData);
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

        private void WriteFullTextFiles(List<InputData> inputFolderData)
        {
            foreach (InputData inputData in inputFolderData)
            {
                if (File.Exists(inputData.FilePath))
                {
                    string readText = File.ReadAllText(inputData.FilePath);
                    string newFilePath = Path.Combine(OutputPath, inputData.FileName);
                    newFilePath += ".txt";
                    if (Directory.Exists(OutputPath))
                    {
                        File.WriteAllText(newFilePath, readText);
                    }
                }
            }

            MessageBox.Show("Process Completed!");
        }
    }
}
