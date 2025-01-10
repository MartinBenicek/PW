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
        [Table(nameof(Predpis))]
        public class Predpis : IEntity<int>
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string? TypLeku { get; set; }
            public string? NazevLeku { get; set; }
            public string? CasPodani { get; set; }
            [ForeignKey(nameof(LekarskeSluzby))]
            public int LekarskeSluzbyID { get; set; }
        }
}
