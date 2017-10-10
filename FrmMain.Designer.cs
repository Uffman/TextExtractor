namespace TextExtractor
{
    partial class FrmMain
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
            this.btnSource = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.cbxRecursive = new System.Windows.Forms.CheckBox();
            this.lblSourcePath = new System.Windows.Forms.Label();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblNumberOFiles = new System.Windows.Forms.Label();
            this.pbProcessing = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.lblProcessedFiles = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(6, 19);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(125, 25);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Select Source Path";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(6, 19);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(125, 23);
            this.btnOutput.TabIndex = 1;
            this.btnOutput.Text = "Select Output Path";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // cbxRecursive
            // 
            this.cbxRecursive.AutoSize = true;
            this.cbxRecursive.Location = new System.Drawing.Point(153, 24);
            this.cbxRecursive.Name = "cbxRecursive";
            this.cbxRecursive.Size = new System.Drawing.Size(93, 17);
            this.cbxRecursive.TabIndex = 3;
            this.cbxRecursive.Text = "Subdirectories";
            this.cbxRecursive.UseVisualStyleBackColor = true;
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.CausesValidation = false;
            this.lblSourcePath.Location = new System.Drawing.Point(7, 51);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(0, 13);
            this.lblSourcePath.TabIndex = 4;
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(6, 45);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(0, 13);
            this.lblOutputPath.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.btnSource);
            this.groupBox1.Controls.Add(this.cbxRecursive);
            this.groupBox1.Controls.Add(this.lblSourcePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Path";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.btnOutput);
            this.groupBox2.Controls.Add(this.lblOutputPath);
            this.groupBox2.Location = new System.Drawing.Point(382, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Path";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 140);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblNumberOFiles
            // 
            this.lblNumberOFiles.AutoSize = true;
            this.lblNumberOFiles.Location = new System.Drawing.Point(115, 140);
            this.lblNumberOFiles.Name = "lblNumberOFiles";
            this.lblNumberOFiles.Size = new System.Drawing.Size(80, 13);
            this.lblNumberOFiles.TabIndex = 9;
            this.lblNumberOFiles.Text = "Number of files:";
            // 
            // pbProcessing
            // 
            this.pbProcessing.Location = new System.Drawing.Point(12, 169);
            this.pbProcessing.Name = "pbProcessing";
            this.pbProcessing.Size = new System.Drawing.Size(350, 23);
            this.pbProcessing.TabIndex = 11;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            // 
            // lblProcessedFiles
            // 
            this.lblProcessedFiles.AutoSize = true;
            this.lblProcessedFiles.Location = new System.Drawing.Point(115, 153);
            this.lblProcessedFiles.Name = "lblProcessedFiles";
            this.lblProcessedFiles.Size = new System.Drawing.Size(81, 13);
            this.lblProcessedFiles.TabIndex = 12;
            this.lblProcessedFiles.Text = "Processed files:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(750, 461);
            this.Controls.Add(this.lblProcessedFiles);
            this.Controls.Add(this.pbProcessing);
            this.Controls.Add(this.lblNumberOFiles);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.CheckBox cbxRecursive;
        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblNumberOFiles;
        private System.Windows.Forms.ProgressBar pbProcessing;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label lblProcessedFiles;
    }
}

