using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechCareerProject_.Models;
using TechCareerProject_.Repositories;

namespace TechCareerProject_
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppUserProfileRepository profileDB = new AppUserProfileRepository();
            AppUserRepository userDB = new AppUserRepository();
            OrderProductRepository orderProductDB = new OrderProductRepository();
            OrderRepository orderDB = new OrderRepository();
            ProductRepository productDB = new ProductRepository();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(profileDB, userDB, orderProductDB, orderDB, productDB));
        }
    }
}
