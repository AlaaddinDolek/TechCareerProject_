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
        AppUser appUser;
        public AdminForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser)
        {
            this.profileRep = profileRep;
            this.userRep = userRep;
            this.orderProductRep = orderProductRep;
            this.orderRep = orderRep;
            this.productRep = productRep;
            this.appUser = appUser;
            InitializeComponent();

        }

        private void btnProductAction_Click(object sender, EventArgs e)
        {
            ProductActionForm ProductActionForm = new ProductActionForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser);
            ProductActionForm.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm LoginForm = new LoginForm(profileRep, userRep, orderProductRep, orderRep, productRep);
            LoginForm.Show();
            Hide();
        }

        private void btnUserAction_Click(object sender, EventArgs e)
        {
            UserActionForm UserActionForm = new UserActionForm(profileRep, userRep, orderProductRep, orderRep, productRep,appUser);
            UserActionForm.Show();
            Hide();
        }

        private void btnOrderAction_Click(object sender, EventArgs e)
        {
            OrderForm OrderForm = new OrderForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser);
            OrderForm.Show();
            Hide();
        }

    }
}
