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

        public string Description { get; set; }
    }
}
