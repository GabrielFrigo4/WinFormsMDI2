namespace MdiForm
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
            this.bCreateFormWin = new System.Windows.Forms.Button();
            this.mdiControl = new WinFormsMDI2.MdiControl();
            this.SuspendLayout();
            // 
            // bCreateFormWin
            // 
            this.bCreateFormWin.Location = new System.Drawing.Point(12, 12);
            this.bCreateFormWin.Name = "bCreateFormWin";
            this.bCreateFormWin.Size = new System.Drawing.Size(130, 29);
            this.bCreateFormWin.TabIndex = 1;
            this.bCreateFormWin.Text = "create form win";
            this.bCreateFormWin.UseVisualStyleBackColor = true;
            this.bCreateFormWin.Click += new System.EventHandler(this.bCreateFormWin_Click);
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
            this.mdiControl.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.mdiControl);
            this.Controls.Add(this.bCreateFormWin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button bCreateFormWin;
        private WinFormsMDI2.MdiControl mdiControl;
    }
}