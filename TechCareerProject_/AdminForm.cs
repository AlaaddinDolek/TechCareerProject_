using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechCareerProject_.Enums;
using TechCareerProject_.Models;
using TechCareerProject_.Repositories;

namespace TechCareerProject_
{
    public partial class AdminForm : Form
    {
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        BookkeepingRepository bookkeepingRep;
        AppUser appUser;
        public AdminForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser, BookkeepingRepository bookkeepingRep)
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

        private void btnProductAction_Click(object sender, EventArgs e)
        {
            ProductActionForm productActionForm = new ProductActionForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            productActionForm.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(profileRep, userRep, orderProductRep, orderRep, productRep, bookkeepingRep);
            loginForm.Show();
            Hide();
        }

        private void btnUserAction_Click(object sender, EventArgs e)
        {
            UserActionForm userActionForm = new UserActionForm(profileRep, userRep, orderProductRep, orderRep, productRep,appUser, bookkeepingRep);
            userActionForm.Show();
            Hide();
        }

        private void btnOrderAction_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            orderForm.Show();
            Hide();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            OrderViewForm orderViewForm = new OrderViewForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            orderViewForm.Show();
            Hide();
        }

        private void btnBookkeepingAction_Click(object sender, EventArgs e)
        {
            BookkeepingForm bookkeepingForm = new BookkeepingForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            bookkeepingForm.Show();
            Hide();
        }
    }
}
