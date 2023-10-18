using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareerProject_.Models;

namespace TechCareerProject_.Options
{
    public class OrderProductMap:BaseMap<OrderProduct>
    {
        public OrderProductMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.OrderID,
                x.ProductID
            });
        }
    }
}
