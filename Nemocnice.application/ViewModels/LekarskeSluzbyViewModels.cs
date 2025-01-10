﻿using System;

namespace Nemocnice.application.ViewModels
{
    public class LekarskeSluzbyViewModel
    {
        public int Id { get; set; }
        public string? Ukon { get; set; }
        public string? Ockovani { get; set; }
        public string? Vysetreni { get; set; }
        public DateTime Datum { get; set; }
        public string? Budova { get; set; }
        public string? Mistnost { get; set; }
    }

    public class LekarskeSluzbyViewModels
    {
        public IList<LekarskeSluzbyViewModel>? LekarskeSluzby { get; set; }
    }
}