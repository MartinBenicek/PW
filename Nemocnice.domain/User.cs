﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nemocnice.domain
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Jmeno { get; set; }
        public string? Prijmeni { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Heslo { get; set; }
        public DateTime DatumNarozeni { get; set; }

    }
}