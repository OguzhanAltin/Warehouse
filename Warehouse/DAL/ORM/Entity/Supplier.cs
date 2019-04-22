using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DAL.ORM.Entity
{
   public class Supplier:BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
