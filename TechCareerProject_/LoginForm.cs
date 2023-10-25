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
    public partial class LoginForm : Form
    {
        int remaining = 3;
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        BookkeepingRepository bookkeepingRep;
        public LoginForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, BookkeepingRepository bookkeepingRep)
        {
            this.profileRep = profileRep;
            this.userRep = userRep;
            this.orderProductRep = orderProductRep;
            this.orderRep = orderRep;
            this.productRep = productRep;
            this.bookkeepingRep = bookkeepingRep;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblKalanHak.Text = $"Kalan hakkınız: {remaining}";

            //AppUser appUser = new AppUser
            //{
            //    Username = "admin",
            //    Password = "password",
            //    Role = Enums.UserRole.Admin
            //};
            //userRep.Add(appUser);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            AppUser appUser = FindByUsernameAndPassword(username, password);
            if (appUser != null)
            {
                if (appUser.Role == Enums.UserRole.Admin)
                {
                    AdminForm adminForm = new AdminForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
                    adminForm.Show();
                    Hide();
                }
                else if (appUser.Role == Enums.UserRole.User)
                {
                    UserForm userForm = new UserForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
                    userForm.Show();
                    Hide();
                }
            }
        }

        private AppUser FindByUsernameAndPassword(string username, string password)
        {
            try
            {
                AppUser user = userRep.Where(x => x.Username == username && x.Password == password).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Kullanıcı adı ve şifre bilgilerinden en az birisi hatalı !");
                    remaining--;
                    if (remaining == 0)
                    {
                        MessageBox.Show("Giriş hakkınız kalmadı program sonlanıyor.");
                        Application.Exit();
                    }
                    lblKalanHak.Text = $"Kalan hakkınız: {remaining}";
                }
                return user;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Bir şeyler ters  gitti: {e.Message}");
                return null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
