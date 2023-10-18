using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechCareerProject_.Common;
using TechCareerProject_.Models;
using TechCareerProject_.Options;
using TechCareerProject_.Repositories;

namespace TechCareerProject_
{
    public partial class ProductActionForm : Form
    {
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        AppUser appUser;
        public ProductActionForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser)
        {
            this.profileRep = profileRep;
            this.userRep = userRep;
            this.orderProductRep = orderProductRep;
            this.orderRep = orderRep;
            this.productRep = productRep;
            this.appUser = appUser;
            InitializeComponent();
        }
        private bool CheckProductName(string productName)
        {
            Product p = productRep.Where(x => x.ProductName.ToLower().Equals(productName.ToLower())).FirstOrDefault();

            return p != null;
        }
        private bool CheckPriceAndStock(string price, decimal stock)
        {
            try
            {
                Convert.ToDecimal(price);
                Convert.ToInt32(stock);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Fiyat ve Stok bilgilerinden en az bir tanesi hatalı");
                return false;
            }
        }

        private void btnInsertProduct_Click_1(object sender, EventArgs e)
        {
            if (txtProuctName.Text.Trim() != string.Empty && txtPrice.Text != string.Empty && txtDescription.Text.Trim() != string.Empty)
            {
                if (CheckProductName(txtProuctName.Text.Trim()))
                {
                    MessageBox.Show("Ürün adı zaten mevcut, başka bir ürün adı girin");
                }
                else if (CheckPriceAndStock(txtPrice.Text, nmrStock.Value))
                {
                    Product p = new Product();
                    p.ProductName = txtProuctName.Text.Trim();
                    p.Price = Convert.ToDecimal(txtPrice.Text);
                    p.StockStatus = Convert.ToInt32(nmrStock.Value);
                    p.Description = txtDescription.Text.Trim();
                    p.AppUser = appUser;
                    productRep.Add(p);
                    MessageBox.Show("Ürün başarıyla eklendi");
                    txtProuctName.Text = string.Empty;
                    txtPrice.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    nmrStock.Value = 1;
                }
                else
                {
                    MessageBox.Show("Fiyat ve Stok bilgilerinden en az birini hatalı girdiniz");
                }

            }
            else
            {
                MessageBox.Show("Boş alan bırakılamaz");
            }
        }

        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckPriceKeyPress(e, txtPrice);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = null;
            if(txtSearchProductName.Text != string.Empty)
            {
                string productName = txtSearchProductName.Text;
                Product product = productRep.Where(x=>x.ProductName == productName).FirstOrDefault();
                if(product != null)
                {
                    AddProductToDataGridView(product);
                    btnUpdate.Enabled = true;
                    txtUpdateDescription.Enabled = true;
                    txtUpdatePrice.Enabled = true;
                    txtUpdateProductName.Enabled = true;
                    nmrUpdateStock.Enabled = true;
                    txtUpdateProductName.Text = product.ProductName;
                    txtUpdatePrice.Text = product.Price.ToString();
                    txtUpdateDescription.Text = product.Description;
                } else
                {
                    MessageBox.Show("Aradığınız ürün adı ile ürün bulunamadı");
                }
            } else if(txtSearchProductID.Text != string.Empty)
            {
                int productID = Convert.ToInt32(txtSearchProductID.Text);
                Product product = productRep.Where(x => x.ID == productID).FirstOrDefault();
                if (product != null)
                {
                    AddProductToDataGridView(product);
                    btnUpdate.Enabled = true;
                    txtUpdateDescription.Enabled = true;
                    txtUpdatePrice.Enabled = true;
                    txtUpdateProductName.Enabled = true;
                    nmrUpdateStock.Enabled = true;
                    txtUpdateProductName.Text = product.ProductName;
                    txtUpdatePrice.Text = product.Price.ToString();
                    txtUpdateDescription.Text = product.Description;
                }
                else
                {
                    MessageBox.Show("Aradığınız ürün ID ile ürün bulunamadı");
                }
            }
            else
            {
                MessageBox.Show("Ürün aramak için arama bilgilerinden en az bir tanesini girmeniz gereklidir");
            }
            
        }

        private void AddProductToDataGridView(Product product)
        {
            List<Product> products = new List<Product>();
            products.Add(product);
            dgvProduct.DataSource = products;
            dgvProduct.Columns["AppUser"].Visible = false;
        }

        private void txtSearchProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckIdKeyPress(e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdateProductName.Text.Trim() != string.Empty && txtUpdatePrice.Text != string.Empty && txtUpdateDescription.Text.Trim() != string.Empty)
            {
                Product product = productRep.Find(Convert.ToInt32(dgvProduct.Rows[0].Cells[dgvProduct.Columns["ID"].Index].Value));
                if (product.ProductName != txtUpdateProductName.Text.Trim())
                {
                    if (CheckProductName(txtUpdateProductName.Text.Trim()))
                    {
                        MessageBox.Show("Ürün adı zaten mevcut, başka bir ürün adı girin");
                    }
                } else
                {
                    if (CheckPriceAndStock(txtUpdatePrice.Text, nmrUpdateStock.Value))
                    {
                        Product p = new Product();
                        p.ID = Convert.ToInt32(dgvProduct.Rows[0].Cells[dgvProduct.Columns["ID"].Index].Value);
                        p.AppUserID = Convert.ToInt32(dgvProduct.Rows[0].Cells[dgvProduct.Columns["AppUserID"].Index].Value);
                        p.ProductName = txtUpdateProductName.Text.Trim();
                        p.Price = Convert.ToDecimal(txtUpdatePrice.Text);
                        p.Description = txtUpdateDescription.Text.Trim();
                        p.StockStatus = Convert.ToInt32(nmrUpdateStock.Value);
                        productRep.Update(p);
                        MessageBox.Show("Güncelleme işlemi başarılı");

                        btnUpdate.Enabled = false;
                        txtUpdateDescription.Enabled = false;
                        txtUpdatePrice.Enabled = false;
                        txtUpdateProductName.Enabled = false;
                        nmrUpdateStock.Enabled = false;
                        nmrUpdateStock.Value = 1;
                        txtUpdateProductName.Text = string.Empty;
                        txtUpdatePrice.Text = string.Empty;
                        txtUpdateDescription.Text = string.Empty;
                        dgvProduct.DataSource = null;

                    }
                    else
                    {
                        MessageBox.Show("Fiyat ve Stok bilgilerinden en az birini hatalı girdiniz");
                    }

                }
            }
               
                
            else
            {
                MessageBox.Show("Boş alan bırakılamaz");
            }
        }

        private void txtUpdatePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckPriceKeyPress(e, txtUpdatePrice);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (appUser.Role == Enums.UserRole.Admin)
            {
                AdminForm AdminForm = new AdminForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser);
                AdminForm.Show();
                Hide();
            }
            else
            {
                LoginForm LoginForm = new LoginForm(profileRep, userRep, orderProductRep, orderRep, productRep);
                LoginForm.Show();
                Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
          Application.Exit();
        }

        private void txtProuctName_KeyPress(object sender, KeyPressEventArgs e)
        {
           // EventValidation.CheckSpaceCharacter(e);
        }
    }
}