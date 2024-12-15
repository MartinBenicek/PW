using Nemocnice.domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain.Entities
{
    [Table(nameof(Role))]
    public class Role : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string? Nazev { get; set; }
    }
}
