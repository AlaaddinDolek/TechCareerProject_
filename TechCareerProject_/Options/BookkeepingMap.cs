using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareerProject_.Models;

namespace TechCareerProject_.Options
{
    public class BookkeepingMap:BaseMap<Bookkeeping>
    {
        public BookkeepingMap()
        {
            Property(e => e.Amount)
            .HasColumnType("money")
            .HasColumnAnnotation("Format", "C2");

            HasOptional(x => x.Order)
           .WithRequired(x => x.Bookkeeping);

           
        }
    }
}
