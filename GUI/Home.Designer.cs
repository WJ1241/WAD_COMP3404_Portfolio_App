
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.LoadBttn = new System.Windows.Forms.Button();
            this.ImgDisplay = new System.Windows.Forms.PictureBox();
            this.NextBttn = new System.Windows.Forms.Button();
            this.BackBttn = new System.Windows.Forms.Button();
            this.EditBttn = new System.Windows.Forms.Button();
            this.lbl_homeLable = new System.Windows.Forms.Label();
            this._notifHome = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadBttn
            // 
            this.LoadBttn.Location = new System.Drawing.Point(250, 190);
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
            this.ImgDisplay.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ImgDisplay.Location = new System.Drawing.Point(91, 36);
            this.ImgDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.ImgDisplay.Name = "ImgDisplay";
            this.ImgDisplay.Size = new System.Drawing.Size(150, 150);
            this.ImgDisplay.TabIndex = 1;
            this.ImgDisplay.TabStop = false;
            // 
            // NextBttn
            // 
            this.NextBttn.Location = new System.Drawing.Point(86, 190);
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
            this.BackBttn.Location = new System.Drawing.Point(11, 190);
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
            this.EditBttn.Location = new System.Drawing.Point(175, 190);
            this.EditBttn.Margin = new System.Windows.Forms.Padding(2);
            this.EditBttn.Name = "EditBttn";
            this.EditBttn.Size = new System.Drawing.Size(71, 29);
            this.EditBttn.TabIndex = 5;
            this.EditBttn.Text = "Edit";
            this.EditBttn.UseVisualStyleBackColor = true;
            this.EditBttn.Click += new System.EventHandler(this.EditBttn_Click);
            // 
            // lbl_homeLable
            // 
            this.lbl_homeLable.AutoSize = true;
            this.lbl_homeLable.Location = new System.Drawing.Point(8, 9);
            this.lbl_homeLable.Name = "lbl_homeLable";
            this.lbl_homeLable.Size = new System.Drawing.Size(128, 13);
            this.lbl_homeLable.TabIndex = 6;
            this.lbl_homeLable.Text = "FishyHomeEditThing v1.2";
            // 
            // _notifHome
            // 
            this._notifHome.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._notifHome.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifHome.Icon")));
            this._notifHome.Text = "FishyHome";
            this._notifHome.Visible = true;
            this._notifHome.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(332, 227);
            this.Controls.Add(this.lbl_homeLable);
            this.Controls.Add(this.EditBttn);
            this.Controls.Add(this.BackBttn);
            this.Controls.Add(this.NextBttn);
            this.Controls.Add(this.ImgDisplay);
            this.Controls.Add(this.LoadBttn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
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
    }
}