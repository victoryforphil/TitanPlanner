﻿namespace TitanPlanner
{
    partial class TitanLogger
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
            this.listBox_logs = new System.Windows.Forms.ListBox();
            this.label_phonestatus = new System.Windows.Forms.Label();
            this.label_serverstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_logs
            // 
            this.listBox_logs.FormattingEnabled = true;
            this.listBox_logs.Location = new System.Drawing.Point(13, 13);
            this.listBox_logs.Name = "listBox_logs";
            this.listBox_logs.Size = new System.Drawing.Size(439, 524);
            this.listBox_logs.TabIndex = 0;
            // 
            // label_phonestatus
            // 
            this.label_phonestatus.AutoSize = true;
            this.label_phonestatus.Location = new System.Drawing.Point(12, 540);
            this.label_phonestatus.Name = "label_phonestatus";
            this.label_phonestatus.Size = new System.Drawing.Size(35, 13);
            this.label_phonestatus.TabIndex = 1;
            this.label_phonestatus.Text = "label1";
            this.label_phonestatus.Click += new System.EventHandler(this.label_phonestatus_Click);
            // 
            // label_serverstatus
            // 
            this.label_serverstatus.AutoSize = true;
            this.label_serverstatus.Location = new System.Drawing.Point(417, 540);
            this.label_serverstatus.Name = "label_serverstatus";
            this.label_serverstatus.Size = new System.Drawing.Size(35, 13);
            this.label_serverstatus.TabIndex = 2;
            this.label_serverstatus.Text = "label1";
            this.label_serverstatus.Click += new System.EventHandler(this.label_serverstatus_Click);
            // 
            // TitanLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 563);
            this.Controls.Add(this.label_serverstatus);
            this.Controls.Add(this.label_phonestatus);
            this.Controls.Add(this.listBox_logs);
            this.Name = "TitanLogger";
            this.Text = "TitanLogger";
            this.Load += new System.EventHandler(this.TitanLogger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_logs;
        private System.Windows.Forms.Label label_phonestatus;
        private System.Windows.Forms.Label label_serverstatus;
    }
}