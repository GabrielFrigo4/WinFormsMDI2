namespace SwitchTheme
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mdiControl = new WinFormsMDI2.MdiControl();
            this.bCreateWin = new System.Windows.Forms.Button();
            this.bSwitchTheme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mdiControl
            // 
            this.mdiControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mdiControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.mdiControl.Location = new System.Drawing.Point(12, 47);
            this.mdiControl.Name = "mdiControl";
            this.mdiControl.RemoveScreenFlickering = true;
            this.mdiControl.Size = new System.Drawing.Size(858, 494);
            this.mdiControl.TabIndex = 0;
            // 
            // bCreateWin
            // 
            this.bCreateWin.Location = new System.Drawing.Point(12, 12);
            this.bCreateWin.Name = "bCreateWin";
            this.bCreateWin.Size = new System.Drawing.Size(94, 29);
            this.bCreateWin.TabIndex = 1;
            this.bCreateWin.Text = "create win";
            this.bCreateWin.UseVisualStyleBackColor = true;
            this.bCreateWin.Click += new System.EventHandler(this.bCreateWin_Click);
            // 
            // bSwitchTheme
            // 
            this.bSwitchTheme.Location = new System.Drawing.Point(112, 12);
            this.bSwitchTheme.Name = "bSwitchTheme";
            this.bSwitchTheme.Size = new System.Drawing.Size(108, 29);
            this.bSwitchTheme.TabIndex = 2;
            this.bSwitchTheme.Text = "switch theme";
            this.bSwitchTheme.UseVisualStyleBackColor = true;
            this.bSwitchTheme.Click += new System.EventHandler(this.bSwitchTheme_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.bSwitchTheme);
            this.Controls.Add(this.bCreateWin);
            this.Controls.Add(this.mdiControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormsMDI2.MdiControl mdiControl;
        private Button bCreateWin;
        private Button bSwitchTheme;
    }
}