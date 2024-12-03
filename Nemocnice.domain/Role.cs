using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        string? Name { get; set; }
    }
}
