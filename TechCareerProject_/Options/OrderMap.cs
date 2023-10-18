using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareerProject_.Models;

namespace TechCareerProject_.Options
{
    public class OrderMap:BaseMap<Order>
    {
        public OrderMap()
        {
            Property(x => x.Status.ToString())
              .HasColumnName("Status")
              .IsRequired()
              .HasMaxLength(50);
        }
    }
}
