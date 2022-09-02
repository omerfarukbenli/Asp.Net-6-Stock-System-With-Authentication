using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.Entities.Concrete.Dtos
{
    public class ikiliDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<string> Categories { get; set; }
    }
}
