using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareerProject_.Models;

namespace TechCareerProject_.Options
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public AppUserMap()
        {
            HasOptional(x => x.AppUserProfile).WithRequired(x => x.AppUser);
            
        }
    }
}
