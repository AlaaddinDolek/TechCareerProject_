﻿using System;
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

namespace TechCareerProject_
{
    public partial class BookkeepingForm : Form
    {
        AppUserProfileRepository profileRep;
        AppUserRepository userRep;
        OrderProductRepository orderProductRep;
        OrderRepository orderRep;
        ProductRepository productRep;
        AppUser appUser;
        BookkeepingRepository bookkeepingRep;

        public BookkeepingForm(AppUserProfileRepository profileRep, AppUserRepository userRep, OrderProductRepository orderProductRep, OrderRepository orderRep, ProductRepository productRep, AppUser appUser, BookkeepingRepository bookkeepingRep)
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
            AdminForm AdminForm = new AdminForm(profileRep, userRep, orderProductRep, orderRep, productRep, appUser, bookkeepingRep);
            AdminForm.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtProfileID_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventValidation.CheckIdKeyPress(e);
        }

        private void BookkeepingForm_Load(object sender, EventArgs e)
        {
            dgvBookkeeping.DataSource = bookkeepingRep.GetAll();
            dgvBookkeeping.Columns["Order"].Visible = false;

            // selectedRow.Cells["ID"].Value


            Array enumValues = Enum.GetValues(typeof(ExpenseType));
            foreach (var value in enumValues)
            {
                cmbExpenseType.Items.Add(value);
            }
        }

        private void btnInsertExpense_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == string.Empty || txtDescription.Text == string.Empty || cmbExpenseType.SelectedIndex < 0)
            {
                MessageBox.Show("Boş alan bırakılamaz");
            }
            else
            {

                Bookkeeping bookkeepingNew = new Bookkeeping { Amount = Convert.ToInt32(txtAmount.Text), Description = txtDescription.Text.Trim(), ExpenseType = (ExpenseType)cmbExpenseType.SelectedItem };
                if (bookkeepingNew.ExpenseType == ExpenseType.Salary)
                {

                    AppUserProfile aup = profileRep.Find(Convert.ToInt32(txtProfileID.Text));
                    if (aup == null)
                    {
                        MessageBox.Show("Kişi bulunamadı");
                    }
                    else
                    {
                        bookkeepingNew.EmployeeFullName = $"{aup.FirstName} {aup.LastName}";
                        bookkeepingNew.Type = IncomeExpenseType.Expense;
                        bookkeepingRep.Add(bookkeepingNew);
                        MessageBox.Show("Ekleme başarılı");
                        dgvBookkeeping.DataSource = bookkeepingRep.GetAll();
                        txtProfileID.Enabled = false;
                    }
                }
                else
                {
                    bookkeepingNew.Type = IncomeExpenseType.Expense;
                    bookkeepingRep.Add(bookkeepingNew);
                    MessageBox.Show("Ekleme başarılı");
                    dgvBookkeeping.DataSource = bookkeepingRep.GetAll();
                    txtProfileID.Enabled = false;
                }


            }

        }

        private void cmbExpenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProfileID.Enabled = cmbExpenseType.SelectedItem.ToString() == ExpenseType.Salary.ToString();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvBookkeeping.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvBookkeeping.SelectedRows[0];
                if (selectedRow != null)
                {
                    int id = (int)dgvBookkeeping.SelectedRows[0].Cells["ID"].Value;
                    dgvOrders.DataSource = orderRep.Where(x => x.ID == id);
                    dgvOrders.Columns["AppUser"].Visible = false;
                    dgvOrders.Columns["Bookkeeping"].Visible = false;
                    
                }
                else
                {
                    MessageBox.Show("Detay görüntülemek için işlem satırını seçin");
                }
            }
        }

        private void btnViewTotal_Click(object sender, EventArgs e)
        {
            decimal total = bookkeepingRep.GetAll().Sum(item => item.Type == IncomeExpenseType.Expense ? -item.Amount : item.Amount);
            lblTotal.Text = $"Toplam: {total:C2}";

        }
    }
}
