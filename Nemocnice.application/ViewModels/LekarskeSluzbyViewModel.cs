﻿using Nemocnice.domain.Validations;

namespace Nemocnice.application.ViewModels
{
    public class LekarskeSluzbyViewModel
    {
        public int LekarskeSluzbyId { get; set; }
        public string Ukon { get; set; }
        public string? Vysetreni { get; set; }
        public string? Ockovani { get; set; }

        [FutureDate]
        public DateTime Datum { get; set; } = DateTime.Now;
    }
}
