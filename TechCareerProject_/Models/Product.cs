using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechCareerProject_.Models
{

    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockStatus { get; set; }

        public int? AppUserID { get; set; }

        //Relational Properties
        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual AppUser AppUser { get; set; }

        public Product()
        {
            OrderProducts = new List<OrderProduct>();
        }
    }
}
