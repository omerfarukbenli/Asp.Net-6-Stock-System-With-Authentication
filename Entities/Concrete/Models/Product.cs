using StokApp.Entities.Concrete.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.Entities.Concrete.Models
{
    public class Product:EntityBase, IEntity
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
