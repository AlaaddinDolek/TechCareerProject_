using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechCareerProject_.Models;

namespace TechCareerProject_.Options
{
    public class OrderMap:BaseMap<Order>
    {
        public OrderMap()
        {
            Property(e => e.TotalPrice)
            .HasColumnType("money")
            .HasColumnAnnotation("Format", "C2");

           
        }
    }
}

