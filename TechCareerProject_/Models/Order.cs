using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechCareerProject_.Enums;

namespace TechCareerProject_.Models
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }

        public string Address { get; set; }

        public Status Status { get; set; }

        public int AppUserID { get; set; }

        public DateTime? ShippingDate { get; set; }

        //Relational Properties
        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual Bookkeeping Bookkeeping { get; set; }
        public Order()
        {
            Status = Status.Preparing;
            OrderProducts = new List<OrderProduct>();
        }

        public void GetTotalPrice()
        {
            foreach (OrderProduct item in OrderProducts)
            TotalPrice += item.Quantity * item.Product.Price;
        }

    }   
    
}
