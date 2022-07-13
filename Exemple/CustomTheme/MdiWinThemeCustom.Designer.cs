
namespace CustomTheme
{
    partial class MdiWinThemeCustom
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
            this.bNormalMax = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.DimGray;
            this.panelMain.Controls.Add(this.bNormalMax);
            this.panelMain.Controls.Add(this.bClose);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(360, 25);
            this.panelMain.TabIndex = 0;
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseDown);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            this.panelMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseUp);
            // 
            // bNormalMax
            // 
            this.bNormalMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bNormalMax.BackColor = System.Drawing.Color.Orange;
            this.bNormalMax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bNormalMax.Location = new System.Drawing.Point(311, 3);
            this.bNormalMax.Name = "bNormalMax";
            this.bNormalMax.Size = new System.Drawing.Size(20, 20);
            this.bNormalMax.TabIndex = 1;
            this.bNormalMax.UseVisualStyleBackColor = false;
            this.bNormalMax.Click += new System.EventHandler(this.bNormalMax_Click);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.BackColor = System.Drawing.Color.Red;
            this.bClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bClose.Location = new System.Drawing.Point(337, 3);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(20, 20);
            this.bClose.TabIndex = 0;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // MdiWinThemeCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.panelMain);
            this.Name = "MdiWinThemeCustom";
            this.Size = new System.Drawing.Size(360, 234);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MdiWinThemeCustom_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MdiWin_MouseDown);
            this.Resize += new System.EventHandler(this.MdiWinThemeCustom_Resize);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private Button bClose;
        private Button bNormalMax;
    }
}
