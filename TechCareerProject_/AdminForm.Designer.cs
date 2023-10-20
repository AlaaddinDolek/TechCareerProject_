namespace TechCareerProject_
{
    partial class AdminForm
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
            this.btnUserAction = new System.Windows.Forms.Button();
            this.btnProductAction = new System.Windows.Forms.Button();
            this.btnOrderAction = new System.Windows.Forms.Button();
            this.btnBookkeepingAction = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUserAction
            // 
            this.btnUserAction.Location = new System.Drawing.Point(51, 101);
            this.btnUserAction.Name = "btnUserAction";
            this.btnUserAction.Size = new System.Drawing.Size(154, 58);
            this.btnUserAction.TabIndex = 1;
            this.btnUserAction.Text = "Kullanıcı İşlemleri";
            this.btnUserAction.UseVisualStyleBackColor = true;
            this.btnUserAction.Click += new System.EventHandler(this.btnUserAction_Click);
            // 
            // btnProductAction
            // 
            this.btnProductAction.Location = new System.Drawing.Point(252, 101);
            this.btnProductAction.Name = "btnProductAction";
            this.btnProductAction.Size = new System.Drawing.Size(154, 58);
            this.btnProductAction.TabIndex = 1;
            this.btnProductAction.Text = "Ürün İşlemleri";
            this.btnProductAction.UseVisualStyleBackColor = true;
            this.btnProductAction.Click += new System.EventHandler(this.btnProductAction_Click);
            // 
            // btnOrderAction
            // 
            this.btnOrderAction.Location = new System.Drawing.Point(51, 191);
            this.btnOrderAction.Name = "btnOrderAction";
            this.btnOrderAction.Size = new System.Drawing.Size(154, 58);
            this.btnOrderAction.TabIndex = 1;
            this.btnOrderAction.Text = "Sipariş Oluşturma";
            this.btnOrderAction.UseVisualStyleBackColor = true;
            this.btnOrderAction.Click += new System.EventHandler(this.btnOrderAction_Click);
            // 
            // btnBookkeepingAction
            // 
            this.btnBookkeepingAction.Location = new System.Drawing.Point(154, 267);
            this.btnBookkeepingAction.Name = "btnBookkeepingAction";
            this.btnBookkeepingAction.Size = new System.Drawing.Size(154, 58);
            this.btnBookkeepingAction.TabIndex = 1;
            this.btnBookkeepingAction.Text = "Gelir-Gider";
            this.btnBookkeepingAction.UseVisualStyleBackColor = true;
            this.btnBookkeepingAction.Click += new System.EventHandler(this.btnBookkeepingAction_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(175, 347);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 37);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.Location = new System.Drawing.Point(252, 191);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(154, 58);
            this.btnViewOrders.TabIndex = 1;
            this.btnViewOrders.Text = "Sipariş İşlemleri";
            this.btnViewOrders.UseVisualStyleBackColor = true;
            this.btnViewOrders.Click += new System.EventHandler(this.btnViewOrders_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 486);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBookkeepingAction);
            this.Controls.Add(this.btnViewOrders);
            this.Controls.Add(this.btnOrderAction);
            this.Controls.Add(this.btnProductAction);
            this.Controls.Add(this.btnUserAction);
            this.Name = "AdminForm";
            this.Text = "Admin Paneli";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUserAction;
        private System.Windows.Forms.Button btnProductAction;
        private System.Windows.Forms.Button btnOrderAction;
        private System.Windows.Forms.Button btnBookkeepingAction;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewOrders;
    }
}