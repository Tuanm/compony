namespace Mess {
    partial class Workspace {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workspace));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.enter = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Label();
            this.hire = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.fire = new System.Windows.Forms.Button();
            this.information = new System.Windows.Forms.Label();
            this.map = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.see = new System.Windows.Forms.PictureBox();
            this.ask = new System.Windows.Forms.Button();
            this.leftSeeing = new System.Windows.Forms.Label();
            this.rightSeeing = new System.Windows.Forms.Label();
            this.seeing = new System.Windows.Forms.Label();
            this.scene = new System.Windows.Forms.PictureBox();
            this.goask = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.see)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scene)).BeginInit();
            this.goask.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 5;
            // 
            // enter
            // 
            this.enter.BackColor = System.Drawing.Color.White;
            this.enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enter.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enter.Location = new System.Drawing.Point(163, 253);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(129, 40);
            this.enter.TabIndex = 1;
            this.enter.Text = "Enter";
            this.toolTip.SetToolTip(this.enter, "Enter the workspace");
            this.enter.UseVisualStyleBackColor = false;
            this.enter.Visible = false;
            // 
            // menu
            // 
            this.menu.AutoSize = true;
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Location = new System.Drawing.Point(10, 10);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(29, 28);
            this.menu.TabIndex = 2;
            this.menu.Text = "☰";
            this.toolTip.SetToolTip(this.menu, "What can I do?");
            // 
            // hire
            // 
            this.hire.BackColor = System.Drawing.Color.White;
            this.hire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hire.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hire.Location = new System.Drawing.Point(10, 40);
            this.hire.Name = "hire";
            this.hire.Size = new System.Drawing.Size(129, 40);
            this.hire.TabIndex = 3;
            this.hire.Text = "Hire";
            this.toolTip.SetToolTip(this.hire, "Add new member to this workspace");
            this.hire.UseVisualStyleBackColor = false;
            this.hire.Visible = false;
            // 
            // change
            // 
            this.change.BackColor = System.Drawing.Color.White;
            this.change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.change.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change.Location = new System.Drawing.Point(10, 124);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(129, 40);
            this.change.TabIndex = 4;
            this.change.Text = "Manage";
            this.toolTip.SetToolTip(this.change, "Manage information of your member(s)");
            this.change.UseVisualStyleBackColor = false;
            this.change.Visible = false;
            // 
            // fire
            // 
            this.fire.BackColor = System.Drawing.Color.White;
            this.fire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fire.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fire.Location = new System.Drawing.Point(10, 82);
            this.fire.Name = "fire";
            this.fire.Size = new System.Drawing.Size(129, 40);
            this.fire.TabIndex = 5;
            this.fire.Text = "Fire";
            this.toolTip.SetToolTip(this.fire, "Remove your member(s)");
            this.fire.UseVisualStyleBackColor = false;
            this.fire.Visible = false;
            // 
            // information
            // 
            this.information.AutoSize = true;
            this.information.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.information.Cursor = System.Windows.Forms.Cursors.Hand;
            this.information.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.information.Location = new System.Drawing.Point(55, 10);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(28, 28);
            this.information.TabIndex = 6;
            this.information.Text = "ⓘ";
            this.toolTip.SetToolTip(this.information, "Who am I?");
            // 
            // map
            // 
            this.map.AutoSize = true;
            this.map.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.map.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.map.Location = new System.Drawing.Point(100, 10);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(31, 28);
            this.map.TabIndex = 7;
            this.map.Text = "⛯";
            this.toolTip.SetToolTip(this.map, "Where am I?");
            // 
            // see
            // 
            this.see.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.see.BackgroundImage = global::Mess.Properties.Resources.employee;
            this.see.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.see.Cursor = System.Windows.Forms.Cursors.Default;
            this.see.Location = new System.Drawing.Point(39, 7);
            this.see.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.see.Name = "see";
            this.see.Size = new System.Drawing.Size(51, 43);
            this.see.TabIndex = 13;
            this.see.TabStop = false;
            this.toolTip.SetToolTip(this.see, "See a member in this workspace");
            // 
            // ask
            // 
            this.ask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ask.BackColor = System.Drawing.Color.White;
            this.ask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ask.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ask.Location = new System.Drawing.Point(571, 64);
            this.ask.Name = "ask";
            this.ask.Size = new System.Drawing.Size(129, 40);
            this.ask.TabIndex = 12;
            this.ask.Text = "Ask";
            this.toolTip.SetToolTip(this.ask, "Ask this member for information");
            this.ask.UseVisualStyleBackColor = false;
            this.ask.Visible = false;
            // 
            // leftSeeing
            // 
            this.leftSeeing.AutoSize = true;
            this.leftSeeing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.leftSeeing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftSeeing.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftSeeing.Location = new System.Drawing.Point(3, 13);
            this.leftSeeing.Name = "leftSeeing";
            this.leftSeeing.Size = new System.Drawing.Size(38, 37);
            this.leftSeeing.TabIndex = 13;
            this.leftSeeing.Text = "◀";
            this.toolTip.SetToolTip(this.leftSeeing, "See previous member");
            // 
            // rightSeeing
            // 
            this.rightSeeing.AutoSize = true;
            this.rightSeeing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rightSeeing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightSeeing.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightSeeing.Location = new System.Drawing.Point(90, 13);
            this.rightSeeing.Name = "rightSeeing";
            this.rightSeeing.Size = new System.Drawing.Size(38, 37);
            this.rightSeeing.TabIndex = 14;
            this.rightSeeing.Text = "▶";
            this.toolTip.SetToolTip(this.rightSeeing, "See next member");
            // 
            // seeing
            // 
            this.seeing.AutoSize = true;
            this.seeing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.seeing.Cursor = System.Windows.Forms.Cursors.Default;
            this.seeing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seeing.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeing.Location = new System.Drawing.Point(134, 13);
            this.seeing.Name = "seeing";
            this.seeing.Size = new System.Drawing.Size(0, 24);
            this.seeing.TabIndex = 9;
            // 
            // scene
            // 
            this.scene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.scene.Cursor = System.Windows.Forms.Cursors.Default;
            this.scene.Location = new System.Drawing.Point(0, 0);
            this.scene.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(929, 386);
            this.scene.TabIndex = 0;
            this.scene.TabStop = false;
            // 
            // goask
            // 
            this.goask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.goask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.goask.Controls.Add(this.see);
            this.goask.Controls.Add(this.rightSeeing);
            this.goask.Controls.Add(this.leftSeeing);
            this.goask.Controls.Add(this.seeing);
            this.goask.Location = new System.Drawing.Point(444, 10);
            this.goask.Name = "goask";
            this.goask.Size = new System.Drawing.Size(272, 70);
            this.goask.TabIndex = 11;
            // 
            // Workspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(728, 386);
            this.Controls.Add(this.fire);
            this.Controls.Add(this.change);
            this.Controls.Add(this.hire);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.ask);
            this.Controls.Add(this.goask);
            this.Controls.Add(this.map);
            this.Controls.Add(this.information);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.scene);
            this.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Workspace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workspace";
            ((System.ComponentModel.ISupportInitialize)(this.see)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scene)).EndInit();
            this.goask.ResumeLayout(false);
            this.goask.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox scene;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.Label menu;
        private System.Windows.Forms.Button hire;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Button fire;
        private System.Windows.Forms.Label information;
        private System.Windows.Forms.Label map;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label seeing;
        private System.Windows.Forms.Panel goask;
        private System.Windows.Forms.Button ask;
        private System.Windows.Forms.PictureBox see;
        private System.Windows.Forms.Label rightSeeing;
        private System.Windows.Forms.Label leftSeeing;
    }
}