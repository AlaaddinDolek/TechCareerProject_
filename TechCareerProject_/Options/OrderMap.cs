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
//TODO: chatgpt son aramanın en altında hata aldın, normalizasyon hatası, bunu çöz. buraya "sipariş ver" butonundan geldin

