﻿
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
            this.radialFilterRemove = new System.Windows.Forms.RadioButton();
            this.radioFilter4 = new System.Windows.Forms.RadioButton();
            this.radioFilter3 = new System.Windows.Forms.RadioButton();
            this.radioFilter2 = new System.Windows.Forms.RadioButton();
            this.radioFilter1 = new System.Windows.Forms.RadioButton();
            this.groupBoxOrientation = new System.Windows.Forms.GroupBox();
            this.groupBoxImageCtrl = new System.Windows.Forms.GroupBox();
            this.lblContrast = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.groupBoxColouring = new System.Windows.Forms.GroupBox();
            this.SaturationControl = new System.Windows.Forms.TrackBar();
            this.ContrastControl = new System.Windows.Forms.TrackBar();
            this.BrightnessControl = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).BeginInit();
            this.groupBoxFilters.SuspendLayout();
            this.groupBoxOrientation.SuspendLayout();
            this.groupBoxImageCtrl.SuspendLayout();
            this.groupBoxColouring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessControl)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseBttn
            // 
            this.CloseBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBttn.Font = new System.Drawing.Font("Calibri", 20F);
            this.CloseBttn.Location = new System.Drawing.Point(991, 15);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(48, 47);
            this.CloseBttn.TabIndex = 1;
            this.CloseBttn.Text = "X";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // LoadBttn
            // 
            this.LoadBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadBttn.Location = new System.Drawing.Point(39, 33);
            this.LoadBttn.Margin = new System.Windows.Forms.Padding(4);
            this.LoadBttn.Name = "LoadBttn";
            this.LoadBttn.Size = new System.Drawing.Size(133, 37);
            this.LoadBttn.TabIndex = 3;
            this.LoadBttn.Text = "Load Image";
            this.LoadBttn.UseVisualStyleBackColor = true;
            this.LoadBttn.Click += new System.EventHandler(this.LoadBttn_Click);
            // 
            // SaveBttn
            // 
            this.SaveBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBttn.Location = new System.Drawing.Point(39, 78);
            this.SaveBttn.Margin = new System.Windows.Forms.Padding(4);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(133, 37);
            this.SaveBttn.TabIndex = 4;
            this.SaveBttn.Text = "Save Image";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // NextImgBttn
            // 
            this.NextImgBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextImgBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextImgBttn.Location = new System.Drawing.Point(39, 162);
            this.NextImgBttn.Margin = new System.Windows.Forms.Padding(4);
            this.NextImgBttn.Name = "NextImgBttn";
            this.NextImgBttn.Size = new System.Drawing.Size(133, 33);
            this.NextImgBttn.TabIndex = 5;
            this.NextImgBttn.Text = "Next ->";
            this.NextImgBttn.UseVisualStyleBackColor = true;
            this.NextImgBttn.Click += new System.EventHandler(this.NextImgBttn_Click);
            // 
            // PrevImgBttn
            // 
            this.PrevImgBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrevImgBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevImgBttn.Location = new System.Drawing.Point(39, 122);
            this.PrevImgBttn.Margin = new System.Windows.Forms.Padding(4);
            this.PrevImgBttn.Name = "PrevImgBttn";
            this.PrevImgBttn.Size = new System.Drawing.Size(133, 33);
            this.PrevImgBttn.TabIndex = 5;
            this.PrevImgBttn.Text = "Prev";
            this.PrevImgBttn.UseVisualStyleBackColor = true;
            this.PrevImgBttn.Click += new System.EventHandler(this.PrevImgBttn_Click);
            // 
            // FlipYBttn
            // 
            this.FlipYBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlipYBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipYBttn.Location = new System.Drawing.Point(171, 38);
            this.FlipYBttn.Margin = new System.Windows.Forms.Padding(4);
            this.FlipYBttn.Name = "FlipYBttn";
            this.FlipYBttn.Size = new System.Drawing.Size(107, 37);
            this.FlipYBttn.TabIndex = 6;
            this.FlipYBttn.Text = "Flip Y";
            this.FlipYBttn.UseVisualStyleBackColor = true;
            this.FlipYBttn.Click += new System.EventHandler(this.FlipYBttn_Click);
            // 
            // FlipXBttn
            // 
            this.FlipXBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlipXBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipXBttn.Location = new System.Drawing.Point(56, 38);
            this.FlipXBttn.Margin = new System.Windows.Forms.Padding(4);
            this.FlipXBttn.Name = "FlipXBttn";
            this.FlipXBttn.Size = new System.Drawing.Size(107, 37);
            this.FlipXBttn.TabIndex = 7;
            this.FlipXBttn.Text = "Flip X";
            this.FlipXBttn.UseVisualStyleBackColor = true;
            this.FlipXBttn.Click += new System.EventHandler(this.FlipXBttn_Click);
            // 
            // Rot90Bttn
            // 
            this.Rot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rot90Bttn.Location = new System.Drawing.Point(29, 82);
            this.Rot90Bttn.Margin = new System.Windows.Forms.Padding(4);
            this.Rot90Bttn.Name = "Rot90Bttn";
            this.Rot90Bttn.Size = new System.Drawing.Size(133, 37);
            this.Rot90Bttn.TabIndex = 8;
            this.Rot90Bttn.Text = "Rotate 90*";
            this.Rot90Bttn.UseVisualStyleBackColor = true;
            this.Rot90Bttn.Click += new System.EventHandler(this.Rot90Bttn_Click);
            // 
            // ImgDisplay
            // 
            this.ImgDisplay.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ImgDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImgDisplay.Location = new System.Drawing.Point(64, 46);
            this.ImgDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImgDisplay.Name = "ImgDisplay";
            this.ImgDisplay.Size = new System.Drawing.Size(533, 246);
            this.ImgDisplay.TabIndex = 9;
            this.ImgDisplay.TabStop = false;
            // 
            // ACRot90Bttn
            // 
            this.ACRot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ACRot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACRot90Bttn.Location = new System.Drawing.Point(171, 82);
            this.ACRot90Bttn.Margin = new System.Windows.Forms.Padding(4);
            this.ACRot90Bttn.Name = "ACRot90Bttn";
            this.ACRot90Bttn.Size = new System.Drawing.Size(133, 37);
            this.ACRot90Bttn.TabIndex = 10;
            this.ACRot90Bttn.Text = "Rotate -90*";
            this.ACRot90Bttn.UseVisualStyleBackColor = true;
            this.ACRot90Bttn.Click += new System.EventHandler(this.ACRot90Bttn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 359);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 22);
            this.textBox1.TabIndex = 11;
            // 
            // ScaleBttn
            // 
            this.ScaleBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ScaleBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScaleBttn.Location = new System.Drawing.Point(29, 127);
            this.ScaleBttn.Margin = new System.Windows.Forms.Padding(4);
            this.ScaleBttn.Name = "ScaleBttn";
            this.ScaleBttn.Size = new System.Drawing.Size(133, 37);
            this.ScaleBttn.TabIndex = 16;
            this.ScaleBttn.Text = "Scale";
            this.ScaleBttn.UseVisualStyleBackColor = true;
            this.ScaleBttn.Click += new System.EventHandler(this.ScaleBttn_Click);
            // 
            // CropBttn
            // 
            this.CropBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CropBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropBttn.Location = new System.Drawing.Point(171, 127);
            this.CropBttn.Margin = new System.Windows.Forms.Padding(4);
            this.CropBttn.Name = "CropBttn";
            this.CropBttn.Size = new System.Drawing.Size(133, 37);
            this.CropBttn.TabIndex = 17;
            this.CropBttn.Text = "Crop";
            this.CropBttn.UseVisualStyleBackColor = true;
            this.CropBttn.Click += new System.EventHandler(this.CropBttn_Click);
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.radialFilterRemove);
            this.groupBoxFilters.Controls.Add(this.radioFilter4);
            this.groupBoxFilters.Controls.Add(this.radioFilter3);
            this.groupBoxFilters.Controls.Add(this.radioFilter2);
            this.groupBoxFilters.Controls.Add(this.radioFilter1);
            this.groupBoxFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxFilters.Location = new System.Drawing.Point(823, 321);
            this.groupBoxFilters.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxFilters.Size = new System.Drawing.Size(175, 279);
            this.groupBoxFilters.TabIndex = 24;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            // 
            // radialFilterRemove
            // 
            this.radialFilterRemove.AutoSize = true;
            this.radialFilterRemove.Location = new System.Drawing.Point(24, 215);
            this.radialFilterRemove.Margin = new System.Windows.Forms.Padding(4);
            this.radialFilterRemove.Name = "radialFilterRemove";
            this.radialFilterRemove.Size = new System.Drawing.Size(138, 35);
            this.radialFilterRemove.TabIndex = 4;
            this.radialFilterRemove.TabStop = true;
            this.radialFilterRemove.Text = "No Filter";
            this.radialFilterRemove.UseVisualStyleBackColor = true;
            this.radialFilterRemove.CheckedChanged += new System.EventHandler(this.radialFilterRemove_CheckedChanged);
            // 
            // radioFilter4
            // 
            this.radioFilter4.AutoSize = true;
            this.radioFilter4.Location = new System.Drawing.Point(24, 171);
            this.radioFilter4.Margin = new System.Windows.Forms.Padding(4);
            this.radioFilter4.Name = "radioFilter4";
            this.radioFilter4.Size = new System.Drawing.Size(118, 35);
            this.radioFilter4.TabIndex = 3;
            this.radioFilter4.TabStop = true;
            this.radioFilter4.Text = "Filter 4";
            this.radioFilter4.UseVisualStyleBackColor = true;
            this.radioFilter4.CheckedChanged += new System.EventHandler(this.radioFilter4_CheckedChanged);
            // 
            // radioFilter3
            // 
            this.radioFilter3.AutoSize = true;
            this.radioFilter3.Location = new System.Drawing.Point(24, 127);
            this.radioFilter3.Margin = new System.Windows.Forms.Padding(4);
            this.radioFilter3.Name = "radioFilter3";
            this.radioFilter3.Size = new System.Drawing.Size(118, 35);
            this.radioFilter3.TabIndex = 2;
            this.radioFilter3.TabStop = true;
            this.radioFilter3.Text = "Filter 3";
            this.radioFilter3.UseVisualStyleBackColor = true;
            this.radioFilter3.CheckedChanged += new System.EventHandler(this.radioFilter3_CheckedChanged);
            // 
            // radioFilter2
            // 
            this.radioFilter2.AutoSize = true;
            this.radioFilter2.Location = new System.Drawing.Point(24, 82);
            this.radioFilter2.Margin = new System.Windows.Forms.Padding(4);
            this.radioFilter2.Name = "radioFilter2";
            this.radioFilter2.Size = new System.Drawing.Size(118, 35);
            this.radioFilter2.TabIndex = 1;
            this.radioFilter2.TabStop = true;
            this.radioFilter2.Text = "Filter 2";
            this.radioFilter2.UseVisualStyleBackColor = true;
            this.radioFilter2.CheckedChanged += new System.EventHandler(this.radioFilter2_CheckedChanged);
            // 
            // radioFilter1
            // 
            this.radioFilter1.AutoSize = true;
            this.radioFilter1.Location = new System.Drawing.Point(24, 38);
            this.radioFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.radioFilter1.Name = "radioFilter1";
            this.radioFilter1.Size = new System.Drawing.Size(118, 35);
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
            this.groupBoxOrientation.Location = new System.Drawing.Point(388, 321);
            this.groupBoxOrientation.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxOrientation.Name = "groupBoxOrientation";
            this.groupBoxOrientation.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxOrientation.Size = new System.Drawing.Size(333, 177);
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
            this.groupBoxImageCtrl.Location = new System.Drawing.Point(731, 75);
            this.groupBoxImageCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxImageCtrl.Name = "groupBoxImageCtrl";
            this.groupBoxImageCtrl.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxImageCtrl.Size = new System.Drawing.Size(221, 217);
            this.groupBoxImageCtrl.TabIndex = 27;
            this.groupBoxImageCtrl.TabStop = false;
            this.groupBoxImageCtrl.Text = "Image Control";
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblContrast.Location = new System.Drawing.Point(56, 122);
            this.lblContrast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(86, 25);
            this.lblContrast.TabIndex = 22;
            this.lblContrast.Text = "Contrast";
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSaturation.Location = new System.Drawing.Point(59, 208);
            this.lblSaturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(101, 25);
            this.lblSaturation.TabIndex = 23;
            this.lblSaturation.Text = "Saturation";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBrightness.Location = new System.Drawing.Point(56, 38);
            this.lblBrightness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(104, 25);
            this.lblBrightness.TabIndex = 21;
            this.lblBrightness.Text = "Brightness";
            // 
            // groupBoxColouring
            // 
            this.groupBoxColouring.Controls.Add(this.SaturationControl);
            this.groupBoxColouring.Controls.Add(this.ContrastControl);
            this.groupBoxColouring.Controls.Add(this.BrightnessControl);
            this.groupBoxColouring.Controls.Add(this.lblBrightness);
            this.groupBoxColouring.Controls.Add(this.lblSaturation);
            this.groupBoxColouring.Controls.Add(this.lblContrast);
            this.groupBoxColouring.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxColouring.Location = new System.Drawing.Point(64, 321);
            this.groupBoxColouring.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxColouring.Name = "groupBoxColouring";
            this.groupBoxColouring.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxColouring.Size = new System.Drawing.Size(221, 292);
            this.groupBoxColouring.TabIndex = 25;
            this.groupBoxColouring.TabStop = false;
            this.groupBoxColouring.Text = "Colouring";
            // 
            // SaturationControl
            // 
            this.SaturationControl.Location = new System.Drawing.Point(53, 236);
            this.SaturationControl.Name = "SaturationControl";
            this.SaturationControl.Size = new System.Drawing.Size(104, 56);
            this.SaturationControl.TabIndex = 28;
            this.SaturationControl.Scroll += new System.EventHandler(this.SaturationControl_ValueChanged);
            // 
            // ContrastControl
            // 
            this.ContrastControl.Location = new System.Drawing.Point(53, 150);
            this.ContrastControl.Name = "ContrastControl";
            this.ContrastControl.Size = new System.Drawing.Size(104, 56);
            this.ContrastControl.TabIndex = 28;
            this.ContrastControl.Scroll += new System.EventHandler(this.ContrastControl_ValueChanged);
            // 
            // BrightnessControl
            // 
            this.BrightnessControl.Location = new System.Drawing.Point(56, 63);
            this.BrightnessControl.Name = "BrightnessControl";
            this.BrightnessControl.Size = new System.Drawing.Size(104, 56);
            this.BrightnessControl.TabIndex = 28;
            this.BrightnessControl.Scroll += new System.EventHandler(this.BrightnessControl_ValueChanged);
            // 
            // FishyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 615);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxImageCtrl);
            this.Controls.Add(this.groupBoxOrientation);
            this.Controls.Add(this.groupBoxColouring);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ImgDisplay);
            this.Controls.Add(this.CloseBttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.groupBoxColouring.ResumeLayout(false);
            this.groupBoxColouring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessControl)).EndInit();
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
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.GroupBox groupBoxColouring;
        private System.Windows.Forms.RadioButton radialFilterRemove;
        private System.Windows.Forms.TrackBar BrightnessControl;
        private System.Windows.Forms.TrackBar ContrastControl;
        private System.Windows.Forms.TrackBar SaturationControl;
    }
}