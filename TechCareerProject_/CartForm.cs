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
using TechCareerProject_.Repositories;

namespace TechCareerProject_
{
    public partial class CartForm : Form
    {
        ListBox lstProducts;
        decimal totalPrice;
        Order order;
        OrderRepository orderRep;
        public CartForm(ListBox lstProducts,decimal totalPrice, Order order,OrderRepository orderRep)
        {
            this.orderRep = orderRep;
            this.order = order;
            this.lstProducts = lstProducts;
            this.totalPrice = totalPrice;
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            lstCart.DataSource = lstProducts.Items;
            lblTotalPrice.Text = $"Toplam Fiyat: {totalPrice:C2}";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            order.Address = rtxtAddress.Text;
            order.GetTotalPrice();

            orderRep.Add(order);
            MessageBox.Show("Sipariş oluşturuldu");
        }
    }
}
