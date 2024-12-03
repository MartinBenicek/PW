using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain
{
    public class Ordinace
    {
        [Key]
        public int Id { get; set; }
        public string? Budova { get; set; }
        public string? Mistnost { get; set; }

        [ForeignKey(nameof(Doktor))]
        public int DoktorID { get; set; }
    }
}
