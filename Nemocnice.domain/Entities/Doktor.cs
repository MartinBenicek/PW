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
    [Table(nameof(Doktor))]
    public class Doktor : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string? Titul {  get; set; }

        [ForeignKey(nameof(UserRole))]
        public int UserRoleID { get; set; }

    }
}
