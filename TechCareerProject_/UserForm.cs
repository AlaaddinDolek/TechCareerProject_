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
    public partial class UserForm : Form
    {
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        BookkeepingRepository bookkeepingRep;
        AppUser appUser;
        public UserForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser, BookkeepingRepository bookkeepingRep)
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

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            OrderViewForm orderViewForm = new OrderViewForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            orderViewForm.Show();
            Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderForm OrderForm = new OrderForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            OrderForm.Show();
            Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            LoginForm LoginForm = new LoginForm(profileRep, userRep, orderProductRep, orderRep, productRep, bookkeepingRep);
            LoginForm.Show();
            Hide();
        }
    }
}
