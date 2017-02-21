namespace TitanPlanner
{
    partial class DriveConfig
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox_FL_Reversed = new System.Windows.Forms.CheckBox();
            this.checkBox_RL_Reversed = new System.Windows.Forms.CheckBox();
            this.checkBox_RR_Reversed = new System.Windows.Forms.CheckBox();
            this.checkBox_FR_Reversed = new System.Windows.Forms.CheckBox();
            this.textBox_FL = new System.Windows.Forms.TextBox();
            this.textBox_RL = new System.Windows.Forms.TextBox();
            this.textBox_RR = new System.Windows.Forms.TextBox();
            this.textBox_FR = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TitanPlanner.Properties.Resources.Holonomic_Drive_2x;
            this.pictureBox1.Location = new System.Drawing.Point(115, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox_FL_Reversed
            // 
            this.checkBox_FL_Reversed.AutoSize = true;
            this.checkBox_FL_Reversed.Location = new System.Drawing.Point(9, 38);
            this.checkBox_FL_Reversed.Name = "checkBox_FL_Reversed";
            this.checkBox_FL_Reversed.Size = new System.Drawing.Size(72, 17);
            this.checkBox_FL_Reversed.TabIndex = 5;
            this.checkBox_FL_Reversed.Text = "Reversed";
            this.checkBox_FL_Reversed.UseVisualStyleBackColor = true;
            // 
            // checkBox_RL_Reversed
            // 
            this.checkBox_RL_Reversed.AutoSize = true;
            this.checkBox_RL_Reversed.Location = new System.Drawing.Point(9, 204);
            this.checkBox_RL_Reversed.Name = "checkBox_RL_Reversed";
            this.checkBox_RL_Reversed.Size = new System.Drawing.Size(72, 17);
            this.checkBox_RL_Reversed.TabIndex = 6;
            this.checkBox_RL_Reversed.Text = "Reversed";
            this.checkBox_RL_Reversed.UseVisualStyleBackColor = true;
            // 
            // checkBox_RR_Reversed
            // 
            this.checkBox_RR_Reversed.AutoSize = true;
            this.checkBox_RR_Reversed.Location = new System.Drawing.Point(321, 204);
            this.checkBox_RR_Reversed.Name = "checkBox_RR_Reversed";
            this.checkBox_RR_Reversed.Size = new System.Drawing.Size(72, 17);
            this.checkBox_RR_Reversed.TabIndex = 7;
            this.checkBox_RR_Reversed.Text = "Reversed";
            this.checkBox_RR_Reversed.UseVisualStyleBackColor = true;
            // 
            // checkBox_FR_Reversed
            // 
            this.checkBox_FR_Reversed.AutoSize = true;
            this.checkBox_FR_Reversed.Location = new System.Drawing.Point(321, 38);
            this.checkBox_FR_Reversed.Name = "checkBox_FR_Reversed";
            this.checkBox_FR_Reversed.Size = new System.Drawing.Size(72, 17);
            this.checkBox_FR_Reversed.TabIndex = 8;
            this.checkBox_FR_Reversed.Text = "Reversed";
            this.checkBox_FR_Reversed.UseVisualStyleBackColor = true;
            // 
            // textBox_FL
            // 
            this.textBox_FL.Location = new System.Drawing.Point(9, 12);
            this.textBox_FL.Name = "textBox_FL";
            this.textBox_FL.Size = new System.Drawing.Size(100, 20);
            this.textBox_FL.TabIndex = 9;
            // 
            // textBox_RL
            // 
            this.textBox_RL.Location = new System.Drawing.Point(9, 178);
            this.textBox_RL.Name = "textBox_RL";
            this.textBox_RL.Size = new System.Drawing.Size(100, 20);
            this.textBox_RL.TabIndex = 10;
            // 
            // textBox_RR
            // 
            this.textBox_RR.Location = new System.Drawing.Point(321, 178);
            this.textBox_RR.Name = "textBox_RR";
            this.textBox_RR.Size = new System.Drawing.Size(100, 20);
            this.textBox_RR.TabIndex = 11;
            // 
            // textBox_FR
            // 
            this.textBox_FR.Location = new System.Drawing.Point(321, 12);
            this.textBox_FR.Name = "textBox_FR";
            this.textBox_FR.Size = new System.Drawing.Size(100, 20);
            this.textBox_FR.TabIndex = 12;
            // 
            // DriveConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 241);
            this.Controls.Add(this.textBox_FR);
            this.Controls.Add(this.textBox_RR);
            this.Controls.Add(this.textBox_RL);
            this.Controls.Add(this.textBox_FL);
            this.Controls.Add(this.checkBox_FR_Reversed);
            this.Controls.Add(this.checkBox_RR_Reversed);
            this.Controls.Add(this.checkBox_RL_Reversed);
            this.Controls.Add(this.checkBox_FL_Reversed);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DriveConfig";
            this.Text = "DriveConfigs";
            this.Load += new System.EventHandler(this.DriveConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox_FL_Reversed;
        private System.Windows.Forms.CheckBox checkBox_RL_Reversed;
        private System.Windows.Forms.CheckBox checkBox_RR_Reversed;
        private System.Windows.Forms.CheckBox checkBox_FR_Reversed;
        private System.Windows.Forms.TextBox textBox_FL;
        private System.Windows.Forms.TextBox textBox_RL;
        private System.Windows.Forms.TextBox textBox_RR;
        private System.Windows.Forms.TextBox textBox_FR;
    }
}