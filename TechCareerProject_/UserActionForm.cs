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
using TechCareerProject_.Enums;
using TechCareerProject_.Models;
using TechCareerProject_.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TechCareerProject_
{
    public partial class UserActionForm : Form
    {
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        BookkeepingRepository bookkeepingRep;
        AppUser appUser;
        public UserActionForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser, BookkeepingRepository bookkeepingRep)
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


        public AppUser CheckUsername(string username)
        {
            AppUser user = userRep.Where(x => x.Username.ToLower().Equals(username.ToLower())).FirstOrDefault();
            return user;
        }

        public AppUserProfile CheckTC(string tc)
        {
            AppUserProfile profile = profileRep.Where(x => x.TCN.Equals(tc)).FirstOrDefault();
            return profile;
        }

        private void InsertProfile(string firstName, string lastName, string tcn, AppUser user,decimal salary)
        {
            AppUserProfile profile = new AppUserProfile();
            profile.FirstName = firstName;
            profile.LastName = lastName;
            profile.TCN = tcn;
            profile.AppUser = user;
            profile.Salary = salary;
            profileRep.Add(profile);
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckFirstNameAndLastNameKeyPress(e);
        }

        private void txtTC_TextChanged_1(object sender, EventArgs e)
        {
            EventValidation.CheckTCTextChange(e, txtTC);
        }
        private void txtUpdateTC_TextChanged(object sender, EventArgs e)
        {
            EventValidation.CheckTCTextChange(e, txtUpdateTC);
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckTCKeyPress(e);
        }

        private void btnInsertUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty || txtFirstname.Text.Trim() == string.Empty || txtLastname.Text.Trim() == string.Empty || txtTC.Text == string.Empty || txtSalary.Text==string.Empty)
            {
                MessageBox.Show("Alanların hiçbiri boş geçilemez");
            }
            else
            {
                if (Convert.ToDecimal(txtTC.Text) % 2 != 0)
                {
                    MessageBox.Show("TC kimlik numarası tek sayı ile bitemez");
                }
                else if (CheckUsername(txtUsername.Text.Trim()) != null)
                {
                    MessageBox.Show("Kullanıcı Adı daha önce alınmış");
                }
                else if (CheckTC(txtTC.Text) != null)
                {
                    MessageBox.Show("Bu TC numarasına ait kullanıcı bulunmaktadır");
                }
                else
                {
                    if (txtUsername.Text.Trim().Length < 3)
                    {
                        MessageBox.Show("Kullanıcı adı en az 3 karakter olmalıdır");
                    }
                    else if (txtPassword.Text.Trim().Length < 3)
                    {
                        MessageBox.Show("Şifre en az 3 karakter olmalıdır");
                    }
                    else if (txtFirstname.Text.Trim().Length < 2)
                    {
                        MessageBox.Show("İsim en az 2 karakter olmalıdır");
                    }
                    else if (txtLastname.Text.Trim().Length < 2)
                    {
                        MessageBox.Show("Soyisim en az 2 karakter olmalıdır");
                    }
                    else if (txtTC.Text.Length != 11)
                    {
                        MessageBox.Show("TC No 11 karakter olmalıdır");
                    }
                    else if (cmbRole.SelectedIndex < 0)
                    {
                        MessageBox.Show("Rol seçiniz");
                    }
                    else
                    {
                        AppUser user = new AppUser();
                        user.Username = txtUsername.Text.Trim();
                        user.Password = txtPassword.Text.Trim();
                        if (cmbRole.SelectedItem.ToString() == "Admin")
                        {
                            try
                            {
                                user.Role = UserRole.Admin;
                                user.InsertedBy = appUser.ID;
                                userRep.Add(user);
                                InsertProfile(txtFirstname.Text.Trim(), txtLastname.Text.Trim(), txtTC.Text, user,Convert.ToInt32(txtSalary.Text));
                                MessageBox.Show("Yekili başarıyla eklendi");
                                txtUsername.Text = string.Empty;
                                txtPassword.Text = string.Empty;
                                txtFirstname.Text = string.Empty;
                                txtLastname.Text = string.Empty;
                                txtTC.Text = string.Empty;
                                txtSalary.Text = string.Empty;
                                cmbRole.Text = string.Empty;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.Message);
                            }

                        }
                        else if (cmbRole.SelectedItem.ToString() == "User")
                        {
                            user.Role = UserRole.User;
                            user.InsertedBy = appUser.ID;
                            userRep.Add(user);
                            InsertProfile(txtFirstname.Text.Trim(), txtLastname.Text.Trim(), txtTC.Text, user, Convert.ToInt32(txtSalary.Text));
                            MessageBox.Show("Kullanıcı başarıyla eklendi");
                            txtUsername.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            txtFirstname.Text = string.Empty;
                            txtLastname.Text = string.Empty;
                            txtTC.Text = string.Empty;
                            txtSalary.Text= string.Empty;
                            cmbRole.Text = string.Empty;
                        } else
                        {
                            MessageBox.Show("Kullanıcı rolü seçiniz");
                        }
                    }
                }
            }
        }

        private void UserActionForm_Load(object sender, EventArgs e)
        {
            Array enumValues = Enum.GetValues(typeof(UserRole));
            foreach (var value in enumValues)
            {
                cmbRole.Items.Add(value);
                cmbUpdateRole.Items.Add(value);
            }
        }

        private void AddUserToDataGridView(AppUser user)
        {
            dgvAppUser.DataSource = new List<AppUser> { user };
            dgvAppUser.Columns["AppUserProfile"].Visible = false;
        }

        private void AddProfileToDataGridView(AppUserProfile profile)
        {
            dgvProfile.DataSource = new List<AppUserProfile> { profile };
            dgvProfile.Columns["AppUser"].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvAppUser.DataSource=null;
            dgvProfile.DataSource=null;
            if (txtSearchUsername.Text != string.Empty)
            {
                string username = txtSearchUsername.Text.Trim();
                if(username == "admin")
                {
                    MessageBox.Show("'admin' kullanıcı adı ile ilgili işlem yapılamaz");
                }
                else
                {
                    AppUser user = userRep.Where(x => x.Username == username).FirstOrDefault();
                    if (user != null)
                    {
                        AddUserToDataGridView(user);
                        AddProfileToDataGridView(user.AppUserProfile);
                        btnUpdate.Enabled = true;
                        txtUpdateFirstName.Enabled = true;
                        txtUpdateLastName.Enabled = true;
                        txtUpdateUsername.Enabled = true;
                        txtUpdateTC.Enabled = true;
                        txtUpdatePassword.Enabled = true;
                        txtUpdateSalary.Enabled = true;
                        cmbUpdateRole.Enabled = true;

                        txtUpdateFirstName.Text=user.AppUserProfile.FirstName;
                        txtUpdateLastName.Text=user.AppUserProfile.LastName;
                        txtUpdateUsername.Text = user.Username;
                        txtUpdateTC.Text = user.AppUserProfile.TCN;
                        txtUpdatePassword.Text = user.Password;
                        txtUpdateSalary.Text = user.AppUserProfile.Salary.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Aradığınız kullanıcı adı ile kullanıcı bulunamadı");
                    }
                }
                
            }
            else if (txtSearchUserID.Text != string.Empty)
            {
                int userID = Convert.ToInt32(txtSearchUserID.Text);
                if (userID == 1)
                {
                    MessageBox.Show("'admin' kullanıcısı ile ilgili işlem yapılamaz");
                }
                else
                {
                    AppUser user = userRep.Where(x => x.ID == userID).FirstOrDefault();
                    if (user != null)
                    {
                        AddUserToDataGridView(user);
                        AddProfileToDataGridView(user.AppUserProfile);
                        btnUpdate.Enabled = true;
                        txtUpdateFirstName.Enabled = true;
                        txtUpdateLastName.Enabled = true;
                        txtUpdateUsername.Enabled = true;
                        txtUpdateTC.Enabled = true;
                        txtUpdatePassword.Enabled = true;
                        txtUpdateSalary.Enabled = true;
                        cmbUpdateRole.Enabled = true;

                        txtUpdateFirstName.Text=user.AppUserProfile.FirstName;
                        txtUpdateLastName.Text=user.AppUserProfile.LastName;
                        txtUpdateUsername.Text = user.Username;
                        txtUpdateTC.Text = user.AppUserProfile.TCN;
                        txtUpdatePassword.Text = user.Password;
                        txtUpdateSalary.Text = user.AppUserProfile.Salary.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Aradığınız kullanıcı ID ile kullanıcı bulunamadı");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı aramak için arama bilgilerinden en az bir tanesini girmeniz gereklidir");
            }
        }


        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckIdKeyPress(e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtUpdateUsername.Text.Trim() == string.Empty || txtUpdatePassword.Text.Trim() == string.Empty || txtUpdateFirstName.Text.Trim() == string.Empty || txtUpdateLastName.Text.Trim() == string.Empty || txtUpdateTC.Text == string.Empty||txtUpdateSalary.Text==string.Empty)
            {
                MessageBox.Show("Alanların hiçbiri boş geçilemez");
            }
            else
            {
                AppUser au = userRep.Find(Convert.ToInt32(dgvAppUser.Rows[0].Cells[dgvAppUser.Columns["ID"].Index].Value));
                if(au.Username != txtUpdateUsername.Text.Trim()&& CheckUsername(txtUpdateUsername.Text.Trim()) != null)
                {
                     MessageBox.Show("Kullanıcı Adı daha önce alınmış");                  
                } 
                else if(au.AppUserProfile.TCN != txtUpdateTC.Text && CheckTC(txtUpdateTC.Text) != null)
                {
                     MessageBox.Show("Bu TC numarasına ait kullanıcı bulunmaktadır");
                }
                else
                {
                    if (Convert.ToDecimal(txtUpdateTC.Text) % 2 != 0)
                    {
                        MessageBox.Show("TC kimlik numarası tek sayı ile bitemez");
                    }
                    else
                    {
                        if (txtUpdateUsername.Text.Trim().Length < 3)
                        {
                            MessageBox.Show("Kullanıcı adı en az 3 karakter olmalıdır");
                        }
                        else if (txtUpdatePassword.Text.Trim().Length < 3)
                        {
                            MessageBox.Show("Şifre en az 3 karakter olmalıdır");
                        }
                        else if (txtUpdateFirstName.Text.Trim().Length < 2)
                        {
                            MessageBox.Show("İsim en az 2 karakter olmalıdır");
                        }
                        else if (txtUpdateLastName.Text.Trim().Length < 2)
                        {
                            MessageBox.Show("Soyisim en az 2 karakter olmalıdır");
                        }
                        else if (txtUpdateTC.Text.Length != 11)
                        {
                            MessageBox.Show("TC No 11 karakter olmalıdır");
                        }
                        else if(cmbUpdateRole.SelectedIndex < 0)
                        {
                            MessageBox.Show("Rol seçiniz");
                        }else
                        {
                            AppUser user = new AppUser();
                            user.ID = Convert.ToInt32(dgvAppUser.Rows[0].Cells[dgvAppUser.Columns["ID"].Index].Value);
                            user.InsertedBy = Convert.ToInt32(dgvAppUser.Rows[0].Cells[dgvAppUser.Columns["InsertedBy"].Index].Value);
                            user.Username = txtUpdateUsername.Text.Trim();
                            user.Password = txtUpdatePassword.Text.Trim();
                            if (cmbUpdateRole.SelectedItem.ToString() == "Admin")
                            {
                                user.Role = UserRole.Admin;
                            }
                            else
                            {
                                user.Role = UserRole.User;
                            }
                                userRep.Update(user);

                            AppUserProfile profile = new AppUserProfile();
                            profile.ID = Convert.ToInt32(dgvAppUser.Rows[0].Cells[dgvAppUser.Columns["ID"].Index].Value);
                            profile.FirstName = txtUpdateFirstName.Text.Trim();
                            profile.LastName = txtUpdateLastName.Text.Trim();
                            profile.TCN = txtUpdateTC.Text;
                            profile.Salary=Convert.ToDecimal(txtUpdateSalary.Text.Trim());
                            profile.AppUser = user;
                            profileRep.Update(profile);

                            MessageBox.Show("Güncelleme işlemi başarılı");

                            btnUpdate.Enabled = false;
                            txtUpdateFirstName.Enabled = false;
                            txtUpdateLastName.Enabled = false;
                            txtUpdateUsername.Enabled = false;
                            txtUpdateTC.Enabled = false;
                            txtUpdatePassword.Enabled = false;
                            txtUpdateSalary.Enabled = false;
                            cmbUpdateRole.Enabled = false;
                            dgvAppUser.DataSource = null;
                            dgvProfile.DataSource = null;

                        }

                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
                AdminForm AdminForm = new AdminForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
                AdminForm.Show();
                Hide();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
