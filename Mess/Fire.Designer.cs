namespace Mess {
    partial class Fire {
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
            this.tree = new System.Windows.Forms.TreeView();
            this.fireCancel = new System.Windows.Forms.Button();
            this.fireOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tree.CheckBoxes = true;
            this.tree.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree.Location = new System.Drawing.Point(12, 26);
            this.tree.Name = "tree";
            this.tree.ShowPlusMinus = false;
            this.tree.Size = new System.Drawing.Size(376, 292);
            this.tree.TabIndex = 0;
            // 
            // fireCancel
            // 
            this.fireCancel.BackColor = System.Drawing.Color.White;
            this.fireCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fireCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fireCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fireCancel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireCancel.Location = new System.Drawing.Point(209, 334);
            this.fireCancel.Name = "fireCancel";
            this.fireCancel.Size = new System.Drawing.Size(129, 40);
            this.fireCancel.TabIndex = 41;
            this.fireCancel.Text = "Cancel";
            this.fireCancel.UseVisualStyleBackColor = false;
            this.fireCancel.Click += new System.EventHandler(this.fireCancel_Click);
            // 
            // fireOK
            // 
            this.fireOK.BackColor = System.Drawing.Color.White;
            this.fireOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fireOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.fireOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fireOK.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireOK.Location = new System.Drawing.Point(50, 334);
            this.fireOK.Name = "fireOK";
            this.fireOK.Size = new System.Drawing.Size(129, 40);
            this.fireOK.TabIndex = 40;
            this.fireOK.Text = "Fire";
            this.fireOK.UseVisualStyleBackColor = false;
            this.fireOK.Click += new System.EventHandler(this.fireOK_Click);
            // 
            // Fire
            // 
            this.AcceptButton = this.fireOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Yellow;
            this.CancelButton = this.fireCancel;
            this.ClientSize = new System.Drawing.Size(400, 386);
            this.Controls.Add(this.fireCancel);
            this.Controls.Add(this.fireOK);
            this.Controls.Add(this.tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fire";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fire";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button fireCancel;
        private System.Windows.Forms.Button fireOK;
    }
}