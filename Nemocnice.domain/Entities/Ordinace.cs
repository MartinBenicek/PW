using Microsoft.AspNetCore.Http;
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
    [Table(nameof(Ordinace))]
    public class Ordinace: IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Budova { get; set; }
        [Required]
        public string? Mistnost { get; set; }
        public string? ImageSrc { get; set; }
        [NotMapped]
        [FileContent("image")]
        public IFormFile? Image { get; set; }
        [ForeignKey(nameof(Doktor))]
        public int DoktorID { get; set; }
    }
}
