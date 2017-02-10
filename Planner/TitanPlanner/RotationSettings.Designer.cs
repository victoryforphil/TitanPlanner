namespace TitanPlanner
{
    partial class RotationSettings
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
            this.checkBox_Gyro = new System.Windows.Forms.CheckBox();
            this.groupBox_Gyro = new System.Windows.Forms.GroupBox();
            this.numericUpDown_Gyro = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_Encoder = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_Gyro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Gyro)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Encoder)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_Gyro
            // 
            this.checkBox_Gyro.AutoSize = true;
            this.checkBox_Gyro.Location = new System.Drawing.Point(6, 19);
            this.checkBox_Gyro.Name = "checkBox_Gyro";
            this.checkBox_Gyro.Size = new System.Drawing.Size(70, 17);
            this.checkBox_Gyro.TabIndex = 1;
            this.checkBox_Gyro.Text = "Use Gyro";
            this.checkBox_Gyro.UseVisualStyleBackColor = true;
            this.checkBox_Gyro.CheckedChanged += new System.EventHandler(this.checkBox_Gyro_CheckedChanged);
            // 
            // groupBox_Gyro
            // 
            this.groupBox_Gyro.Controls.Add(this.numericUpDown_Gyro);
            this.groupBox_Gyro.Controls.Add(this.checkBox_Gyro);
            this.groupBox_Gyro.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Gyro.Name = "groupBox_Gyro";
            this.groupBox_Gyro.Size = new System.Drawing.Size(89, 73);
            this.groupBox_Gyro.TabIndex = 2;
            this.groupBox_Gyro.TabStop = false;
            this.groupBox_Gyro.Text = "Gyro Settings";
            this.groupBox_Gyro.UseCompatibleTextRendering = true;
            // 
            // numericUpDown_Gyro
            // 
            this.numericUpDown_Gyro.Enabled = false;
            this.numericUpDown_Gyro.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Gyro.Location = new System.Drawing.Point(7, 43);
            this.numericUpDown_Gyro.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numericUpDown_Gyro.Name = "numericUpDown_Gyro";
            this.numericUpDown_Gyro.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown_Gyro.TabIndex = 2;
            this.numericUpDown_Gyro.ValueChanged += new System.EventHandler(this.numericUpDown_Gyro_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown_Encoder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(108, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encoder Settings";
            // 
            // numericUpDown_Encoder
            // 
            this.numericUpDown_Encoder.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_Encoder.Location = new System.Drawing.Point(60, 20);
            this.numericUpDown_Encoder.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Encoder.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Encoder.Name = "numericUpDown_Encoder";
            this.numericUpDown_Encoder.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown_Encoder.TabIndex = 3;
            this.numericUpDown_Encoder.Tag = "Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encoder";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RotationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 95);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Gyro);
            this.Name = "RotationSettings";
            this.Text = "RotationSettings";
            this.Load += new System.EventHandler(this.RotationSettings_Load);
            this.groupBox_Gyro.ResumeLayout(false);
            this.groupBox_Gyro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Gyro)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Encoder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Gyro;
        private System.Windows.Forms.GroupBox groupBox_Gyro;
        private System.Windows.Forms.NumericUpDown numericUpDown_Gyro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Encoder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}