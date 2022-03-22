
namespace GUI
{
    partial class FishyHome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FishyHome));
            this.LoadBttn = new System.Windows.Forms.Button();
            this.ImgDisplay = new System.Windows.Forms.PictureBox();
            this.NextBttn = new System.Windows.Forms.Button();
            this.BackBttn = new System.Windows.Forms.Button();
            this.EditBttn = new System.Windows.Forms.Button();
            this.lbl_homeLable = new System.Windows.Forms.Label();
            this._notifHome = new System.Windows.Forms.NotifyIcon(this.components);
            this.CloseBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadBttn
            // 
            this.LoadBttn.Location = new System.Drawing.Point(458, 351);
            this.LoadBttn.Margin = new System.Windows.Forms.Padding(4);
            this.LoadBttn.Name = "LoadBttn";
            this.LoadBttn.Size = new System.Drawing.Size(130, 54);
            this.LoadBttn.TabIndex = 0;
            this.LoadBttn.Text = "Load";
            this.LoadBttn.UseVisualStyleBackColor = true;
            this.LoadBttn.Click += new System.EventHandler(this.LoadBttn_Click);
            // 
            // ImgDisplay
            // 
            this.ImgDisplay.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ImgDisplay.Location = new System.Drawing.Point(167, 66);
            this.ImgDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.ImgDisplay.Name = "ImgDisplay";
            this.ImgDisplay.Size = new System.Drawing.Size(275, 277);
            this.ImgDisplay.TabIndex = 1;
            this.ImgDisplay.TabStop = false;
            // 
            // NextBttn
            // 
            this.NextBttn.Location = new System.Drawing.Point(158, 351);
            this.NextBttn.Margin = new System.Windows.Forms.Padding(4);
            this.NextBttn.Name = "NextBttn";
            this.NextBttn.Size = new System.Drawing.Size(130, 54);
            this.NextBttn.TabIndex = 2;
            this.NextBttn.Text = "Next";
            this.NextBttn.UseVisualStyleBackColor = true;
            this.NextBttn.Click += new System.EventHandler(this.NextBttn_Click);
            // 
            // BackBttn
            // 
            this.BackBttn.Location = new System.Drawing.Point(20, 351);
            this.BackBttn.Margin = new System.Windows.Forms.Padding(4);
            this.BackBttn.Name = "BackBttn";
            this.BackBttn.Size = new System.Drawing.Size(130, 54);
            this.BackBttn.TabIndex = 3;
            this.BackBttn.Text = "Back";
            this.BackBttn.UseVisualStyleBackColor = true;
            this.BackBttn.Click += new System.EventHandler(this.PrevImgBttn_Click);
            // 
            // EditBttn
            // 
            this.EditBttn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EditBttn.Location = new System.Drawing.Point(321, 351);
            this.EditBttn.Margin = new System.Windows.Forms.Padding(4);
            this.EditBttn.Name = "EditBttn";
            this.EditBttn.Size = new System.Drawing.Size(130, 54);
            this.EditBttn.TabIndex = 5;
            this.EditBttn.Text = "Edit";
            this.EditBttn.UseVisualStyleBackColor = true;
            this.EditBttn.Click += new System.EventHandler(this.EditBttn_Click);
            // 
            // lbl_homeLable
            // 
            this.lbl_homeLable.AutoSize = true;
            this.lbl_homeLable.Location = new System.Drawing.Point(15, 17);
            this.lbl_homeLable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_homeLable.Name = "lbl_homeLable";
            this.lbl_homeLable.Size = new System.Drawing.Size(111, 25);
            this.lbl_homeLable.TabIndex = 6;
            this.lbl_homeLable.Text = "FishyHome";
            // 
            // _notifHome
            // 
            this._notifHome.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._notifHome.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifHome.Icon")));
            this._notifHome.Text = "FishyHome";
            this._notifHome.Visible = true;
            // 
            // CloseBttn
            // 
            this.CloseBttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBttn.Font = new System.Drawing.Font("Calibri", 20F);
            this.CloseBttn.Location = new System.Drawing.Point(530, 15);
            this.CloseBttn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(66, 70);
            this.CloseBttn.TabIndex = 7;
            this.CloseBttn.Text = "X";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // FishyHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(609, 419);
            this.Controls.Add(this.CloseBttn);
            this.Controls.Add(this.lbl_homeLable);
            this.Controls.Add(this.EditBttn);
            this.Controls.Add(this.BackBttn);
            this.Controls.Add(this.NextBttn);
            this.Controls.Add(this.ImgDisplay);
            this.Controls.Add(this.LoadBttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FishyHome";
            this.Text = "FishyHome";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FishyHome_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FishyHome_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FishyHome_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadBttn;
        private System.Windows.Forms.PictureBox ImgDisplay;
        private System.Windows.Forms.Button NextBttn;
        private System.Windows.Forms.Button BackBttn;
        private System.Windows.Forms.Button EditBttn;
        private System.Windows.Forms.Label lbl_homeLable;
        private System.Windows.Forms.NotifyIcon _notifHome;
        private System.Windows.Forms.Button CloseBttn;
    }
}