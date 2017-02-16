namespace TitanPlanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitanLogger));
            this.listBox_logs = new System.Windows.Forms.ListBox();
            this.label_phonestatus = new System.Windows.Forms.Label();
            this.label_serverstatus = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox_direction = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_Delta = new System.Windows.Forms.Label();
            this.label_multiplyer = new System.Windows.Forms.Label();
            this.label_encoder = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_direction)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_logs
            // 
            this.listBox_logs.FormattingEnabled = true;
            this.listBox_logs.Location = new System.Drawing.Point(3, 6);
            this.listBox_logs.Name = "listBox_logs";
            this.listBox_logs.Size = new System.Drawing.Size(439, 498);
            this.listBox_logs.TabIndex = 0;
            this.listBox_logs.SelectedIndexChanged += new System.EventHandler(this.listBox_logs_SelectedIndexChanged);
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
            this.label_serverstatus.Location = new System.Drawing.Point(12, 554);
            this.label_serverstatus.Name = "label_serverstatus";
            this.label_serverstatus.Size = new System.Drawing.Size(35, 13);
            this.label_serverstatus.TabIndex = 2;
            this.label_serverstatus.Text = "label1";
            this.label_serverstatus.Click += new System.EventHandler(this.label_serverstatus_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(328, 544);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(124, 23);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Start Server";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 537);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(442, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Formated";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_logs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raw";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox_direction
            // 
            this.pictureBox_direction.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_direction.InitialImage")));
            this.pictureBox_direction.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_direction.Name = "pictureBox_direction";
            this.pictureBox_direction.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_direction.TabIndex = 0;
            this.pictureBox_direction.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_encoder);
            this.groupBox1.Controls.Add(this.label_multiplyer);
            this.groupBox1.Controls.Add(this.label_Delta);
            this.groupBox1.Controls.Add(this.pictureBox_direction);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label_Delta
            // 
            this.label_Delta.AutoSize = true;
            this.label_Delta.Location = new System.Drawing.Point(113, 19);
            this.label_Delta.Name = "label_Delta";
            this.label_Delta.Size = new System.Drawing.Size(55, 13);
            this.label_Delta.TabIndex = 1;
            this.label_Delta.Text = "Delta: 0/0";
            // 
            // label_multiplyer
            // 
            this.label_multiplyer.AutoSize = true;
            this.label_multiplyer.Location = new System.Drawing.Point(113, 46);
            this.label_multiplyer.Name = "label_multiplyer";
            this.label_multiplyer.Size = new System.Drawing.Size(74, 13);
            this.label_multiplyer.TabIndex = 2;
            this.label_multiplyer.Text = "Multiplyer: 0/0";
            // 
            // label_encoder
            // 
            this.label_encoder.AutoSize = true;
            this.label_encoder.Location = new System.Drawing.Point(112, 72);
            this.label_encoder.Name = "label_encoder";
            this.label_encoder.Size = new System.Drawing.Size(50, 13);
            this.label_encoder.TabIndex = 3;
            this.label_encoder.Text = "Encoder:";
            // 
            // TitanLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 576);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_serverstatus);
            this.Controls.Add(this.label_phonestatus);
            this.Name = "TitanLogger";
            this.Text = "TitanLogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TitanLogger_FormClosing);
            this.Load += new System.EventHandler(this.TitanLogger_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_direction)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_logs;
        private System.Windows.Forms.Label label_phonestatus;
        private System.Windows.Forms.Label label_serverstatus;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox_direction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_multiplyer;
        private System.Windows.Forms.Label label_Delta;
        private System.Windows.Forms.Label label_encoder;
    }
}