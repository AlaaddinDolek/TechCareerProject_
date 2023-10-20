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
    public partial class OrderViewForm : Form
    {
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        BookkeepingRepository bookkeepingRep;
        AppUser appUser;
        public OrderViewForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser, BookkeepingRepository bookkeepingRep)
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

        private void OrderViewForm_Load(object sender, EventArgs e)
        {
            dgvOrders.DataSource = orderRep.GetAll();
            
            dgvOrders.Columns["AppUser"].Visible = false;
            //dgvOrders.Columns["Bookkeping"].Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnShipped_Click(object sender, EventArgs e)
        {
            Order order = GetOrder();
            if (order != null)
            {
                if (order.Status == Enums.Status.Preparing)
                {
                    order.Status = Enums.Status.InTransit;
                    order.ShippingDate = DateTime.Now;
                    order.ModifiedDate = DateTime.Now;
                    orderRep.Update(order);
                    MessageBox.Show("Sipariş kargoya verildi");
                    dgvOrders.DataSource = orderRep.GetAll();
                    dgvOrders.Columns["AppUser"].Visible = false;
                }
            }

        }

        private void btnDelivered_Click(object sender, EventArgs e)
        {

            Order order = GetOrder();
            if (order != null)
            {

                if (order.Status != Enums.Status.Delivered)
                {
                    order.Status = Enums.Status.Delivered;
                    order.ModifiedDate = DateTime.Now;
                    orderRep.Update(order);
                    MessageBox.Show("Sipariş teslim edildi");
                    dgvOrders.DataSource = orderRep.GetAll();
                    dgvOrders.Columns["AppUser"].Visible = false;
                    Bookkeeping bookkeeping = new Bookkeeping {Order=order,Type=Enums.IncomeExpenseType.Income};
                    
                }
            }

        }

        private Order GetOrder()
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvOrders.SelectedRows[0];
                Order order = orderRep.Find((int)selectedRow.Cells["ID"].Value);

                return order;
            }
            else
            {
                MessageBox.Show("İşlem yapmak istediğiniz satırı seçiniz");
                return null;
            }


        }


    }
}
