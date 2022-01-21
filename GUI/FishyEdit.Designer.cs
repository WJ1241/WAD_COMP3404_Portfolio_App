
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
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseBttn
            // 
            this.CloseBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBttn.Font = new System.Drawing.Font("Calibri", 18F);
            this.CloseBttn.Location = new System.Drawing.Point(513, 15);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(55, 54);
            this.CloseBttn.TabIndex = 1;
            this.CloseBttn.Text = "X";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // LoadBttn
            // 
            this.LoadBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadBttn.Location = new System.Drawing.Point(93, 375);
            this.LoadBttn.Margin = new System.Windows.Forms.Padding(6);
            this.LoadBttn.Name = "LoadBttn";
            this.LoadBttn.Size = new System.Drawing.Size(400, 60);
            this.LoadBttn.TabIndex = 3;
            this.LoadBttn.Text = "Load Image";
            this.LoadBttn.UseVisualStyleBackColor = true;
            this.LoadBttn.Click += new System.EventHandler(this.LoadBttn_Click);
            // 
            // SaveBttn
            // 
            this.SaveBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBttn.Location = new System.Drawing.Point(93, 447);
            this.SaveBttn.Margin = new System.Windows.Forms.Padding(6);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(400, 60);
            this.SaveBttn.TabIndex = 4;
            this.SaveBttn.Text = "Save Image";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // NextImgBttn
            // 
            this.NextImgBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextImgBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextImgBttn.Location = new System.Drawing.Point(393, 807);
            this.NextImgBttn.Margin = new System.Windows.Forms.Padding(6);
            this.NextImgBttn.Name = "NextImgBttn";
            this.NextImgBttn.Size = new System.Drawing.Size(100, 50);
            this.NextImgBttn.TabIndex = 5;
            this.NextImgBttn.Text = "Next ->";
            this.NextImgBttn.UseVisualStyleBackColor = true;
            this.NextImgBttn.Click += new System.EventHandler(this.NextImgBttn_Click);
            // 
            // PrevImgBttn
            // 
            this.PrevImgBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrevImgBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevImgBttn.Location = new System.Drawing.Point(93, 807);
            this.PrevImgBttn.Margin = new System.Windows.Forms.Padding(6);
            this.PrevImgBttn.Name = "PrevImgBttn";
            this.PrevImgBttn.Size = new System.Drawing.Size(100, 50);
            this.PrevImgBttn.TabIndex = 5;
            this.PrevImgBttn.Text = "<- Prev";
            this.PrevImgBttn.UseVisualStyleBackColor = true;
            this.PrevImgBttn.Click += new System.EventHandler(this.PrevImgBttn_Click);
            // 
            // FlipYBttn
            // 
            this.FlipYBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlipYBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipYBttn.Location = new System.Drawing.Point(93, 591);
            this.FlipYBttn.Margin = new System.Windows.Forms.Padding(6);
            this.FlipYBttn.Name = "FlipYBttn";
            this.FlipYBttn.Size = new System.Drawing.Size(400, 60);
            this.FlipYBttn.TabIndex = 6;
            this.FlipYBttn.Text = "Flip Y";
            this.FlipYBttn.UseVisualStyleBackColor = true;
            this.FlipYBttn.Click += new System.EventHandler(this.FlipYBttn_Click);
            // 
            // FlipXBttn
            // 
            this.FlipXBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlipXBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipXBttn.Location = new System.Drawing.Point(93, 519);
            this.FlipXBttn.Margin = new System.Windows.Forms.Padding(6);
            this.FlipXBttn.Name = "FlipXBttn";
            this.FlipXBttn.Size = new System.Drawing.Size(400, 60);
            this.FlipXBttn.TabIndex = 7;
            this.FlipXBttn.Text = "Flip X";
            this.FlipXBttn.UseVisualStyleBackColor = true;
            this.FlipXBttn.Click += new System.EventHandler(this.FlipXBttn_Click);
            // 
            // Rot90Bttn
            // 
            this.Rot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rot90Bttn.Location = new System.Drawing.Point(93, 663);
            this.Rot90Bttn.Margin = new System.Windows.Forms.Padding(6);
            this.Rot90Bttn.Name = "Rot90Bttn";
            this.Rot90Bttn.Size = new System.Drawing.Size(400, 60);
            this.Rot90Bttn.TabIndex = 8;
            this.Rot90Bttn.Text = "Rotate 90 Degrees Clockwise";
            this.Rot90Bttn.UseVisualStyleBackColor = true;
            this.Rot90Bttn.Click += new System.EventHandler(this.Rot90Bttn_Click);
            // 
            // ImgDisplay
            // 
            this.ImgDisplay.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ImgDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImgDisplay.Location = new System.Drawing.Point(93, 74);
            this.ImgDisplay.Name = "ImgDisplay";
            this.ImgDisplay.Size = new System.Drawing.Size(400, 280);
            this.ImgDisplay.TabIndex = 9;
            this.ImgDisplay.TabStop = false;
            // 
            // ACRot90Bttn
            // 
            this.ACRot90Bttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ACRot90Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACRot90Bttn.Location = new System.Drawing.Point(93, 735);
            this.ACRot90Bttn.Margin = new System.Windows.Forms.Padding(6);
            this.ACRot90Bttn.Name = "ACRot90Bttn";
            this.ACRot90Bttn.Size = new System.Drawing.Size(400, 60);
            this.ACRot90Bttn.TabIndex = 10;
            this.ACRot90Bttn.Text = "Rotate 90 Degrees AntiClockwise";
            this.ACRot90Bttn.UseVisualStyleBackColor = true;
            this.ACRot90Bttn.Click += new System.EventHandler(this.ACRot90Bttn_Click);
            // 
            // FishyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(586, 880);
            this.ControlBox = false;
            this.Controls.Add(this.ACRot90Bttn);
            this.Controls.Add(this.ImgDisplay);
            this.Controls.Add(this.Rot90Bttn);
            this.Controls.Add(this.FlipXBttn);
            this.Controls.Add(this.FlipYBttn);
            this.Controls.Add(this.PrevImgBttn);
            this.Controls.Add(this.NextImgBttn);
            this.Controls.Add(this.SaveBttn);
            this.Controls.Add(this.LoadBttn);
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
            this.ResumeLayout(false);

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
    }
}