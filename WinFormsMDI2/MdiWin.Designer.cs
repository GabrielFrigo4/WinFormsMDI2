
namespace WinFormsMDI2
{
    partial class MdiWin
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.bMin = new System.Windows.Forms.PictureBox();
            this.bMax = new System.Windows.Forms.PictureBox();
            this.bClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxIco = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelLeftTop = new System.Windows.Forms.Panel();
            this.panelFloor = new System.Windows.Forms.Panel();
            this.panelLeftFloor = new System.Windows.Forms.Panel();
            this.panelRightFloor = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelRightTop = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIco)).BeginInit();
            this.panelFloor.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelMain.Controls.Add(this.bMin);
            this.panelMain.Controls.Add(this.bMax);
            this.panelMain.Controls.Add(this.bClose);
            this.panelMain.Controls.Add(this.pictureBoxIco);
            this.panelMain.Controls.Add(this.labelTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(5, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(590, 32);
            this.panelMain.TabIndex = 0;
            this.panelMain.DoubleClick += new System.EventHandler(this.panelMain_DoubleClick);
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseDown);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            this.panelMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseUp);
            // 
            // bMin
            // 
            this.bMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMin.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bMin.Image = global::WinFormsMDI2.Properties.Resources.Minimize;
            this.bMin.Location = new System.Drawing.Point(452, 0);
            this.bMin.Name = "bMin";
            this.bMin.Size = new System.Drawing.Size(46, 32);
            this.bMin.TabIndex = 0;
            this.bMin.TabStop = false;
            this.bMin.Click += new System.EventHandler(this.bMin_Click);
            this.bMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bMin_MouseDown);
            this.bMin.MouseEnter += new System.EventHandler(this.bMin_MouseEnter);
            this.bMin.MouseLeave += new System.EventHandler(this.bMin_MouseLeave);
            // 
            // bMax
            // 
            this.bMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMax.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bMax.Image = global::WinFormsMDI2.Properties.Resources.Maximize;
            this.bMax.Location = new System.Drawing.Point(498, 0);
            this.bMax.Name = "bMax";
            this.bMax.Size = new System.Drawing.Size(46, 32);
            this.bMax.TabIndex = 0;
            this.bMax.TabStop = false;
            this.bMax.Click += new System.EventHandler(this.bMax_Click);
            this.bMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bMax_MouseDown);
            this.bMax.MouseEnter += new System.EventHandler(this.bMax_MouseEnter);
            this.bMax.MouseLeave += new System.EventHandler(this.bMax_MouseLeave);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bClose.Image = global::WinFormsMDI2.Properties.Resources.Close;
            this.bClose.Location = new System.Drawing.Point(544, 0);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(46, 32);
            this.bClose.TabIndex = 0;
            this.bClose.TabStop = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            this.bClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bClose_MouseDown);
            this.bClose.MouseEnter += new System.EventHandler(this.bClose_MouseEnter);
            this.bClose.MouseLeave += new System.EventHandler(this.bClose_MouseLeave);
            // 
            // pictureBoxIco
            // 
            this.pictureBoxIco.Image = global::WinFormsMDI2.Properties.Resources.File;
            this.pictureBoxIco.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxIco.Name = "pictureBoxIco";
            this.pictureBoxIco.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxIco.TabIndex = 1;
            this.pictureBoxIco.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(32, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(69, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "MdiWin";
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Size = new System.Drawing.Size(5, 5);
            this.panelLeftTop.TabIndex = 2;
            this.panelLeftTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLeftTop_MouseDown);
            this.panelLeftTop.MouseEnter += new System.EventHandler(this.panelLeftTop_MouseEnter);
            this.panelLeftTop.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelLeftTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLeftTop_MouseMove);
            this.panelLeftTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelLeftTop_MouseUp);
            // 
            // panelFloor
            // 
            this.panelFloor.BackColor = System.Drawing.Color.LightGray;
            this.panelFloor.Controls.Add(this.panelLeftFloor);
            this.panelFloor.Controls.Add(this.panelRightFloor);
            this.panelFloor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFloor.Location = new System.Drawing.Point(0, 395);
            this.panelFloor.Name = "panelFloor";
            this.panelFloor.Size = new System.Drawing.Size(600, 5);
            this.panelFloor.TabIndex = 0;
            this.panelFloor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelFloor_MouseDown);
            this.panelFloor.MouseEnter += new System.EventHandler(this.panelFloor_MouseEnter);
            this.panelFloor.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelFloor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelFloor_MouseMove);
            this.panelFloor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelFloor_MouseUp);
            // 
            // panelLeftFloor
            // 
            this.panelLeftFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeftFloor.Location = new System.Drawing.Point(0, 0);
            this.panelLeftFloor.Name = "panelLeftFloor";
            this.panelLeftFloor.Size = new System.Drawing.Size(5, 5);
            this.panelLeftFloor.TabIndex = 2;
            this.panelLeftFloor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLeftFloor_MouseDown);
            this.panelLeftFloor.MouseEnter += new System.EventHandler(this.panelLeftFloor_MouseEnter);
            this.panelLeftFloor.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelLeftFloor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLeftFloor_MouseMove);
            this.panelLeftFloor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelLeftFloor_MouseUp);
            // 
            // panelRightFloor
            // 
            this.panelRightFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRightFloor.Location = new System.Drawing.Point(595, 0);
            this.panelRightFloor.Name = "panelRightFloor";
            this.panelRightFloor.Size = new System.Drawing.Size(5, 5);
            this.panelRightFloor.TabIndex = 1;
            this.panelRightFloor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRightFloor_MouseDown);
            this.panelRightFloor.MouseEnter += new System.EventHandler(this.panelRightFloor_MouseEnter);
            this.panelRightFloor.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelRightFloor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelRightFloor_MouseMove);
            this.panelRightFloor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelRightFloor_MouseUp);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.LightGray;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(5, 390);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLeft_MouseDown);
            this.panelLeft.MouseEnter += new System.EventHandler(this.panelLeft_MouseEnter);
            this.panelLeft.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLeft_MouseMove);
            this.panelLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelLeft_MouseUp);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.LightGray;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(595, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(5, 390);
            this.panelRight.TabIndex = 0;
            this.panelRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRight_MouseDown);
            this.panelRight.MouseEnter += new System.EventHandler(this.panelRight_MouseEnter);
            this.panelRight.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelRight_MouseMove);
            this.panelRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelRight_MouseUp);
            // 
            // panelRightTop
            // 
            this.panelRightTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRightTop.Location = new System.Drawing.Point(595, 0);
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.Size = new System.Drawing.Size(5, 5);
            this.panelRightTop.TabIndex = 0;
            this.panelRightTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRightTop_MouseDown);
            this.panelRightTop.MouseEnter += new System.EventHandler(this.panelRightTop_MouseEnter);
            this.panelRightTop.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelRightTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelRightTop_MouseMove);
            this.panelRightTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelRightTop_MouseUp);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightGray;
            this.panelTop.Controls.Add(this.panelLeftTop);
            this.panelTop.Controls.Add(this.panelRightTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 5);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseEnter += new System.EventHandler(this.panelTop_MouseEnter);
            this.panelTop.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // MdiWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelFloor);
            this.DoubleBuffered = true;
            this.Name = "MdiWin";
            this.Size = new System.Drawing.Size(600, 400);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MdiWin_MouseDown);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIco)).EndInit();
            this.panelFloor.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox bMin;
        private System.Windows.Forms.PictureBox bMax;
        private System.Windows.Forms.PictureBox bClose;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFloor;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelRightFloor;
        private System.Windows.Forms.Panel panelLeftFloor;
        private System.Windows.Forms.PictureBox pictureBoxIco;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.Panel panelRightTop;
    }
}
