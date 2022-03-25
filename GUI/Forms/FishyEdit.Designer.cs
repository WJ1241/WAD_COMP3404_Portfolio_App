
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
            this.GroupBoxFilters = new System.Windows.Forms.GroupBox();
            this.RadioFilter4 = new System.Windows.Forms.RadioButton();
            this.RadioFilter3 = new System.Windows.Forms.RadioButton();
            this.RadioFilter2 = new System.Windows.Forms.RadioButton();
            this.RadioFilter1 = new System.Windows.Forms.RadioButton();
            this.groupBoxOrientation = new System.Windows.Forms.GroupBox();
            this.groupBoxImageCtrl = new System.Windows.Forms.GroupBox();
            this.ResetBttn = new System.Windows.Forms.Button();
            this.lblContrast = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.groupBoxColouring = new System.Windows.Forms.GroupBox();
            this.SaturationVal = new System.Windows.Forms.Label();
            this.ContrastVal = new System.Windows.Forms.Label();
            this.BrightnessVal = new System.Windows.Forms.Label();
            this.SaturationControl = new System.Windows.Forms.TrackBar();
            this.ContrastControl = new System.Windows.Forms.TrackBar();
            this.BrightnessControl = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblScale = new System.Windows.Forms.Label();
            this.ScaleNumBox = new System.Windows.Forms.NumericUpDown();
            this.CropBttn = new System.Windows.Forms.Button();
            this.HelpBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).BeginInit();
            this.GroupBoxFilters.SuspendLayout();
            this.groupBoxOrientation.SuspendLayout();
            this.groupBoxImageCtrl.SuspendLayout();
            this.groupBoxColouring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseBttn
            // 
            this.CloseBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBttn.Font = new System.Drawing.Font("Calibri", 20F);
            this.CloseBttn.Location = new System.Drawing.Point(820, 10);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(48, 47);
            this.CloseBttn.TabIndex = 1;
            this.CloseBttn.Text = "X";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // SaveBttn
            // 
            this.SaveBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBttn.Location = new System.Drawing.Point(45, 98);
            this.SaveBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(133, 37);
            this.SaveBttn.TabIndex = 4;
            this.SaveBttn.Text = "Save Image";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // VFlipBttn
            // 
            this.VFlipBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VFlipBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VFlipBttn.Location = new System.Drawing.Point(171, 38);
            this.VFlipBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VFlipBttn.Name = "VFlipBttn";
            this.VFlipBttn.Size = new System.Drawing.Size(107, 37);
            this.VFlipBttn.TabIndex = 6;
            this.VFlipBttn.Text = "Ver Flip";
            this.VFlipBttn.UseVisualStyleBackColor = true;
            this.VFlipBttn.Click += new System.EventHandler(this.VFlipBttn_Click);
            // 
            // HFlipBttn
            // 
            this.HFlipBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HFlipBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HFlipBttn.Location = new System.Drawing.Point(56, 38);
            this.HFlipBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HFlipBttn.Name = "HFlipBttn";
            this.HFlipBttn.Size = new System.Drawing.Size(107, 37);
            this.HFlipBttn.TabIndex = 7;
            this.HFlipBttn.Text = "Hor Flip";
            this.HFlipBttn.UseVisualStyleBackColor = true;
            this.HFlipBttn.Click += new System.EventHandler(this.HFlipBttn_Click);
            // 
            // Rot90Bttn
            // 
            this.Rot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rot90Bttn.Location = new System.Drawing.Point(171, 84);
            this.Rot90Bttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.ImgDisplay.Size = new System.Drawing.Size(363, 246);
            this.ImgDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImgDisplay.TabIndex = 9;
            this.ImgDisplay.TabStop = false;
            // 
            // ACRot90Bttn
            // 
            this.ACRot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ACRot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACRot90Bttn.Location = new System.Drawing.Point(29, 84);
            this.ACRot90Bttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ACRot90Bttn.Name = "ACRot90Bttn";
            this.ACRot90Bttn.Size = new System.Drawing.Size(133, 37);
            this.ACRot90Bttn.TabIndex = 10;
            this.ACRot90Bttn.Text = "Rotate -90*";
            this.ACRot90Bttn.UseVisualStyleBackColor = true;
            this.ACRot90Bttn.Click += new System.EventHandler(this.ACRot90Bttn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 358);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1, 22);
            this.textBox1.TabIndex = 11;
            // 
            // GroupBoxFilters
            // 
            this.GroupBoxFilters.Controls.Add(this.RadioFilter4);
            this.GroupBoxFilters.Controls.Add(this.RadioFilter3);
            this.GroupBoxFilters.Controls.Add(this.RadioFilter2);
            this.GroupBoxFilters.Controls.Add(this.RadioFilter1);
            this.GroupBoxFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.GroupBoxFilters.Location = new System.Drawing.Point(636, 311);
            this.GroupBoxFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBoxFilters.Name = "GroupBoxFilters";
            this.GroupBoxFilters.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBoxFilters.Size = new System.Drawing.Size(175, 288);
            this.GroupBoxFilters.TabIndex = 24;
            this.GroupBoxFilters.TabStop = false;
            this.GroupBoxFilters.Text = "Filters";
            // 
            // RadioFilter4
            // 
            this.RadioFilter4.AutoSize = true;
            this.RadioFilter4.Location = new System.Drawing.Point(28, 196);
            this.RadioFilter4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioFilter4.Name = "RadioFilter4";
            this.RadioFilter4.Size = new System.Drawing.Size(94, 35);
            this.RadioFilter4.TabIndex = 3;
            this.RadioFilter4.TabStop = true;
            this.RadioFilter4.Text = "Grey";
            this.RadioFilter4.UseVisualStyleBackColor = true;
            this.RadioFilter4.CheckedChanged += new System.EventHandler(this.RadioFilter4_CheckedChanged);
            // 
            // RadioFilter3
            // 
            this.RadioFilter3.AutoSize = true;
            this.RadioFilter3.Location = new System.Drawing.Point(28, 151);
            this.RadioFilter3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioFilter3.Name = "RadioFilter3";
            this.RadioFilter3.Size = new System.Drawing.Size(113, 35);
            this.RadioFilter3.TabIndex = 2;
            this.RadioFilter3.TabStop = true;
            this.RadioFilter3.Text = "Purple";
            this.RadioFilter3.UseVisualStyleBackColor = true;
            this.RadioFilter3.CheckedChanged += new System.EventHandler(this.RadioFilter3_CheckedChanged);
            // 
            // RadioFilter2
            // 
            this.RadioFilter2.AutoSize = true;
            this.RadioFilter2.Location = new System.Drawing.Point(28, 107);
            this.RadioFilter2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioFilter2.Name = "RadioFilter2";
            this.RadioFilter2.Size = new System.Drawing.Size(85, 35);
            this.RadioFilter2.TabIndex = 1;
            this.RadioFilter2.TabStop = true;
            this.RadioFilter2.Text = "Red";
            this.RadioFilter2.UseVisualStyleBackColor = true;
            this.RadioFilter2.CheckedChanged += new System.EventHandler(this.RadioFilter2_CheckedChanged);
            // 
            // RadioFilter1
            // 
            this.RadioFilter1.AutoSize = true;
            this.RadioFilter1.Location = new System.Drawing.Point(28, 63);
            this.RadioFilter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioFilter1.Name = "RadioFilter1";
            this.RadioFilter1.Size = new System.Drawing.Size(89, 35);
            this.RadioFilter1.TabIndex = 0;
            this.RadioFilter1.TabStop = true;
            this.RadioFilter1.Text = "Blue";
            this.RadioFilter1.UseVisualStyleBackColor = true;
            this.RadioFilter1.CheckedChanged += new System.EventHandler(this.RadioFilter1_CheckedChanged);
            // 
            // groupBoxOrientation
            // 
            this.groupBoxOrientation.Controls.Add(this.HFlipBttn);
            this.groupBoxOrientation.Controls.Add(this.VFlipBttn);
            this.groupBoxOrientation.Controls.Add(this.Rot90Bttn);
            this.groupBoxOrientation.Controls.Add(this.ACRot90Bttn);
            this.groupBoxOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxOrientation.Location = new System.Drawing.Point(293, 311);
            this.groupBoxOrientation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOrientation.Name = "groupBoxOrientation";
            this.groupBoxOrientation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOrientation.Size = new System.Drawing.Size(333, 143);
            this.groupBoxOrientation.TabIndex = 26;
            this.groupBoxOrientation.TabStop = false;
            this.groupBoxOrientation.Text = "Orientation";
            // 
            // groupBoxImageCtrl
            // 
            this.groupBoxImageCtrl.Controls.Add(this.ResetBttn);
            this.groupBoxImageCtrl.Controls.Add(this.SaveBttn);
            this.groupBoxImageCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxImageCtrl.Location = new System.Drawing.Point(519, 46);
            this.groupBoxImageCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxImageCtrl.Name = "groupBoxImageCtrl";
            this.groupBoxImageCtrl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxImageCtrl.Size = new System.Drawing.Size(221, 165);
            this.groupBoxImageCtrl.TabIndex = 27;
            this.groupBoxImageCtrl.TabStop = false;
            this.groupBoxImageCtrl.Text = "Image Control";
            // 
            // ResetBttn
            // 
            this.ResetBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBttn.Location = new System.Drawing.Point(45, 53);
            this.ResetBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResetBttn.Name = "ResetBttn";
            this.ResetBttn.Size = new System.Drawing.Size(133, 37);
            this.ResetBttn.TabIndex = 5;
            this.ResetBttn.Text = "Reset Image";
            this.ResetBttn.UseVisualStyleBackColor = true;
            this.ResetBttn.Click += new System.EventHandler(this.ResetBttn_Click);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblContrast.Location = new System.Drawing.Point(24, 119);
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
            this.lblSaturation.Location = new System.Drawing.Point(24, 204);
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
            this.lblBrightness.Location = new System.Drawing.Point(24, 38);
            this.lblBrightness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(104, 25);
            this.lblBrightness.TabIndex = 21;
            this.lblBrightness.Text = "Brightness";
            // 
            // groupBoxColouring
            // 
            this.groupBoxColouring.Controls.Add(this.SaturationVal);
            this.groupBoxColouring.Controls.Add(this.ContrastVal);
            this.groupBoxColouring.Controls.Add(this.BrightnessVal);
            this.groupBoxColouring.Controls.Add(this.SaturationControl);
            this.groupBoxColouring.Controls.Add(this.ContrastControl);
            this.groupBoxColouring.Controls.Add(this.BrightnessControl);
            this.groupBoxColouring.Controls.Add(this.lblBrightness);
            this.groupBoxColouring.Controls.Add(this.lblSaturation);
            this.groupBoxColouring.Controls.Add(this.lblContrast);
            this.groupBoxColouring.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBoxColouring.Location = new System.Drawing.Point(64, 311);
            this.groupBoxColouring.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxColouring.Name = "groupBoxColouring";
            this.groupBoxColouring.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxColouring.Size = new System.Drawing.Size(221, 288);
            this.groupBoxColouring.TabIndex = 25;
            this.groupBoxColouring.TabStop = false;
            this.groupBoxColouring.Text = "Colouring";
            // 
            // SaturationVal
            // 
            this.SaturationVal.AutoSize = true;
            this.SaturationVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SaturationVal.Location = new System.Drawing.Point(145, 204);
            this.SaturationVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SaturationVal.Name = "SaturationVal";
            this.SaturationVal.Size = new System.Drawing.Size(41, 25);
            this.SaturationVal.TabIndex = 31;
            this.SaturationVal.Text = "0%";
            // 
            // ContrastVal
            // 
            this.ContrastVal.AutoSize = true;
            this.ContrastVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ContrastVal.Location = new System.Drawing.Point(145, 119);
            this.ContrastVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ContrastVal.Name = "ContrastVal";
            this.ContrastVal.Size = new System.Drawing.Size(41, 25);
            this.ContrastVal.TabIndex = 30;
            this.ContrastVal.Text = "0%";
            // 
            // BrightnessVal
            // 
            this.BrightnessVal.AutoSize = true;
            this.BrightnessVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BrightnessVal.Location = new System.Drawing.Point(145, 38);
            this.BrightnessVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BrightnessVal.Name = "BrightnessVal";
            this.BrightnessVal.Size = new System.Drawing.Size(41, 25);
            this.BrightnessVal.TabIndex = 29;
            this.BrightnessVal.Text = "0%";
            this.BrightnessVal.Click += new System.EventHandler(this.label2_Click);
            // 
            // SaturationControl
            // 
            this.SaturationControl.Location = new System.Drawing.Point(56, 226);
            this.SaturationControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaturationControl.Maximum = 100;
            this.SaturationControl.Minimum = -100;
            this.SaturationControl.Name = "SaturationControl";
            this.SaturationControl.Size = new System.Drawing.Size(109, 56);
            this.SaturationControl.TabIndex = 28;
            this.SaturationControl.Scroll += new System.EventHandler(this.SaturationControl_ValueChanged);
            // 
            // ContrastControl
            // 
            this.ContrastControl.Location = new System.Drawing.Point(56, 142);
            this.ContrastControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ContrastControl.Maximum = 100;
            this.ContrastControl.Minimum = -100;
            this.ContrastControl.Name = "ContrastControl";
            this.ContrastControl.Size = new System.Drawing.Size(112, 56);
            this.ContrastControl.TabIndex = 28;
            this.ContrastControl.Scroll += new System.EventHandler(this.ContrastControl_ValueChanged);
            // 
            // BrightnessControl
            // 
            this.BrightnessControl.Location = new System.Drawing.Point(56, 63);
            this.BrightnessControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrightnessControl.Maximum = 100;
            this.BrightnessControl.Minimum = -100;
            this.BrightnessControl.Name = "BrightnessControl";
            this.BrightnessControl.Size = new System.Drawing.Size(109, 56);
            this.BrightnessControl.TabIndex = 28;
            this.BrightnessControl.Scroll += new System.EventHandler(this.BrightnessControl_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Confirm);
            this.groupBox1.Controls.Add(this.LblScale);
            this.groupBox1.Controls.Add(this.ScaleNumBox);
            this.groupBox1.Controls.Add(this.CropBttn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBox1.Location = new System.Drawing.Point(293, 501);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(333, 100);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size";
            // 
            // LblScale
            // 
            this.LblScale.AutoSize = true;
            this.LblScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LblScale.Location = new System.Drawing.Point(25, 33);
            this.LblScale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblScale.Name = "LblScale";
            this.LblScale.Size = new System.Drawing.Size(62, 25);
            this.LblScale.TabIndex = 29;
            this.LblScale.Text = "Scale";
            // 
            // ScaleNumBox
            // 
            this.ScaleNumBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ScaleNumBox.DecimalPlaces = 1;
            this.ScaleNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScaleNumBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleNumBox.Location = new System.Drawing.Point(29, 57);
            this.ScaleNumBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScaleNumBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ScaleNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleNumBox.Name = "ScaleNumBox";
            this.ScaleNumBox.Size = new System.Drawing.Size(133, 40);
            this.ScaleNumBox.TabIndex = 29;
            this.ScaleNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ScaleNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScaleNumBox.ValueChanged += new System.EventHandler(this.ScaleNumBox_ValueChanged);
            // 
            // CropBttn
            // 
            this.CropBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CropBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CropBttn.Location = new System.Drawing.Point(171, 21);
            this.CropBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CropBttn.Name = "CropBttn";
            this.CropBttn.Size = new System.Drawing.Size(133, 37);
            this.CropBttn.TabIndex = 17;
            this.CropBttn.Text = "Crop";
            this.CropBttn.UseVisualStyleBackColor = true;
            this.CropBttn.Click += new System.EventHandler(this.CropBttn_Click_1);
            // 
            // HelpBttn
            // 
            this.HelpBttn.BackColor = System.Drawing.Color.DodgerBlue;
            this.HelpBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HelpBttn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.HelpBttn.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.HelpBttn.ForeColor = System.Drawing.SystemColors.Control;
            this.HelpBttn.Location = new System.Drawing.Point(820, 63);
            this.HelpBttn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HelpBttn.Name = "HelpBttn";
            this.HelpBttn.Size = new System.Drawing.Size(48, 47);
            this.HelpBttn.TabIndex = 28;
            this.HelpBttn.Text = "i";
            this.HelpBttn.UseVisualStyleBackColor = false;
            this.HelpBttn.Click += new System.EventHandler(this.HelpBttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 31);
            this.label1.TabIndex = 30;
            this.label1.Text = "Image displayed is to scale";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(171, 57);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(133, 40);
            this.Confirm.TabIndex = 30;
            this.Confirm.Text = "ConfirmBtn";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // FishyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(877, 614);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HelpBttn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxImageCtrl);
            this.Controls.Add(this.groupBoxOrientation);
            this.Controls.Add(this.groupBoxColouring);
            this.Controls.Add(this.GroupBoxFilters);
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
            this.GroupBoxFilters.ResumeLayout(false);
            this.GroupBoxFilters.PerformLayout();
            this.groupBoxOrientation.ResumeLayout(false);
            this.groupBoxImageCtrl.ResumeLayout(false);
            this.groupBoxColouring.ResumeLayout(false);
            this.groupBoxColouring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNumBox)).EndInit();
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
        private System.Windows.Forms.TrackBar BrightnessControl;
        private System.Windows.Forms.TrackBar ContrastControl;
        private System.Windows.Forms.TrackBar SaturationControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CropBttn;
        private System.Windows.Forms.Button ResetBttn;
        private System.Windows.Forms.Button HelpBttn;
        private System.Windows.Forms.Label LblScale;
        private System.Windows.Forms.NumericUpDown ScaleNumBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BrightnessVal;
        private System.Windows.Forms.Label SaturationVal;
        private System.Windows.Forms.Label ContrastVal;
        private System.Windows.Forms.Button Confirm;
    }
}