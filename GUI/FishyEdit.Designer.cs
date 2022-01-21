
namespace GUI
{
    partial class FishyEdit
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
            this.CloseBttn = new System.Windows.Forms.Button();
            this.LoadBttn = new System.Windows.Forms.Button();
            this.SaveBttn = new System.Windows.Forms.Button();
            this.NextImgBttn = new System.Windows.Forms.Button();
            this.PrevImgBttn = new System.Windows.Forms.Button();
            this.FlipYBttn = new System.Windows.Forms.Button();
            this.FlipXBttn = new System.Windows.Forms.Button();
            this.Rot90Bttn = new System.Windows.Forms.Button();
            this.ImgDisplay = new System.Windows.Forms.PictureBox();
            this.ACRot90Bttn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ScaleBttn = new System.Windows.Forms.Button();
            this.CropBttn = new System.Windows.Forms.Button();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.radioFilter4 = new System.Windows.Forms.RadioButton();
            this.radioFilter3 = new System.Windows.Forms.RadioButton();
            this.radioFilter2 = new System.Windows.Forms.RadioButton();
            this.radioFilter1 = new System.Windows.Forms.RadioButton();
            this.groupBoxOrientation = new System.Windows.Forms.GroupBox();
            this.groupBoxImageCtrl = new System.Windows.Forms.GroupBox();
            this.ContrastControl = new System.Windows.Forms.NumericUpDown();
            this.lblContrast = new System.Windows.Forms.Label();
            this.SaturationControl = new System.Windows.Forms.NumericUpDown();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.BrightnessControl = new System.Windows.Forms.NumericUpDown();
            this.groupBoxColouring = new System.Windows.Forms.GroupBox();
            this.radialFilterRemove = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).BeginInit();
            this.groupBoxFilters.SuspendLayout();
            this.groupBoxOrientation.SuspendLayout();
            this.groupBoxImageCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessControl)).BeginInit();
            this.groupBoxColouring.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBttn
            // 
            this.CloseBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBttn.Font = new System.Drawing.Font("Calibri", 20F);
            this.CloseBttn.Location = new System.Drawing.Point(743, 12);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(36, 38);
            this.CloseBttn.TabIndex = 1;
            this.CloseBttn.Text = "X";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // LoadBttn
            // 
            this.LoadBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadBttn.Location = new System.Drawing.Point(29, 27);
            this.LoadBttn.Name = "LoadBttn";
            this.LoadBttn.Size = new System.Drawing.Size(100, 30);
            this.LoadBttn.TabIndex = 3;
            this.LoadBttn.Text = "Load Image";
            this.LoadBttn.UseVisualStyleBackColor = true;
            this.LoadBttn.Click += new System.EventHandler(this.LoadBttn_Click);
            // 
            // SaveBttn
            // 
            this.SaveBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBttn.Location = new System.Drawing.Point(29, 63);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(100, 30);
            this.SaveBttn.TabIndex = 4;
            this.SaveBttn.Text = "Save Image";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // NextImgBttn
            // 
            this.NextImgBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextImgBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextImgBttn.Location = new System.Drawing.Point(29, 132);
            this.NextImgBttn.Name = "NextImgBttn";
            this.NextImgBttn.Size = new System.Drawing.Size(100, 27);
            this.NextImgBttn.TabIndex = 5;
            this.NextImgBttn.Text = "Next ->";
            this.NextImgBttn.UseVisualStyleBackColor = true;
            this.NextImgBttn.Click += new System.EventHandler(this.NextImgBttn_Click);
            // 
            // PrevImgBttn
            // 
            this.PrevImgBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrevImgBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevImgBttn.Location = new System.Drawing.Point(29, 99);
            this.PrevImgBttn.Name = "PrevImgBttn";
            this.PrevImgBttn.Size = new System.Drawing.Size(100, 27);
            this.PrevImgBttn.TabIndex = 5;
            this.PrevImgBttn.Text = "Prev";
            this.PrevImgBttn.UseVisualStyleBackColor = true;
            this.PrevImgBttn.Click += new System.EventHandler(this.PrevImgBttn_Click);
            // 
            // FlipYBttn
            // 
            this.FlipYBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlipYBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipYBttn.Location = new System.Drawing.Point(128, 31);
            this.FlipYBttn.Name = "FlipYBttn";
            this.FlipYBttn.Size = new System.Drawing.Size(80, 30);
            this.FlipYBttn.TabIndex = 6;
            this.FlipYBttn.Text = "Flip Y";
            this.FlipYBttn.UseVisualStyleBackColor = true;
            this.FlipYBttn.Click += new System.EventHandler(this.FlipYBttn_Click);
            // 
            // FlipXBttn
            // 
            this.FlipXBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlipXBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipXBttn.Location = new System.Drawing.Point(42, 31);
            this.FlipXBttn.Name = "FlipXBttn";
            this.FlipXBttn.Size = new System.Drawing.Size(80, 30);
            this.FlipXBttn.TabIndex = 7;
            this.FlipXBttn.Text = "Flip X";
            this.FlipXBttn.UseVisualStyleBackColor = true;
            this.FlipXBttn.Click += new System.EventHandler(this.FlipXBttn_Click);
            // 
            // Rot90Bttn
            // 
            this.Rot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rot90Bttn.Location = new System.Drawing.Point(22, 67);
            this.Rot90Bttn.Name = "Rot90Bttn";
            this.Rot90Bttn.Size = new System.Drawing.Size(100, 30);
            this.Rot90Bttn.TabIndex = 8;
            this.Rot90Bttn.Text = "Rotate 90*";
            this.Rot90Bttn.UseVisualStyleBackColor = true;
            this.Rot90Bttn.Click += new System.EventHandler(this.Rot90Bttn_Click);
            // 
            // ImgDisplay
            // 
            this.ImgDisplay.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ImgDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImgDisplay.Location = new System.Drawing.Point(48, 37);
            this.ImgDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.ImgDisplay.Name = "ImgDisplay";
            this.ImgDisplay.Size = new System.Drawing.Size(400, 200);
            this.ImgDisplay.TabIndex = 9;
            this.ImgDisplay.TabStop = false;
            // 
            // ACRot90Bttn
            // 
            this.ACRot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ACRot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACRot90Bttn.Location = new System.Drawing.Point(128, 67);
            this.ACRot90Bttn.Name = "ACRot90Bttn";
            this.ACRot90Bttn.Size = new System.Drawing.Size(100, 30);
            this.ACRot90Bttn.TabIndex = 10;
            this.ACRot90Bttn.Text = "Rotate -90*";
            this.ACRot90Bttn.UseVisualStyleBackColor = true;
            this.ACRot90Bttn.Click += new System.EventHandler(this.ACRot90Bttn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 292);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 20);
            this.textBox1.TabIndex = 11;
            // 
            // ScaleBttn
            // 
            this.ScaleBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ScaleBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScaleBttn.Location = new System.Drawing.Point(22, 103);
            this.ScaleBttn.Name = "ScaleBttn";
            this.ScaleBttn.Size = new System.Drawing.Size(100, 30);
            this.ScaleBttn.TabIndex = 16;
            this.ScaleBttn.Text = "Scale";
            this.ScaleBttn.UseVisualStyleBackColor = true;
            // 
            // CropBttn
            // 
            this.CropBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CropBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropBttn.Location = new System.Drawing.Point(128, 103);
            this.CropBttn.Name = "CropBttn";
            this.CropBttn.Size = new System.Drawing.Size(100, 30);
            this.CropBttn.TabIndex = 17;
            this.CropBttn.Text = "Crop";
            this.CropBttn.UseVisualStyleBackColor = true;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.radialFilterRemove);
            this.groupBoxFilters.Controls.Add(this.radioFilter4);
            this.groupBoxFilters.Controls.Add(this.radioFilter3);
            this.groupBoxFilters.Controls.Add(this.radioFilter2);
            this.groupBoxFilters.Controls.Add(this.radioFilter1);
            this.groupBoxFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxFilters.Location = new System.Drawing.Point(617, 261);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(131, 227);
            this.groupBoxFilters.TabIndex = 24;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            // 
            // radioFilter4
            // 
            this.radioFilter4.AutoSize = true;
            this.radioFilter4.Location = new System.Drawing.Point(18, 139);
            this.radioFilter4.Name = "radioFilter4";
            this.radioFilter4.Size = new System.Drawing.Size(96, 30);
            this.radioFilter4.TabIndex = 3;
            this.radioFilter4.TabStop = true;
            this.radioFilter4.Text = "Filter 4";
            this.radioFilter4.UseVisualStyleBackColor = true;
            this.radioFilter4.CheckedChanged += new System.EventHandler(this.radioFilter4_CheckedChanged);
            // 
            // radioFilter3
            // 
            this.radioFilter3.AutoSize = true;
            this.radioFilter3.Location = new System.Drawing.Point(18, 103);
            this.radioFilter3.Name = "radioFilter3";
            this.radioFilter3.Size = new System.Drawing.Size(96, 30);
            this.radioFilter3.TabIndex = 2;
            this.radioFilter3.TabStop = true;
            this.radioFilter3.Text = "Filter 3";
            this.radioFilter3.UseVisualStyleBackColor = true;
            this.radioFilter3.CheckedChanged += new System.EventHandler(this.radioFilter3_CheckedChanged);
            // 
            // radioFilter2
            // 
            this.radioFilter2.AutoSize = true;
            this.radioFilter2.Location = new System.Drawing.Point(18, 67);
            this.radioFilter2.Name = "radioFilter2";
            this.radioFilter2.Size = new System.Drawing.Size(96, 30);
            this.radioFilter2.TabIndex = 1;
            this.radioFilter2.TabStop = true;
            this.radioFilter2.Text = "Filter 2";
            this.radioFilter2.UseVisualStyleBackColor = true;
            this.radioFilter2.CheckedChanged += new System.EventHandler(this.radioFilter2_CheckedChanged);
            // 
            // radioFilter1
            // 
            this.radioFilter1.AutoSize = true;
            this.radioFilter1.Location = new System.Drawing.Point(18, 31);
            this.radioFilter1.Name = "radioFilter1";
            this.radioFilter1.Size = new System.Drawing.Size(96, 30);
            this.radioFilter1.TabIndex = 0;
            this.radioFilter1.TabStop = true;
            this.radioFilter1.Text = "Filter 1";
            this.radioFilter1.UseVisualStyleBackColor = true;
            this.radioFilter1.CheckedChanged += new System.EventHandler(this.radioFilter1_CheckedChanged);
            // 
            // groupBoxOrientation
            // 
            this.groupBoxOrientation.Controls.Add(this.FlipXBttn);
            this.groupBoxOrientation.Controls.Add(this.FlipYBttn);
            this.groupBoxOrientation.Controls.Add(this.Rot90Bttn);
            this.groupBoxOrientation.Controls.Add(this.CropBttn);
            this.groupBoxOrientation.Controls.Add(this.ACRot90Bttn);
            this.groupBoxOrientation.Controls.Add(this.ScaleBttn);
            this.groupBoxOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxOrientation.Location = new System.Drawing.Point(291, 261);
            this.groupBoxOrientation.Name = "groupBoxOrientation";
            this.groupBoxOrientation.Size = new System.Drawing.Size(250, 144);
            this.groupBoxOrientation.TabIndex = 26;
            this.groupBoxOrientation.TabStop = false;
            this.groupBoxOrientation.Text = "Orientation";
            // 
            // groupBoxImageCtrl
            // 
            this.groupBoxImageCtrl.Controls.Add(this.LoadBttn);
            this.groupBoxImageCtrl.Controls.Add(this.SaveBttn);
            this.groupBoxImageCtrl.Controls.Add(this.NextImgBttn);
            this.groupBoxImageCtrl.Controls.Add(this.PrevImgBttn);
            this.groupBoxImageCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxImageCtrl.Location = new System.Drawing.Point(548, 61);
            this.groupBoxImageCtrl.Name = "groupBoxImageCtrl";
            this.groupBoxImageCtrl.Size = new System.Drawing.Size(166, 176);
            this.groupBoxImageCtrl.TabIndex = 27;
            this.groupBoxImageCtrl.TabStop = false;
            this.groupBoxImageCtrl.Text = "Image Control";
            // 
            // ContrastControl
            // 
            this.ContrastControl.Location = new System.Drawing.Point(24, 110);
            this.ContrastControl.Name = "ContrastControl";
            this.ContrastControl.Size = new System.Drawing.Size(120, 32);
            this.ContrastControl.TabIndex = 19;
            this.ContrastControl.ValueChanged += new System.EventHandler(this.ContrastControl_ValueChanged);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblContrast.Location = new System.Drawing.Point(42, 89);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(70, 20);
            this.lblContrast.TabIndex = 22;
            this.lblContrast.Text = "Contrast";
            // 
            // SaturationControl
            // 
            this.SaturationControl.Location = new System.Drawing.Point(22, 173);
            this.SaturationControl.Name = "SaturationControl";
            this.SaturationControl.Size = new System.Drawing.Size(120, 32);
            this.SaturationControl.TabIndex = 20;
            this.SaturationControl.ValueChanged += new System.EventHandler(this.SaturationControl_ValueChanged);
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSaturation.Location = new System.Drawing.Point(42, 150);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(83, 20);
            this.lblSaturation.TabIndex = 23;
            this.lblSaturation.Text = "Saturation";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBrightness.Location = new System.Drawing.Point(42, 31);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(85, 20);
            this.lblBrightness.TabIndex = 21;
            this.lblBrightness.Text = "Brightness";
            // 
            // BrightnessControl
            // 
            this.BrightnessControl.Location = new System.Drawing.Point(24, 54);
            this.BrightnessControl.Name = "BrightnessControl";
            this.BrightnessControl.Size = new System.Drawing.Size(120, 32);
            this.BrightnessControl.TabIndex = 18;
            this.BrightnessControl.ValueChanged += new System.EventHandler(this.BrightnessControl_ValueChanged);
            // 
            // groupBoxColouring
            // 
            this.groupBoxColouring.Controls.Add(this.BrightnessControl);
            this.groupBoxColouring.Controls.Add(this.lblBrightness);
            this.groupBoxColouring.Controls.Add(this.lblSaturation);
            this.groupBoxColouring.Controls.Add(this.SaturationControl);
            this.groupBoxColouring.Controls.Add(this.lblContrast);
            this.groupBoxColouring.Controls.Add(this.ContrastControl);
            this.groupBoxColouring.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxColouring.Location = new System.Drawing.Point(48, 261);
            this.groupBoxColouring.Name = "groupBoxColouring";
            this.groupBoxColouring.Size = new System.Drawing.Size(166, 227);
            this.groupBoxColouring.TabIndex = 25;
            this.groupBoxColouring.TabStop = false;
            this.groupBoxColouring.Text = "Colouring";
            // 
            // radialFilterRemove
            // 
            this.radialFilterRemove.AutoSize = true;
            this.radialFilterRemove.Location = new System.Drawing.Point(18, 175);
            this.radialFilterRemove.Name = "radialFilterRemove";
            this.radialFilterRemove.Size = new System.Drawing.Size(112, 30);
            this.radialFilterRemove.TabIndex = 4;
            this.radialFilterRemove.TabStop = true;
            this.radialFilterRemove.Text = "No Filter";
            this.radialFilterRemove.UseVisualStyleBackColor = true;
            this.radialFilterRemove.CheckedChanged += new System.EventHandler(this.radialFilterRemove_CheckedChanged);
            // 
            // FishyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxImageCtrl);
            this.Controls.Add(this.groupBoxOrientation);
            this.Controls.Add(this.groupBoxColouring);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ImgDisplay);
            this.Controls.Add(this.CloseBttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FishyEdit";
            this.Text = "FishyNote";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FishyEdit_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FishyEdit_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FishyEdit_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).EndInit();
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.groupBoxOrientation.ResumeLayout(false);
            this.groupBoxImageCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContrastControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessControl)).EndInit();
            this.groupBoxColouring.ResumeLayout(false);
            this.groupBoxColouring.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Button LoadBttn;
        private System.Windows.Forms.Button SaveBttn;
        private System.Windows.Forms.Button NextImgBttn;
        private System.Windows.Forms.Button PrevImgBttn;
        private System.Windows.Forms.Button FlipYBttn;
        private System.Windows.Forms.Button FlipXBttn;
        private System.Windows.Forms.Button Rot90Bttn;
        private System.Windows.Forms.PictureBox ImgDisplay;
        private System.Windows.Forms.Button ACRot90Bttn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ScaleBttn;
        private System.Windows.Forms.Button CropBttn;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.RadioButton radioFilter4;
        private System.Windows.Forms.RadioButton radioFilter3;
        private System.Windows.Forms.RadioButton radioFilter2;
        private System.Windows.Forms.RadioButton radioFilter1;
        private System.Windows.Forms.GroupBox groupBoxOrientation;
        private System.Windows.Forms.GroupBox groupBoxImageCtrl;
        private System.Windows.Forms.NumericUpDown ContrastControl;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.NumericUpDown SaturationControl;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.NumericUpDown BrightnessControl;
        private System.Windows.Forms.GroupBox groupBoxColouring;
        private System.Windows.Forms.RadioButton radialFilterRemove;
    }
}