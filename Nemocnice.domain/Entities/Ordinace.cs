﻿using Nemocnice.domain.Entities.Interfaces;
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

        [ForeignKey(nameof(Doktor))]
        public int DoktorID { get; set; }
    }
}
