using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechCareerProject_.Models;
using TechCareerProject_.Options;
using TechCareerProject_.Repositories;

namespace TechCareerProject_
{
    public partial class CartForm : Form
    {
        ListBox lstProducts;
        decimal totalPrice;
        Order order;
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        BookkeepingRepository bookkeepingRep;
        AppUser appUser;
        public CartForm(ListBox lstProducts,decimal totalPrice, Order order, OrderRepository orderRep, ProductRepository productRep, AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, AppUser appUser, BookkeepingRepository bookkeepingRep)
        {
            this.orderRep = orderRep;
            this.order = order;
            this.lstProducts = lstProducts;
            this.totalPrice = totalPrice;
            this.productRep = productRep;
            this.profileRep = profileRep;
            this.userRep = userRep;
            this.appUser = appUser;
            this.bookkeepingRep = bookkeepingRep;
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            lstCart.DataSource = lstProducts.Items;
            lblTotalPrice.Text = $"Toplam Fiyat: {totalPrice:C2}";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (rtxtAddress.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Adres boş geçilemez");
            }
            else
            {
                order.Address = rtxtAddress.Text.Trim();
                order.GetTotalPrice();

                foreach (OrderProduct item in order.OrderProducts)
                {
                    item.Product.StockStatus -= item.Quantity;
                }
                Bookkeeping bookkeeping = new Bookkeeping { Order = order,Type=Enums.IncomeExpenseType.Income};
                bookkeeping.Amount = order.TotalPrice;
                bookkeepingRep.Add(bookkeeping);
                //TODO: orderRep.Add(order);
                MessageBox.Show("Sipariş oluşturuldu");

                rtxtAddress.Text = string.Empty;
                lstCart.DataSource = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OrderForm OrderForm = new OrderForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            OrderForm.Show();
            Hide();
        }
    }
}
