namespace mohjang
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.opcja1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zAPISZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wCZYTAJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Nowa = new System.Windows.Forms.ToolStripMenuItem();
            this.nARZĘDZIAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOFNIJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wYMIESZAJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cZASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opcja1ToolStripMenuItem
            // 
            this.opcja1ToolStripMenuItem.Name = "opcja1ToolStripMenuItem";
            this.opcja1ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUToolStripMenuItem,
            this.nARZĘDZIAToolStripMenuItem,
            this.cZASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zAPISZToolStripMenuItem,
            this.wCZYTAJToolStripMenuItem,
            this.Nowa});
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.mENUToolStripMenuItem.Text = "MENU";
            // 
            // zAPISZToolStripMenuItem
            // 
            this.zAPISZToolStripMenuItem.Name = "zAPISZToolStripMenuItem";
            this.zAPISZToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zAPISZToolStripMenuItem.Text = "ZAPISZ";
            // 
            // wCZYTAJToolStripMenuItem
            // 
            this.wCZYTAJToolStripMenuItem.Name = "wCZYTAJToolStripMenuItem";
            this.wCZYTAJToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wCZYTAJToolStripMenuItem.Text = "WCZYTAJ";
            // 
            // Nowa
            // 
            this.Nowa.Name = "Nowa";
            this.Nowa.Size = new System.Drawing.Size(180, 22);
            this.Nowa.Text = "NOWA";
            // 
            // nARZĘDZIAToolStripMenuItem
            // 
            this.nARZĘDZIAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOFNIJToolStripMenuItem,
            this.wYMIESZAJToolStripMenuItem});
            this.nARZĘDZIAToolStripMenuItem.Name = "nARZĘDZIAToolStripMenuItem";
            this.nARZĘDZIAToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.nARZĘDZIAToolStripMenuItem.Text = "NARZĘDZIA";
            // 
            // cOFNIJToolStripMenuItem
            // 
            this.cOFNIJToolStripMenuItem.Name = "cOFNIJToolStripMenuItem";
            this.cOFNIJToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cOFNIJToolStripMenuItem.Text = "COFNIJ";
            // 
            // wYMIESZAJToolStripMenuItem
            // 
            this.wYMIESZAJToolStripMenuItem.Name = "wYMIESZAJToolStripMenuItem";
            this.wYMIESZAJToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.wYMIESZAJToolStripMenuItem.Text = "WYMIESZAJ";
            // 
            // cZASToolStripMenuItem
            // 
            this.cZASToolStripMenuItem.Name = "cZASToolStripMenuItem";
            this.cZASToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "CZAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "KAMIENIE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mahjong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem opcja1ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nARZĘDZIAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cZASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zAPISZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wCZYTAJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Nowa;
        private System.Windows.Forms.ToolStripMenuItem cOFNIJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wYMIESZAJToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

