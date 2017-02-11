namespace TitanPlanner
{
    partial class MainApp
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
            this.groupBox_Map = new System.Windows.Forms.GroupBox();
            this.pictureBox_Map = new System.Windows.Forms.PictureBox();
            this.treeView_steps = new System.Windows.Forms.TreeView();
            this.button_newStep = new System.Windows.Forms.Button();
            this.comboBox_StepType = new System.Windows.Forms.ComboBox();
            this.button_edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_export = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_TicksPerMeter = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label_ticksPerUnit = new System.Windows.Forms.Label();
            this.button_import = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_logger = new System.Windows.Forms.Button();
            this.groupBox_Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TicksPerMeter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Map
            // 
            this.groupBox_Map.Controls.Add(this.pictureBox_Map);
            this.groupBox_Map.Location = new System.Drawing.Point(2, 5);
            this.groupBox_Map.Name = "groupBox_Map";
            this.groupBox_Map.Size = new System.Drawing.Size(714, 727);
            this.groupBox_Map.TabIndex = 0;
            this.groupBox_Map.TabStop = false;
            this.groupBox_Map.Text = "Map";
            this.groupBox_Map.Enter += new System.EventHandler(this.groupBox_Map_Enter);
            // 
            // pictureBox_Map
            // 
            this.pictureBox_Map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Map.Image = global::TitanPlanner.Properties.Resources.VelocityVortexField_1;
            this.pictureBox_Map.Location = new System.Drawing.Point(7, 20);
            this.pictureBox_Map.Name = "pictureBox_Map";
            this.pictureBox_Map.Size = new System.Drawing.Size(700, 700);
            this.pictureBox_Map.TabIndex = 0;
            this.pictureBox_Map.TabStop = false;
            this.pictureBox_Map.Click += new System.EventHandler(this.pictureBox_Map_Click);
            // 
            // treeView_steps
            // 
            this.treeView_steps.Location = new System.Drawing.Point(749, 81);
            this.treeView_steps.Name = "treeView_steps";
            this.treeView_steps.Size = new System.Drawing.Size(196, 607);
            this.treeView_steps.TabIndex = 2;
            this.treeView_steps.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_steps_NodeMouseClick);
            // 
            // button_newStep
            // 
            this.button_newStep.Location = new System.Drawing.Point(749, 52);
            this.button_newStep.Name = "button_newStep";
            this.button_newStep.Size = new System.Drawing.Size(93, 23);
            this.button_newStep.TabIndex = 3;
            this.button_newStep.Text = "New Step";
            this.button_newStep.UseVisualStyleBackColor = true;
            this.button_newStep.Click += new System.EventHandler(this.CreateNewStep);
            // 
            // comboBox_StepType
            // 
            this.comboBox_StepType.FormattingEnabled = true;
            this.comboBox_StepType.Items.AddRange(new object[] {
            "Waypoint",
            "Rotation",
            "Choice"});
            this.comboBox_StepType.Location = new System.Drawing.Point(749, 25);
            this.comboBox_StepType.Name = "comboBox_StepType";
            this.comboBox_StepType.Size = new System.Drawing.Size(196, 21);
            this.comboBox_StepType.TabIndex = 4;
            this.comboBox_StepType.Text = "Waypoint";
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(852, 52);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(93, 23);
            this.button_edit.TabIndex = 6;
            this.button_edit.Text = "Edit Step";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(746, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type";
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(749, 731);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(196, 29);
            this.button_export.TabIndex = 9;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "titan";
            this.saveFileDialog1.Filter = "Titan Auto Files|*.titan";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 740);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ticks Per Meter";
            // 
            // nud_TicksPerMeter
            // 
            this.nud_TicksPerMeter.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_TicksPerMeter.Location = new System.Drawing.Point(97, 738);
            this.nud_TicksPerMeter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_TicksPerMeter.Name = "nud_TicksPerMeter";
            this.nud_TicksPerMeter.Size = new System.Drawing.Size(120, 20);
            this.nud_TicksPerMeter.TabIndex = 11;
            this.nud_TicksPerMeter.ValueChanged += new System.EventHandler(this.nud_TicksPerMeter_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(304, 738);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 740);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Field Width";
            // 
            // label_ticksPerUnit
            // 
            this.label_ticksPerUnit.AutoSize = true;
            this.label_ticksPerUnit.Location = new System.Drawing.Point(455, 740);
            this.label_ticksPerUnit.Name = "label_ticksPerUnit";
            this.label_ticksPerUnit.Size = new System.Drawing.Size(86, 13);
            this.label_ticksPerUnit.TabIndex = 14;
            this.label_ticksPerUnit.Text = "Ticks Per Unit = ";
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(749, 694);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(196, 31);
            this.button_import.TabIndex = 15;
            this.button_import.Text = "Import";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button_logger
            // 
            this.button_logger.Location = new System.Drawing.Point(668, 734);
            this.button_logger.Name = "button_logger";
            this.button_logger.Size = new System.Drawing.Size(75, 23);
            this.button_logger.TabIndex = 16;
            this.button_logger.Text = "Logger";
            this.button_logger.UseVisualStyleBackColor = true;
            this.button_logger.Click += new System.EventHandler(this.button_logger_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 765);
            this.Controls.Add(this.button_logger);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.label_ticksPerUnit);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nud_TicksPerMeter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.comboBox_StepType);
            this.Controls.Add(this.button_newStep);
            this.Controls.Add(this.treeView_steps);
            this.Controls.Add(this.groupBox_Map);
            this.Name = "MainApp";
            this.Text = "MainApp";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.groupBox_Map.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TicksPerMeter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Map;
        private System.Windows.Forms.PictureBox pictureBox_Map;
        private System.Windows.Forms.TreeView treeView_steps;
        private System.Windows.Forms.Button button_newStep;
        private System.Windows.Forms.ComboBox comboBox_StepType;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_TicksPerMeter;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_ticksPerUnit;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_logger;
    }
}