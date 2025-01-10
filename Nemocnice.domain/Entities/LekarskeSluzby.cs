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
    [Table(nameof(LekarskeSluzby))]
    public class LekarskeSluzby: IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string? Vysetreni { get; set; }
        public string? Ockovani { get; set; }
        public string? Ukon { get; set; }

        [ForeignKey(nameof(Ordinace))]
        public int OrdinaceID { get; set; }
        public Ordinace Ordinace { get; set; } // Navigation property

        [ForeignKey(nameof(Karta))]
        public int KartaID { get; set; }
        public Karta Karta { get; set; } // Navigation property
        [Required]
        public DateTime Datum { get; set; }

    }
}
