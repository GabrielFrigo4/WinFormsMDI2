
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxIco = new System.Windows.Forms.PictureBox();
            this.bMin = new System.Windows.Forms.Button();
            this.bMax = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelFloor = new System.Windows.Forms.Panel();
            this.panelLeftFloor = new System.Windows.Forms.Panel();
            this.panelRightFloor = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIco)).BeginInit();
            this.panelFloor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelTop.Controls.Add(this.pictureBoxIco);
            this.panelTop.Controls.Add(this.bMin);
            this.panelTop.Controls.Add(this.bMax);
            this.panelTop.Controls.Add(this.bExit);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 32);
            this.panelTop.TabIndex = 0;
            this.panelTop.DoubleClick += new System.EventHandler(this.panelTop_DoubleClick);
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // pictureBoxIco
            // 
            this.pictureBoxIco.Image = Properties.Resources.Arquivo;
            this.pictureBoxIco.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxIco.Name = "pictureBoxIco";
            this.pictureBoxIco.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxIco.TabIndex = 1;
            this.pictureBoxIco.TabStop = false;
            // 
            // bMin
            // 
            this.bMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bMin.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bMin.Location = new System.Drawing.Point(462, 0);
            this.bMin.Name = "bMin";
            this.bMin.Size = new System.Drawing.Size(46, 32);
            this.bMin.TabIndex = 0;
            this.bMin.TabStop = false;
            this.bMin.Text = "__";
            this.bMin.UseVisualStyleBackColor = true;
            this.bMin.Click += new System.EventHandler(this.bMin_Click);
            this.bMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bMin_MouseDown);
            this.bMin.MouseEnter += new System.EventHandler(this.bMin_MouseEnter);
            this.bMin.MouseLeave += new System.EventHandler(this.bMin_MouseLeave);
            // 
            // bMax
            // 
            this.bMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bMax.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bMax.Location = new System.Drawing.Point(508, 0);
            this.bMax.Name = "bMax";
            this.bMax.Size = new System.Drawing.Size(46, 32);
            this.bMax.TabIndex = 0;
            this.bMax.TabStop = false;
            this.bMax.Text = "[//]";
            this.bMax.UseVisualStyleBackColor = true;
            this.bMax.Click += new System.EventHandler(this.bMax_Click);
            this.bMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bMax_MouseDown);
            this.bMax.MouseEnter += new System.EventHandler(this.bMax_MouseEnter);
            this.bMax.MouseLeave += new System.EventHandler(this.bMax_MouseLeave);
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bExit.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bExit.Location = new System.Drawing.Point(554, 0);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(46, 32);
            this.bExit.TabIndex = 0;
            this.bExit.TabStop = false;
            this.bExit.Text = "X";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            this.bExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bExit_MouseDown);
            this.bExit.MouseEnter += new System.EventHandler(this.bExit_MouseEnter);
            this.bExit.MouseLeave += new System.EventHandler(this.bExit_MouseLeave);
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
            // panelFloor
            // 
            this.panelFloor.BackColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.panelLeft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 32);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(5, 363);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLeft_MouseDown);
            this.panelLeft.MouseEnter += new System.EventHandler(this.panelLeft_MouseEnter);
            this.panelLeft.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLeft_MouseMove);
            this.panelLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelLeft_MouseUp);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(595, 32);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(5, 363);
            this.panelRight.TabIndex = 0;
            this.panelRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRight_MouseDown);
            this.panelRight.MouseEnter += new System.EventHandler(this.panelRight_MouseEnter);
            this.panelRight.MouseLeave += new System.EventHandler(this.panelAll_MouseLeave);
            this.panelRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelRight_MouseMove);
            this.panelRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelRight_MouseUp);
            // 
            // MdiWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelFloor);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MdiWin";
            this.Size = new System.Drawing.Size(600, 400);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MdiWin_MouseDown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIco)).EndInit();
            this.panelFloor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button bMin;
        private System.Windows.Forms.Button bMax;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Panel panelFloor;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelRightFloor;
        private System.Windows.Forms.Panel panelLeftFloor;
        private System.Windows.Forms.PictureBox pictureBoxIco;
    }
}
