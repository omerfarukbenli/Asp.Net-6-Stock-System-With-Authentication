using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.Entities.Concrete.Dtos
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
    }
}
