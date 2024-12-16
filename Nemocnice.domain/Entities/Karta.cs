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
    [Table(nameof(Karta))]
    public class Karta : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Stav { get; set; }

        [ForeignKey(nameof(Pacient))]
        public int PacientID { get; set; }

        [ForeignKey(nameof(LekarskeSluzby))]
        public int LekarskeSluzbyID { get; set; }

    }
}
