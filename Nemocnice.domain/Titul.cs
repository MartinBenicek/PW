using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain
{
    [Table(nameof(Titul))]
    public class Titul
    {
        [Key]
        public int Id { get; set; }
        public string? titul { get; set; }
    }
}
