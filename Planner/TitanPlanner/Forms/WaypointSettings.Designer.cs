namespace TitanPlanner
{
    partial class WaypointSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nup_Length = new System.Windows.Forms.NumericUpDown();
            this.nup_Speed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nup_CoordX = new System.Windows.Forms.NumericUpDown();
            this.nup_coordY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_CoordX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_coordY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coord X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coord Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Length";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // nup_Length
            // 
            this.nup_Length.DecimalPlaces = 3;
            this.nup_Length.Location = new System.Drawing.Point(233, 9);
            this.nup_Length.Name = "nup_Length";
            this.nup_Length.Size = new System.Drawing.Size(73, 20);
            this.nup_Length.TabIndex = 5;
            this.nup_Length.ValueChanged += new System.EventHandler(this.nup_Length_ValueChanged);
            // 
            // nup_Speed
            // 
            this.nup_Speed.DecimalPlaces = 2;
            this.nup_Speed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nup_Speed.Location = new System.Drawing.Point(233, 40);
            this.nup_Speed.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nup_Speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nup_Speed.Name = "nup_Speed";
            this.nup_Speed.Size = new System.Drawing.Size(73, 20);
            this.nup_Speed.TabIndex = 7;
            this.nup_Speed.ValueChanged += new System.EventHandler(this.nup_Speed_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Speed (0-1)";
            // 
            // nup_CoordX
            // 
            this.nup_CoordX.DecimalPlaces = 2;
            this.nup_CoordX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nup_CoordX.Location = new System.Drawing.Point(64, 10);
            this.nup_CoordX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nup_CoordX.Name = "nup_CoordX";
            this.nup_CoordX.Size = new System.Drawing.Size(91, 20);
            this.nup_CoordX.TabIndex = 8;
            this.nup_CoordX.Value = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.nup_CoordX.ValueChanged += new System.EventHandler(this.nup_CoordX_ValueChanged);
            // 
            // nup_coordY
            // 
            this.nup_coordY.DecimalPlaces = 2;
            this.nup_coordY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nup_coordY.Location = new System.Drawing.Point(64, 40);
            this.nup_coordY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nup_coordY.Name = "nup_coordY";
            this.nup_coordY.Size = new System.Drawing.Size(91, 20);
            this.nup_coordY.TabIndex = 9;
            this.nup_coordY.Value = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.nup_coordY.ValueChanged += new System.EventHandler(this.nup_coordY_ValueChanged);
            // 
            // WaypointSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 71);
            this.Controls.Add(this.nup_coordY);
            this.Controls.Add(this.nup_CoordX);
            this.Controls.Add(this.nup_Speed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nup_Length);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.MaximumSize = new System.Drawing.Size(335, 110);
            this.Name = "WaypointSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waypoint Settings";
            this.Load += new System.EventHandler(this.WaypointSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nup_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_CoordX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_coordY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nup_Length;
        private System.Windows.Forms.NumericUpDown nup_Speed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nup_CoordX;
        private System.Windows.Forms.NumericUpDown nup_coordY;
    }
}