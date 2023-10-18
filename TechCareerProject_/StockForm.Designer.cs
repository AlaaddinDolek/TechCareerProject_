namespace TechCareerProject_
{
    partial class StockForm
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
            this.btnInsertStock = new System.Windows.Forms.Button();
            this.nmrStock = new System.Windows.Forms.NumericUpDown();
            this.cmbStokProducts = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmrStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsertStock
            // 
            this.btnInsertStock.Location = new System.Drawing.Point(70, 285);
            this.btnInsertStock.Name = "btnInsertStock";
            this.btnInsertStock.Size = new System.Drawing.Size(75, 23);
            this.btnInsertStock.TabIndex = 12;
            this.btnInsertStock.Text = "Ekle";
            this.btnInsertStock.UseVisualStyleBackColor = true;
            // 
            // nmrStock
            // 
            this.nmrStock.Location = new System.Drawing.Point(70, 228);
            this.nmrStock.Name = "nmrStock";
            this.nmrStock.Size = new System.Drawing.Size(120, 22);
            this.nmrStock.TabIndex = 11;
            this.nmrStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbStokProducts
            // 
            this.cmbStokProducts.FormattingEnabled = true;
            this.cmbStokProducts.Location = new System.Drawing.Point(70, 159);
            this.cmbStokProducts.Name = "cmbStokProducts";
            this.cmbStokProducts.Size = new System.Drawing.Size(300, 24);
            this.cmbStokProducts.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(67, 205);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 16);
            this.label21.TabIndex = 8;
            this.label21.Text = "Adet";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(67, 140);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 16);
            this.label20.TabIndex = 9;
            this.label20.Text = "Ürün";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(141, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 29);
            this.label19.TabIndex = 7;
            this.label19.Text = "Stok Ekle";
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInsertStock);
            this.Controls.Add(this.nmrStock);
            this.Controls.Add(this.cmbStokProducts);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Name = "StockForm";
            this.Text = "Stok İşlemleri";
            ((System.ComponentModel.ISupportInitialize)(this.nmrStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsertStock;
        private System.Windows.Forms.NumericUpDown nmrStock;
        private System.Windows.Forms.ComboBox cmbStokProducts;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
    }
}