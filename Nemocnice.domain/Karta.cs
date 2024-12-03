﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain
{
    public class Karta
    {
        [Key]
        public int Id { get; set; }
        public string? Stav {  get; set; }

        [ForeignKey(nameof(Pacient))]
        public int PacientID { get; set; }


    }
}
