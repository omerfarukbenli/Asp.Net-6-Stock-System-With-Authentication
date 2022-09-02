using StokApp.Entities.Concrete.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.Entities.Concrete.Models
{
    public class Category: EntityBase, IEntity
    {
    
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
