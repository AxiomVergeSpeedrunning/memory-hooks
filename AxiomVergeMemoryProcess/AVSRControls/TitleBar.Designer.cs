namespace AVSRControls
{
    partial class TitleBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleBarMenu = new System.Windows.Forms.MenuStrip();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleLabel = new System.Windows.Forms.Label();
            this.TitleBarMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleBarMenu
            // 
            this.TitleBarMenu.BackColor = System.Drawing.Color.Transparent;
            this.TitleBarMenu.Font = new System.Drawing.Font("Joystix Monospace", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseMenuItem,
            this.MinimizeMenuItem});
            this.TitleBarMenu.Location = new System.Drawing.Point(0, 0);
            this.TitleBarMenu.Name = "TitleBarMenu";
            this.TitleBarMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TitleBarMenu.Size = new System.Drawing.Size(200, 24);
            this.TitleBarMenu.TabIndex = 57;
            this.TitleBarMenu.Text = "menuStrip1";
            this.TitleBarMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBarMenu_MouseDown);
            this.TitleBarMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBarMenu_MouseMove);
            this.TitleBarMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBarMenu_MouseUp);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.ForeColor = System.Drawing.Color.LightCoral;
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(29, 20);
            this.CloseMenuItem.Text = "X";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // MinimizeMenuItem
            // 
            this.MinimizeMenuItem.ForeColor = System.Drawing.Color.LightCoral;
            this.MinimizeMenuItem.Name = "MinimizeMenuItem";
            this.MinimizeMenuItem.Size = new System.Drawing.Size(29, 20);
            this.MinimizeMenuItem.Text = "-";
            this.MinimizeMenuItem.Click += new System.EventHandler(this.MinimizeMenuItem_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Good Times Rg", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.titleLabel.Location = new System.Drawing.Point(10, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(42, 13);
            this.titleLabel.TabIndex = 58;
            this.titleLabel.Text = "Title";
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.titleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // TitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.TitleBarMenu);
            this.Name = "TitleBar";
            this.Size = new System.Drawing.Size(200, 24);
            this.Load += new System.EventHandler(this.TitleBar_Load);
            this.TitleBarMenu.ResumeLayout(false);
            this.TitleBarMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TitleBarMenu;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MinimizeMenuItem;
        private System.Windows.Forms.Label titleLabel;
    }
}
