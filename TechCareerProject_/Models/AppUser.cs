using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechCareerProject_.Enums;

namespace TechCareerProject_.Models
{
    public class AppUser:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public int InsertedBy { get; set; }


        //Relational Properties
        public virtual AppUserProfile AppUserProfile { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<Order> Orders { get; set; }

        public AppUser()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
        }

    }
}
