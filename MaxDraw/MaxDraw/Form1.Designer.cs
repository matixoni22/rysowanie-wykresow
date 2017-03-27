namespace MaxDraw
{
    partial class MaxDraw
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
            this.PanelG = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszWykresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Draw = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.max = new System.Windows.Forms.Button();
            this.szer_pol = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelG
            // 
            this.PanelG.BackColor = System.Drawing.Color.White;
            this.PanelG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelG.Location = new System.Drawing.Point(113, 27);
            this.PanelG.Name = "PanelG";
            this.PanelG.Size = new System.Drawing.Size(1100, 600);
            this.PanelG.TabIndex = 0;
            this.PanelG.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 469);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(94, 158);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ustawieniaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wczytajToolStripMenuItem,
            this.zapiszWykresToolStripMenuItem});
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.wczytajToolStripMenuItem.Text = "Wczytaj dane";
            this.wczytajToolStripMenuItem.Click += new System.EventHandler(this.wczytajToolStripMenuItem_Click);
            // 
            // zapiszWykresToolStripMenuItem
            // 
            this.zapiszWykresToolStripMenuItem.Name = "zapiszWykresToolStripMenuItem";
            this.zapiszWykresToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.zapiszWykresToolStripMenuItem.Text = "Zapisz wykres";
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(12, 47);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(93, 52);
            this.Draw.TabIndex = 3;
            this.Draw.Text = "Narysuj wykres";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(11, 105);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(95, 51);
            this.Clear.TabIndex = 4;
            this.Clear.Text = "Wyczyść";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // max
            // 
            this.max.Location = new System.Drawing.Point(12, 209);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(94, 52);
            this.max.TabIndex = 0;
            this.max.Text = "Wartość max";
            this.max.UseVisualStyleBackColor = true;
            this.max.Click += new System.EventHandler(this.button1_Click);
            // 
            // szer_pol
            // 
            this.szer_pol.Location = new System.Drawing.Point(12, 267);
            this.szer_pol.Name = "szer_pol";
            this.szer_pol.Size = new System.Drawing.Size(94, 49);
            this.szer_pol.TabIndex = 5;
            this.szer_pol.Text = "Szerokość połówkowa";
            this.szer_pol.UseVisualStyleBackColor = true;
            this.szer_pol.Click += new System.EventHandler(this.szer_pol_Click);
            // 
            // MaxDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 662);
            this.Controls.Add(this.szer_pol);
            this.Controls.Add(this.max);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.PanelG);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MaxDraw";
            this.Text = "MaxDraw";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelG;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszWykresToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button max;
        private System.Windows.Forms.Button szer_pol;
    }
}

