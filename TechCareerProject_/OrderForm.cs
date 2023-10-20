using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechCareerProject_.Common;
using TechCareerProject_.Models;
using TechCareerProject_.Repositories;

namespace TechCareerProject_
{
    public partial class OrderForm : Form
    {
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        BookkeepingRepository bookkeepingRep;
        AppUser appUser;
        decimal totalPrice = 0;
        Order orderReady = new Order();
        public OrderForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser, BookkeepingRepository bookkeepingRep)
        {
            this.profileRep = profileRep;
            this.userRep = userRep;
            this.orderProductRep = orderProductRep;
            this.orderRep = orderRep;
            this.productRep = productRep;
            this.appUser = appUser;
            this.bookkeepingRep = bookkeepingRep;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (appUser.Role == Enums.UserRole.Admin)
            {
                AdminForm adminForm = new AdminForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
                adminForm.Show();
                Hide();
            }
            else
            {
                UserForm userForm = new UserForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
                userForm.Show();
                Hide();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtProuctID_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckIdKeyPress(e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckPriceKeyPress(e, txtPrice);
        }

        private void btnCart_Click(object sender, EventArgs e)
        {

            if(lstCart.Items.Count == 0)
            {
                MessageBox.Show("Sepete en az 1 ürün ekleyin");
            }
            else
            {
                Bookkeeping bookkeeping = new Bookkeeping();
                orderReady.Bookkeeping = bookkeeping;
                //TODO: sepettekileri order yap ve diğer forma aktar

                CartForm cartForm = new CartForm(lstCart, totalPrice, orderReady, orderRep, productRep, profileRep, userRep, orderProductRep, appUser, bookkeepingRep);
                cartForm.Show();
                Hide();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = string.Empty;
            productName = txtProductName.Text.TrimEnd();
            int productID = 0;
            decimal price = 0;
            List<Product> productList = new List<Product>();
            if (txtProuctID.Text != string.Empty)
            {
                productID = Convert.ToInt32(txtProuctID.Text.TrimEnd());
            }
            else if (txtPrice.Text != string.Empty)
            {
                price = Convert.ToDecimal(txtPrice.Text.TrimEnd());
            }
            if (txtProductName.Text.Trim() == string.Empty && txtProuctID.Text == string.Empty && txtPrice.Text == string.Empty)
            {
                MessageBox.Show("Arama yapmak için ürün adı, ürün ID veya Max/Min olarak fiyat girin");
            }
            else
            {
                if (productID != 0)
                {
                    productID = Convert.ToInt32(txtProuctID.Text);
                    productList = productRep.Where(x => x.ID == productID).ToList();
                    dgvProducts.DataSource = productList;
                }
                else if (productName != string.Empty)
                {
                    productName = txtProductName.Text.TrimEnd();
                    productList = productRep.Where(x => x.ProductName.Contains(productName)).ToList();

                    if (rdbMax.Checked)
                    {

                        if (txtPrice.Text != string.Empty)
                        {
                            price = Convert.ToDecimal(txtPrice.Text);
                            productList = productList.Where(x => x.Price <= price).ToList();
                            dgvProducts.DataSource = productList;
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }
                        else
                        {
                            dgvProducts.DataSource = productRep.GetActives();
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }

                    }
                    else if (rdbMin.Checked)
                    {
                        if (txtPrice.Text != string.Empty)
                        {
                            price = Convert.ToDecimal(txtPrice.Text);
                            productList = productList.Where(x => x.Price >= price).ToList();
                            dgvProducts.DataSource = productList;
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }
                        else
                        {
                            dgvProducts.DataSource = productRep.GetActives();
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }

                    }
                    else if (txtPrice.Text != string.Empty)
                    {
                        productList = productRep.Where(x => x.Price == price).ToList();
                        dgvProducts.Columns["AppUser"].Visible = false;
                    }
                    else
                    {
                        dgvProducts.DataSource = productList;
                        dgvProducts.Columns["AppUser"].Visible = false;
                    }
                    
                }
                else
                {
                    if (rdbMax.Checked)
                    {

                        if (txtPrice.Text != string.Empty)
                        {
                            price = Convert.ToDecimal(txtPrice.Text);
                            productList = productRep.Where(x => x.Price <= price).ToList();
                            dgvProducts.DataSource = productList;
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }
                        else
                        {
                            dgvProducts.DataSource = productRep.GetActives();
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }

                    }
                    else if (rdbMin.Checked)
                    {
                        if (txtPrice.Text != string.Empty)
                        {
                            price = Convert.ToDecimal(txtPrice.Text);
                            productList = productRep.Where(x => x.Price >= price).ToList();
                            dgvProducts.DataSource = productList;
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }
                        else
                        {
                            dgvProducts.DataSource = productRep.GetActives();
                            dgvProducts.Columns["AppUser"].Visible = false;
                        }

                    }
                    else if(txtPrice.Text != string.Empty)
                    {
                        productList = productRep.Where(x => x.Price == price).ToList();
                        dgvProducts.Columns["AppUser"].Visible = false;
                    }
                }
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            List<Product> productList = productRep.GetActives();
            dgvProducts.DataSource = productList.Where(x=>x.StockStatus>0).ToList();
            dgvProducts.Columns["AppUser"].Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPrice.Text = string.Empty;
            txtProuctID.Text = string.Empty;
            rdbMax.Checked = false;
            rdbMax.Checked = false;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {

            if (dgvProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];
                Product product = productRep.Find((int)selectedRow.Cells["ID"].Value);

                if (productRep.Find((int)selectedRow.Cells["ID"].Value).StockStatus < nmrQuantity.Value)
                {
                    MessageBox.Show($"{product.ProductName} ürününden stokta {product.StockStatus} adet kaldı! Sipariş adeti veya stok güncellemesi yapın");
                } else
                {
                    OrderProduct orderProduct = new OrderProduct();
                    orderProduct.Product=product;
                    orderProduct.Quantity = (int)nmrQuantity.Value;
                    orderReady.OrderProducts.Add(orderProduct);
                    orderReady.AppUser = appUser;

                    decimal price = Convert.ToDecimal(product.Price) * (nmrQuantity.Value);
                    string selectedProduct = $"{product.ProductName} x {nmrQuantity.Value} ---> {price:C2}";

                    lstCart.Items.Add(selectedProduct);
                    totalPrice += price;
                    lblTotalPrice.Text = $"Toplam Tutar: {totalPrice:C2}";


                }
               
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            lstCart.Items.Clear();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedIndex != -1)
            {
                string selectedProduct = lstCart.SelectedItem.ToString();
                decimal price = GetPriceFromSelectedItem(selectedProduct);
                lstCart.Items.RemoveAt(lstCart.SelectedIndex);
                totalPrice -= price;
                lblTotalPrice.Text = $"Toplam Tutar: {totalPrice:C2}";

            }
            else
            {
                MessageBox.Show("Lütfen sepetten çıkarılacak ürünü seçin.");
            }
        }

        private decimal GetPriceFromSelectedItem(string selectedItem)
        {
            string[] parts = selectedItem.Split(new[] { " ---> " }, StringSplitOptions.None);
            if (parts.Length == 2)
            {
                string priceString = parts[1];
                decimal price;
                if (decimal.TryParse(priceString, NumberStyles.Currency, CultureInfo.CurrentCulture, out price))
                {
                    return price;
                }
            }
            return 0; // Geçersiz fiyat durumunda sıfır döner
        }
    }
}
