
namespace WinFormsMDI2_Test
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
            this.createMDI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mdiControl
            // 
            this.mdiControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mdiControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.mdiControl.Location = new System.Drawing.Point(12, 46);
            this.mdiControl.Name = "mdiControl";
            this.mdiControl.RemoveScreenFlickering = false;
            this.mdiControl.Size = new System.Drawing.Size(1158, 695);
            this.mdiControl.TabIndex = 0;
            // 
            // createMDI
            // 
            this.createMDI.Location = new System.Drawing.Point(12, 12);
            this.createMDI.Name = "createMDI";
            this.createMDI.Size = new System.Drawing.Size(104, 29);
            this.createMDI.TabIndex = 1;
            this.createMDI.Text = "create mdi";
            this.createMDI.UseVisualStyleBackColor = true;
            this.createMDI.Click += new System.EventHandler(this.createMDI_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.createMDI);
            this.Controls.Add(this.mdiControl);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormsMDI2.MdiControl mdiControl;
        private System.Windows.Forms.Button createMDI;
    }
}

