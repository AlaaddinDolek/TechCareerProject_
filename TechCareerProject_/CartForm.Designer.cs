namespace TechCareerProject_
{
    partial class CartForm
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
            this.lstCart = new System.Windows.Forms.ListBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.rtxtAddress = new System.Windows.Forms.RichTextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCart
            // 
            this.lstCart.FormattingEnabled = true;
            this.lstCart.ItemHeight = 16;
            this.lstCart.Location = new System.Drawing.Point(25, 21);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(342, 212);
            this.lstCart.TabIndex = 0;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(22, 251);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 16);
            this.lblTotalPrice.TabIndex = 1;
            // 
            // rtxtAddress
            // 
            this.rtxtAddress.Location = new System.Drawing.Point(435, 21);
            this.rtxtAddress.Name = "rtxtAddress";
            this.rtxtAddress.Size = new System.Drawing.Size(338, 88);
            this.rtxtAddress.TabIndex = 2;
            this.rtxtAddress.Text = "";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(435, 127);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(143, 32);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "Sipariş Oluştur";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.rtxtAddress);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lstCart);
            this.Name = "CartForm";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.CartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCart;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.RichTextBox rtxtAddress;
        private System.Windows.Forms.Button btnOrder;
    }
}