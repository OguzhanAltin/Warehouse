using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DAL.ORM.Entity
{
   public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
