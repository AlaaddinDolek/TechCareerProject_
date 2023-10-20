using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareerProject_.Enums;

namespace TechCareerProject_.Models
{
    public class Bookkeeping:BaseEntity
    {
        public decimal Amount { get; set; }

        public IncomeExpenseType Type { get; set; }

        public ExpenseType? ExpenseType { get; set; }

        public string Description { get; set; }
        public string EmployeeFullName { get; set; }

        public int OrderID { get; set; }


        //Relational Properties

        public virtual Order Order { get; set; }

        public Bookkeeping()
        {
            if (Order != null)
            {
                Amount = Order.TotalPrice;
                OrderID = Order.ID;
            }
        }

    }
}
