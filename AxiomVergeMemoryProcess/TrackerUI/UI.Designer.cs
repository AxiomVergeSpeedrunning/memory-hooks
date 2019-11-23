﻿namespace TrackerUI
{
    partial class UI
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AreaItemsCompleted = new System.Windows.Forms.Panel();
            this.AreaMapCompleted = new System.Windows.Forms.Panel();
            this.AreaItemCount = new System.Windows.Forms.Label();
            this.CurrentAutoMapName = new System.Windows.Forms.Label();
            this.AreaScreenCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Connection = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ItemsCompleted = new System.Windows.Forms.Panel();
            this.MapCompleted = new System.Windows.Forms.Panel();
            this.RedGooDestroyed = new System.Windows.Forms.Label();
            this.ItemCount = new System.Windows.Forms.Label();
            this.ScreenCount = new System.Windows.Forms.Label();
            this.Difficulty = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BricksDestroyed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HitPoints = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.94024F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.05976F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 251);
            this.tableLayoutPanel2.TabIndex = 54;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::TrackerUI.Properties.Resources.frame2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.AreaItemCount);
            this.panel2.Controls.Add(this.CurrentAutoMapName);
            this.panel2.Controls.Add(this.AreaScreenCount);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 165);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 83);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.AreaItemsCompleted, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AreaMapCompleted, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(211, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(40, 20);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // AreaItemsCompleted
            // 
            this.AreaItemsCompleted.BackgroundImage = global::TrackerUI.Properties.Resources.itemsComplete;
            this.AreaItemsCompleted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AreaItemsCompleted.Location = new System.Drawing.Point(3, 3);
            this.AreaItemsCompleted.Name = "AreaItemsCompleted";
            this.AreaItemsCompleted.Size = new System.Drawing.Size(14, 14);
            this.AreaItemsCompleted.TabIndex = 0;
            this.AreaItemsCompleted.Visible = false;
            // 
            // AreaMapCompleted
            // 
            this.AreaMapCompleted.BackgroundImage = global::TrackerUI.Properties.Resources.mapComplete;
            this.AreaMapCompleted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AreaMapCompleted.Location = new System.Drawing.Point(23, 3);
            this.AreaMapCompleted.Name = "AreaMapCompleted";
            this.AreaMapCompleted.Size = new System.Drawing.Size(14, 14);
            this.AreaMapCompleted.TabIndex = 1;
            this.AreaMapCompleted.Visible = false;
            // 
            // AreaItemCount
            // 
            this.AreaItemCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AreaItemCount.BackColor = System.Drawing.Color.Transparent;
            this.AreaItemCount.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AreaItemCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.AreaItemCount.Location = new System.Drawing.Point(79, 44);
            this.AreaItemCount.Name = "AreaItemCount";
            this.AreaItemCount.Size = new System.Drawing.Size(45, 14);
            this.AreaItemCount.TabIndex = 54;
            this.AreaItemCount.Text = "null";
            this.AreaItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentAutoMapName
            // 
            this.CurrentAutoMapName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CurrentAutoMapName.BackColor = System.Drawing.Color.Transparent;
            this.CurrentAutoMapName.Font = new System.Drawing.Font("Good Times Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentAutoMapName.ForeColor = System.Drawing.Color.LightCoral;
            this.CurrentAutoMapName.Location = new System.Drawing.Point(64, 14);
            this.CurrentAutoMapName.Name = "CurrentAutoMapName";
            this.CurrentAutoMapName.Size = new System.Drawing.Size(144, 20);
            this.CurrentAutoMapName.TabIndex = 51;
            this.CurrentAutoMapName.Text = "AREA";
            this.CurrentAutoMapName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AreaScreenCount
            // 
            this.AreaScreenCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AreaScreenCount.BackColor = System.Drawing.Color.Transparent;
            this.AreaScreenCount.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AreaScreenCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.AreaScreenCount.Location = new System.Drawing.Point(160, 44);
            this.AreaScreenCount.Name = "AreaScreenCount";
            this.AreaScreenCount.Size = new System.Drawing.Size(45, 14);
            this.AreaScreenCount.TabIndex = 55;
            this.AreaScreenCount.Text = "null";
            this.AreaScreenCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(120, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 14);
            this.label10.TabIndex = 53;
            this.label10.Text = "Map%";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(31, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 14);
            this.label9.TabIndex = 52;
            this.label9.Text = "Item%";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::TrackerUI.Properties.Resources.frame;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.Connection);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.RedGooDestroyed);
            this.panel1.Controls.Add(this.ItemCount);
            this.panel1.Controls.Add(this.ScreenCount);
            this.panel1.Controls.Add(this.Difficulty);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.BricksDestroyed);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.HitPoints);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 156);
            this.panel1.TabIndex = 52;
            // 
            // Connection
            // 
            this.Connection.BackColor = System.Drawing.Color.Transparent;
            this.Connection.BackgroundImage = global::TrackerUI.Properties.Resources.Disconnected;
            this.Connection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Connection.Location = new System.Drawing.Point(22, 16);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(14, 14);
            this.Connection.TabIndex = 59;
            this.Connection.Click += new System.EventHandler(this.Connection_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Good Times Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightCoral;
            this.label6.Location = new System.Drawing.Point(64, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "AV Tracker";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ItemsCompleted, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.MapCompleted, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(211, 13);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(40, 20);
            this.tableLayoutPanel3.TabIndex = 57;
            // 
            // ItemsCompleted
            // 
            this.ItemsCompleted.BackgroundImage = global::TrackerUI.Properties.Resources.itemsComplete;
            this.ItemsCompleted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ItemsCompleted.Location = new System.Drawing.Point(3, 3);
            this.ItemsCompleted.Name = "ItemsCompleted";
            this.ItemsCompleted.Size = new System.Drawing.Size(14, 14);
            this.ItemsCompleted.TabIndex = 0;
            this.ItemsCompleted.Visible = false;
            // 
            // MapCompleted
            // 
            this.MapCompleted.BackgroundImage = global::TrackerUI.Properties.Resources.mapComplete;
            this.MapCompleted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MapCompleted.Location = new System.Drawing.Point(23, 3);
            this.MapCompleted.Name = "MapCompleted";
            this.MapCompleted.Size = new System.Drawing.Size(14, 14);
            this.MapCompleted.TabIndex = 1;
            this.MapCompleted.Visible = false;
            // 
            // RedGooDestroyed
            // 
            this.RedGooDestroyed.BackColor = System.Drawing.Color.Transparent;
            this.RedGooDestroyed.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedGooDestroyed.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RedGooDestroyed.Location = new System.Drawing.Point(169, 85);
            this.RedGooDestroyed.Name = "RedGooDestroyed";
            this.RedGooDestroyed.Size = new System.Drawing.Size(130, 14);
            this.RedGooDestroyed.TabIndex = 44;
            this.RedGooDestroyed.Text = "null";
            this.RedGooDestroyed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemCount
            // 
            this.ItemCount.BackColor = System.Drawing.Color.Transparent;
            this.ItemCount.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ItemCount.Location = new System.Drawing.Point(79, 57);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.Size = new System.Drawing.Size(45, 14);
            this.ItemCount.TabIndex = 45;
            this.ItemCount.Text = "null";
            this.ItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScreenCount
            // 
            this.ScreenCount.BackColor = System.Drawing.Color.Transparent;
            this.ScreenCount.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScreenCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ScreenCount.Location = new System.Drawing.Point(160, 57);
            this.ScreenCount.Name = "ScreenCount";
            this.ScreenCount.Size = new System.Drawing.Size(45, 14);
            this.ScreenCount.TabIndex = 46;
            this.ScreenCount.Text = "null";
            this.ScreenCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Difficulty
            // 
            this.Difficulty.BackColor = System.Drawing.Color.Transparent;
            this.Difficulty.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Difficulty.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Difficulty.Location = new System.Drawing.Point(175, 43);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(127, 14);
            this.Difficulty.TabIndex = 47;
            this.Difficulty.Text = "null";
            this.Difficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(31, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 14);
            this.label7.TabIndex = 43;
            this.label7.Text = "Game Difficulty:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BricksDestroyed
            // 
            this.BricksDestroyed.BackColor = System.Drawing.Color.Transparent;
            this.BricksDestroyed.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BricksDestroyed.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BricksDestroyed.Location = new System.Drawing.Point(160, 99);
            this.BricksDestroyed.Name = "BricksDestroyed";
            this.BricksDestroyed.Size = new System.Drawing.Size(139, 14);
            this.BricksDestroyed.TabIndex = 48;
            this.BricksDestroyed.Text = "null";
            this.BricksDestroyed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(31, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "Bubbles Popped:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(31, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 14);
            this.label5.TabIndex = 42;
            this.label5.Text = "HP:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(31, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 39;
            this.label2.Text = "Item%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HitPoints
            // 
            this.HitPoints.BackColor = System.Drawing.Color.Transparent;
            this.HitPoints.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HitPoints.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HitPoints.Location = new System.Drawing.Point(61, 71);
            this.HitPoints.Name = "HitPoints";
            this.HitPoints.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HitPoints.Size = new System.Drawing.Size(241, 14);
            this.HitPoints.TabIndex = 49;
            this.HitPoints.Text = "null";
            this.HitPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(120, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 40;
            this.label3.Text = "Map%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(31, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 14);
            this.label4.TabIndex = 41;
            this.label4.Text = "Blocks Broken:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(278, 251);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UI";
            this.Text = "Axiom Verge Tracker";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel AreaItemsCompleted;
        private System.Windows.Forms.Panel AreaMapCompleted;
        public System.Windows.Forms.Label AreaItemCount;
        public System.Windows.Forms.Label CurrentAutoMapName;
        public System.Windows.Forms.Label AreaScreenCount;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel ItemsCompleted;
        private System.Windows.Forms.Panel MapCompleted;
        public System.Windows.Forms.Label RedGooDestroyed;
        public System.Windows.Forms.Label ItemCount;
        public System.Windows.Forms.Label ScreenCount;
        public System.Windows.Forms.Label Difficulty;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label BricksDestroyed;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label HitPoints;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel Connection;
    }
}

