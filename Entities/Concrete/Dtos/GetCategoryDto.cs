using StokApp.Entities.Concrete.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.Entities.Concrete.Dtos
{
    public class GetCategoryDto:DtoBase
    {
        public string CategoryName { get; set; }
    }
}
