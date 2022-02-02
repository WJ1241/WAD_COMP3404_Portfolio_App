
namespace GUI
{
    partial class Home
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
            this.LoadBttn = new System.Windows.Forms.Button();
            this.ImgDisplay = new System.Windows.Forms.PictureBox();
            this.NextBttn = new System.Windows.Forms.Button();
            this.BackBttn = new System.Windows.Forms.Button();
            this.EditBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadBttn
            // 
            this.LoadBttn.Location = new System.Drawing.Point(250, 167);
            this.LoadBttn.Margin = new System.Windows.Forms.Padding(2);
            this.LoadBttn.Name = "LoadBttn";
            this.LoadBttn.Size = new System.Drawing.Size(71, 29);
            this.LoadBttn.TabIndex = 0;
            this.LoadBttn.Text = "Load";
            this.LoadBttn.UseVisualStyleBackColor = true;
            this.LoadBttn.Click += new System.EventHandler(this.LoadBttn_Click);
            // 
            // ImgDisplay
            // 
            this.ImgDisplay.Location = new System.Drawing.Point(91, 13);
            this.ImgDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.ImgDisplay.Name = "ImgDisplay";
            this.ImgDisplay.Size = new System.Drawing.Size(150, 150);
            this.ImgDisplay.TabIndex = 1;
            this.ImgDisplay.TabStop = false;
            // 
            // NextBttn
            // 
            this.NextBttn.Location = new System.Drawing.Point(86, 167);
            this.NextBttn.Margin = new System.Windows.Forms.Padding(2);
            this.NextBttn.Name = "NextBttn";
            this.NextBttn.Size = new System.Drawing.Size(71, 29);
            this.NextBttn.TabIndex = 2;
            this.NextBttn.Text = "Next";
            this.NextBttn.UseVisualStyleBackColor = true;
            this.NextBttn.Click += new System.EventHandler(this.NextBttn_Click);
            // 
            // BackBttn
            // 
            this.BackBttn.Location = new System.Drawing.Point(11, 167);
            this.BackBttn.Margin = new System.Windows.Forms.Padding(2);
            this.BackBttn.Name = "BackBttn";
            this.BackBttn.Size = new System.Drawing.Size(71, 29);
            this.BackBttn.TabIndex = 3;
            this.BackBttn.Text = "Back";
            this.BackBttn.UseVisualStyleBackColor = true;
            this.BackBttn.Click += new System.EventHandler(this.PrevImgBttn_Click);
            // 
            // EditBttn
            // 
            this.EditBttn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EditBttn.Location = new System.Drawing.Point(175, 167);
            this.EditBttn.Margin = new System.Windows.Forms.Padding(2);
            this.EditBttn.Name = "EditBttn";
            this.EditBttn.Size = new System.Drawing.Size(71, 29);
            this.EditBttn.TabIndex = 5;
            this.EditBttn.Text = "Edit";
            this.EditBttn.UseVisualStyleBackColor = true;
            this.EditBttn.Click += new System.EventHandler(this.EditBttn_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 221);
            this.Controls.Add(this.EditBttn);
            this.Controls.Add(this.BackBttn);
            this.Controls.Add(this.NextBttn);
            this.Controls.Add(this.ImgDisplay);
            this.Controls.Add(this.LoadBttn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadBttn;
        private System.Windows.Forms.PictureBox ImgDisplay;
        private System.Windows.Forms.Button NextBttn;
        private System.Windows.Forms.Button BackBttn;
        private System.Windows.Forms.Button EditBttn;
    }
}