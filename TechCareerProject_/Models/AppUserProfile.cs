using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechCareerProject_.Models
{
   
    public class AppUserProfile:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCN { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}
