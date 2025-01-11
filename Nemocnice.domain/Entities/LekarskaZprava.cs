using Nemocnice.domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain.Entities
{
    [Table(nameof(LekarskaZprava))]
    public class LekarskaZprava : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime? Datum { get; set; }
        public string? Zprava { get; set; }

        [ForeignKey(nameof(Karta))]
        public int KartaID { get; set; }
    }
}