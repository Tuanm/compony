namespace Mess
{
    partial class MilkteaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MilkteaForm));
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnJelly = new System.Windows.Forms.Button();
            this.btnFruit = new System.Windows.Forms.Button();
            this.btnPudding = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxChoosing = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxBill = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(114, 335);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(264, 335);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnJelly
            // 
            this.btnJelly.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJelly.Location = new System.Drawing.Point(183, 147);
            this.btnJelly.Name = "btnJelly";
            this.btnJelly.Size = new System.Drawing.Size(68, 29);
            this.btnJelly.TabIndex = 0;
            this.btnJelly.Text = "Jelly";
            this.btnJelly.UseVisualStyleBackColor = true;
            this.btnJelly.Click += new System.EventHandler(this.btnJelly_Click);
            // 
            // btnFruit
            // 
            this.btnFruit.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFruit.Location = new System.Drawing.Point(94, 147);
            this.btnFruit.Name = "btnFruit";
            this.btnFruit.Size = new System.Drawing.Size(68, 29);
            this.btnFruit.TabIndex = 0;
            this.btnFruit.Text = "Fruit";
            this.btnFruit.UseVisualStyleBackColor = true;
            this.btnFruit.Click += new System.EventHandler(this.btnFruit_Click);
            // 
            // btnPudding
            // 
            this.btnPudding.BackColor = System.Drawing.Color.Transparent;
            this.btnPudding.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPudding.Location = new System.Drawing.Point(271, 147);
            this.btnPudding.Name = "btnPudding";
            this.btnPudding.Size = new System.Drawing.Size(68, 29);
            this.btnPudding.TabIndex = 0;
            this.btnPudding.Text = "Pudding";
            this.btnPudding.UseVisualStyleBackColor = false;
            this.btnPudding.Click += new System.EventHandler(this.btnPudding_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Topping:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "Bill:";
            // 
            // tbxChoosing
            // 
            this.tbxChoosing.Location = new System.Drawing.Point(94, 307);
            this.tbxChoosing.Name = "tbxChoosing";
            this.tbxChoosing.ReadOnly = true;
            this.tbxChoosing.Size = new System.Drawing.Size(265, 20);
            this.tbxChoosing.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choosing:";
            // 
            // lbxBill
            // 
            this.lbxBill.FormattingEnabled = true;
            this.lbxBill.Location = new System.Drawing.Point(-1, 377);
            this.lbxBill.Name = "lbxBill";
            this.lbxBill.Size = new System.Drawing.Size(485, 212);
            this.lbxBill.TabIndex = 4;
            // 
            // MilkteaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mess.Properties.Resources._13319_Trasua;
            this.ClientSize = new System.Drawing.Size(484, 589);
            this.Controls.Add(this.lbxBill);
            this.Controls.Add(this.tbxChoosing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPudding);
            this.Controls.Add(this.btnFruit);
            this.Controls.Add(this.btnJelly);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnOrder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MilkteaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MilkTea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnJelly;
        private System.Windows.Forms.Button btnFruit;
        private System.Windows.Forms.Button btnPudding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxChoosing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxBill;
    }
}

