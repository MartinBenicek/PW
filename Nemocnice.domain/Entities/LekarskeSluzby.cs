using Nemocnice.domain.Entities.Interfaces;
using Nemocnice.domain.Validations;
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

        [Required]
        [FutureDate]
        public DateTime Datum { get; set; }

        [ForeignKey(nameof(Ordinace))]
        public int OrdinaceID { get; set; }

        [ForeignKey(nameof(Karta))]
        public int KartaID { get; set; }
        

    }
}
