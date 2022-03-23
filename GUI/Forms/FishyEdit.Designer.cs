
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
            this.SaveBttn = new System.Windows.Forms.Button();
            this.VFlipBttn = new System.Windows.Forms.Button();
            this.HFlipBttn = new System.Windows.Forms.Button();
            this.Rot90Bttn = new System.Windows.Forms.Button();
            this.ImgDisplay = new System.Windows.Forms.PictureBox();
            this.ACRot90Bttn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ScaleBttn = new System.Windows.Forms.Button();
            this.CropBttn = new System.Windows.Forms.Button();
            this.GroupBoxFilters = new System.Windows.Forms.GroupBox();
            this.RadioFilterRemove = new System.Windows.Forms.RadioButton();
            this.RadioFilter4 = new System.Windows.Forms.RadioButton();
            this.RadioFilter3 = new System.Windows.Forms.RadioButton();
            this.RadioFilter2 = new System.Windows.Forms.RadioButton();
            this.RadioFilter1 = new System.Windows.Forms.RadioButton();
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
            this.GroupBoxFilters.SuspendLayout();
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
            this.CloseBttn.Location = new System.Drawing.Point(1160, 15);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(66, 70);
            this.CloseBttn.TabIndex = 1;
            this.CloseBttn.Text = "X";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // SaveBttn
            // 
            this.SaveBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBttn.Location = new System.Drawing.Point(62, 98);
            this.SaveBttn.Margin = new System.Windows.Forms.Padding(6);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(183, 56);
            this.SaveBttn.TabIndex = 4;
            this.SaveBttn.Text = "Save Image";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // VFlipBttn
            // 
            this.VFlipBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VFlipBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VFlipBttn.Location = new System.Drawing.Point(235, 57);
            this.VFlipBttn.Margin = new System.Windows.Forms.Padding(6);
            this.VFlipBttn.Name = "VFlipBttn";
            this.VFlipBttn.Size = new System.Drawing.Size(147, 56);
            this.VFlipBttn.TabIndex = 6;
            this.VFlipBttn.Text = "Ver Flip";
            this.VFlipBttn.UseVisualStyleBackColor = true;
            this.VFlipBttn.Click += new System.EventHandler(this.VFlipBttn_Click);
            // 
            // HFlipBttn
            // 
            this.HFlipBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HFlipBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HFlipBttn.Location = new System.Drawing.Point(77, 57);
            this.HFlipBttn.Margin = new System.Windows.Forms.Padding(6);
            this.HFlipBttn.Name = "HFlipBttn";
            this.HFlipBttn.Size = new System.Drawing.Size(147, 56);
            this.HFlipBttn.TabIndex = 7;
            this.HFlipBttn.Text = "Hor Flip";
            this.HFlipBttn.UseVisualStyleBackColor = true;
            this.HFlipBttn.Click += new System.EventHandler(this.HFlipBttn_Click);
            // 
            // Rot90Bttn
            // 
            this.Rot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rot90Bttn.Location = new System.Drawing.Point(235, 125);
            this.Rot90Bttn.Margin = new System.Windows.Forms.Padding(6);
            this.Rot90Bttn.Name = "Rot90Bttn";
            this.Rot90Bttn.Size = new System.Drawing.Size(183, 56);
            this.Rot90Bttn.TabIndex = 8;
            this.Rot90Bttn.Text = "Rotate 90*";
            this.Rot90Bttn.UseVisualStyleBackColor = true;
            this.Rot90Bttn.Click += new System.EventHandler(this.Rot90Bttn_Click);
            // 
            // ImgDisplay
            // 
            this.ImgDisplay.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ImgDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImgDisplay.Location = new System.Drawing.Point(88, 69);
            this.ImgDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ImgDisplay.Name = "ImgDisplay";
            this.ImgDisplay.Size = new System.Drawing.Size(499, 369);
            this.ImgDisplay.TabIndex = 9;
            this.ImgDisplay.TabStop = false;
            // 
            // ACRot90Bttn
            // 
            this.ACRot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ACRot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACRot90Bttn.Location = new System.Drawing.Point(40, 125);
            this.ACRot90Bttn.Margin = new System.Windows.Forms.Padding(6);
            this.ACRot90Bttn.Name = "ACRot90Bttn";
            this.ACRot90Bttn.Size = new System.Drawing.Size(183, 56);
            this.ACRot90Bttn.TabIndex = 10;
            this.ACRot90Bttn.Text = "Rotate -90*";
            this.ACRot90Bttn.UseVisualStyleBackColor = true;
            this.ACRot90Bttn.Click += new System.EventHandler(this.ACRot90Bttn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 538);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 29);
            this.textBox1.TabIndex = 11;
            // 
            // ScaleBttn
            // 
            this.ScaleBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ScaleBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScaleBttn.Location = new System.Drawing.Point(40, 190);
            this.ScaleBttn.Margin = new System.Windows.Forms.Padding(6);
            this.ScaleBttn.Name = "ScaleBttn";
            this.ScaleBttn.Size = new System.Drawing.Size(183, 56);
            this.ScaleBttn.TabIndex = 16;
            this.ScaleBttn.Text = "Scale";
            this.ScaleBttn.UseVisualStyleBackColor = true;
            this.ScaleBttn.Click += new System.EventHandler(this.ScaleBttn_Click);
            // 
            // CropBttn
            // 
            this.CropBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CropBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropBttn.Location = new System.Drawing.Point(235, 190);
            this.CropBttn.Margin = new System.Windows.Forms.Padding(6);
            this.CropBttn.Name = "CropBttn";
            this.CropBttn.Size = new System.Drawing.Size(183, 56);
            this.CropBttn.TabIndex = 17;
            this.CropBttn.Text = "Crop";
            this.CropBttn.UseVisualStyleBackColor = true;
            this.CropBttn.Click += new System.EventHandler(this.CropBttn_Click);
            // 
            // GroupBoxFilters
            // 
            this.GroupBoxFilters.Controls.Add(this.RadioFilterRemove);
            this.GroupBoxFilters.Controls.Add(this.RadioFilter4);
            this.GroupBoxFilters.Controls.Add(this.RadioFilter3);
            this.GroupBoxFilters.Controls.Add(this.RadioFilter2);
            this.GroupBoxFilters.Controls.Add(this.RadioFilter1);
            this.GroupBoxFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.GroupBoxFilters.Location = new System.Drawing.Point(985, 482);
            this.GroupBoxFilters.Margin = new System.Windows.Forms.Padding(6);
            this.GroupBoxFilters.Name = "GroupBoxFilters";
            this.GroupBoxFilters.Padding = new System.Windows.Forms.Padding(6);
            this.GroupBoxFilters.Size = new System.Drawing.Size(241, 418);
            this.GroupBoxFilters.TabIndex = 24;
            this.GroupBoxFilters.TabStop = false;
            this.GroupBoxFilters.Text = "Filters";
            // 
            // RadioFilterRemove
            // 
            this.RadioFilterRemove.AutoSize = true;
            this.RadioFilterRemove.Location = new System.Drawing.Point(33, 322);
            this.RadioFilterRemove.Margin = new System.Windows.Forms.Padding(6);
            this.RadioFilterRemove.Name = "RadioFilterRemove";
            this.RadioFilterRemove.Size = new System.Drawing.Size(189, 48);
            this.RadioFilterRemove.TabIndex = 4;
            this.RadioFilterRemove.TabStop = true;
            this.RadioFilterRemove.Text = "No Filter";
            this.RadioFilterRemove.UseVisualStyleBackColor = true;
            this.RadioFilterRemove.CheckedChanged += new System.EventHandler(this.RadioFilterRemove_CheckedChanged);
            // 
            // RadioFilter4
            // 
            this.RadioFilter4.AutoSize = true;
            this.RadioFilter4.Location = new System.Drawing.Point(33, 256);
            this.RadioFilter4.Margin = new System.Windows.Forms.Padding(6);
            this.RadioFilter4.Name = "RadioFilter4";
            this.RadioFilter4.Size = new System.Drawing.Size(162, 48);
            this.RadioFilter4.TabIndex = 3;
            this.RadioFilter4.TabStop = true;
            this.RadioFilter4.Text = "Filter 4";
            this.RadioFilter4.UseVisualStyleBackColor = true;
            this.RadioFilter4.CheckedChanged += new System.EventHandler(this.RadioFilter4_CheckedChanged);
            // 
            // RadioFilter3
            // 
            this.RadioFilter3.AutoSize = true;
            this.RadioFilter3.Location = new System.Drawing.Point(33, 190);
            this.RadioFilter3.Margin = new System.Windows.Forms.Padding(6);
            this.RadioFilter3.Name = "RadioFilter3";
            this.RadioFilter3.Size = new System.Drawing.Size(162, 48);
            this.RadioFilter3.TabIndex = 2;
            this.RadioFilter3.TabStop = true;
            this.RadioFilter3.Text = "Filter 3";
            this.RadioFilter3.UseVisualStyleBackColor = true;
            this.RadioFilter3.CheckedChanged += new System.EventHandler(this.RadioFilter3_CheckedChanged);
            // 
            // RadioFilter2
            // 
            this.RadioFilter2.AutoSize = true;
            this.RadioFilter2.Location = new System.Drawing.Point(33, 123);
            this.RadioFilter2.Margin = new System.Windows.Forms.Padding(6);
            this.RadioFilter2.Name = "RadioFilter2";
            this.RadioFilter2.Size = new System.Drawing.Size(162, 48);
            this.RadioFilter2.TabIndex = 1;
            this.RadioFilter2.TabStop = true;
            this.RadioFilter2.Text = "Filter 2";
            this.RadioFilter2.UseVisualStyleBackColor = true;
            this.RadioFilter2.CheckedChanged += new System.EventHandler(this.RadioFilter2_CheckedChanged);
            // 
            // RadioFilter1
            // 
            this.RadioFilter1.AutoSize = true;
            this.RadioFilter1.Location = new System.Drawing.Point(33, 57);
            this.RadioFilter1.Margin = new System.Windows.Forms.Padding(6);
            this.RadioFilter1.Name = "RadioFilter1";
            this.RadioFilter1.Size = new System.Drawing.Size(162, 48);
            this.RadioFilter1.TabIndex = 0;
            this.RadioFilter1.TabStop = true;
            this.RadioFilter1.Text = "Filter 1";
            this.RadioFilter1.UseVisualStyleBackColor = true;
            this.RadioFilter1.CheckedChanged += new System.EventHandler(this.RadioFilter1_CheckedChanged);
            // 
            // groupBoxOrientation
            // 
            this.groupBoxOrientation.Controls.Add(this.HFlipBttn);
            this.groupBoxOrientation.Controls.Add(this.VFlipBttn);
            this.groupBoxOrientation.Controls.Add(this.Rot90Bttn);
            this.groupBoxOrientation.Controls.Add(this.CropBttn);
            this.groupBoxOrientation.Controls.Add(this.ACRot90Bttn);
            this.groupBoxOrientation.Controls.Add(this.ScaleBttn);
            this.groupBoxOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxOrientation.Location = new System.Drawing.Point(457, 482);
            this.groupBoxOrientation.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxOrientation.Name = "groupBoxOrientation";
            this.groupBoxOrientation.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxOrientation.Size = new System.Drawing.Size(458, 266);
            this.groupBoxOrientation.TabIndex = 26;
            this.groupBoxOrientation.TabStop = false;
            this.groupBoxOrientation.Text = "Orientation";
            // 
            // groupBoxImageCtrl
            // 
            this.groupBoxImageCtrl.Controls.Add(this.SaveBttn);
            this.groupBoxImageCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxImageCtrl.Location = new System.Drawing.Point(791, 69);
            this.groupBoxImageCtrl.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxImageCtrl.Name = "groupBoxImageCtrl";
            this.groupBoxImageCtrl.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxImageCtrl.Size = new System.Drawing.Size(304, 204);
            this.groupBoxImageCtrl.TabIndex = 27;
            this.groupBoxImageCtrl.TabStop = false;
            this.groupBoxImageCtrl.Text = "Image Control";
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblContrast.Location = new System.Drawing.Point(77, 183);
            this.lblContrast.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(122, 32);
            this.lblContrast.TabIndex = 22;
            this.lblContrast.Text = "Contrast";
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSaturation.Location = new System.Drawing.Point(81, 312);
            this.lblSaturation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(146, 32);
            this.lblSaturation.TabIndex = 23;
            this.lblSaturation.Text = "Saturation";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBrightness.Location = new System.Drawing.Point(77, 57);
            this.lblBrightness.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(150, 32);
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
            this.groupBoxColouring.Location = new System.Drawing.Point(88, 482);
            this.groupBoxColouring.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxColouring.Name = "groupBoxColouring";
            this.groupBoxColouring.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxColouring.Size = new System.Drawing.Size(304, 413);
            this.groupBoxColouring.TabIndex = 25;
            this.groupBoxColouring.TabStop = false;
            this.groupBoxColouring.Text = "Colouring";
            // 
            // SaturationControl
            // 
            this.SaturationControl.Location = new System.Drawing.Point(73, 354);
            this.SaturationControl.Margin = new System.Windows.Forms.Padding(4);
            this.SaturationControl.Name = "SaturationControl";
            this.SaturationControl.Size = new System.Drawing.Size(143, 80);
            this.SaturationControl.TabIndex = 28;
            this.SaturationControl.Scroll += new System.EventHandler(this.SaturationControl_ValueChanged);
            // 
            // ContrastControl
            // 
            this.ContrastControl.Location = new System.Drawing.Point(73, 225);
            this.ContrastControl.Margin = new System.Windows.Forms.Padding(4);
            this.ContrastControl.Name = "ContrastControl";
            this.ContrastControl.Size = new System.Drawing.Size(143, 80);
            this.ContrastControl.TabIndex = 28;
            this.ContrastControl.Scroll += new System.EventHandler(this.ContrastControl_ValueChanged);
            // 
            // BrightnessControl
            // 
            this.BrightnessControl.Location = new System.Drawing.Point(77, 94);
            this.BrightnessControl.Margin = new System.Windows.Forms.Padding(4);
            this.BrightnessControl.Name = "BrightnessControl";
            this.BrightnessControl.Size = new System.Drawing.Size(143, 80);
            this.BrightnessControl.TabIndex = 28;
            this.BrightnessControl.Scroll += new System.EventHandler(this.BrightnessControl_ValueChanged);
            // 
            // FishyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1247, 922);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxImageCtrl);
            this.Controls.Add(this.groupBoxOrientation);
            this.Controls.Add(this.groupBoxColouring);
            this.Controls.Add(this.GroupBoxFilters);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ImgDisplay);
            this.Controls.Add(this.CloseBttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FishyEdit";
            this.Text = "FishyNote";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FishyEdit_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FishyEdit_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FishyEdit_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).EndInit();
            this.GroupBoxFilters.ResumeLayout(false);
            this.GroupBoxFilters.PerformLayout();
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
        private System.Windows.Forms.Button SaveBttn;
        private System.Windows.Forms.Button VFlipBttn;
        private System.Windows.Forms.Button HFlipBttn;
        private System.Windows.Forms.Button Rot90Bttn;
        private System.Windows.Forms.PictureBox ImgDisplay;
        private System.Windows.Forms.Button ACRot90Bttn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ScaleBttn;
        private System.Windows.Forms.Button CropBttn;
        private System.Windows.Forms.GroupBox GroupBoxFilters;
        private System.Windows.Forms.RadioButton RadioFilter4;
        private System.Windows.Forms.RadioButton RadioFilter3;
        private System.Windows.Forms.RadioButton RadioFilter2;
        private System.Windows.Forms.RadioButton RadioFilter1;
        private System.Windows.Forms.GroupBox groupBoxOrientation;
        private System.Windows.Forms.GroupBox groupBoxImageCtrl;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.GroupBox groupBoxColouring;
        private System.Windows.Forms.RadioButton RadioFilterRemove;
        private System.Windows.Forms.TrackBar BrightnessControl;
        private System.Windows.Forms.TrackBar ContrastControl;
        private System.Windows.Forms.TrackBar SaturationControl;
    }
}