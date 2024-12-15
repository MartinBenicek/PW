using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain.Entities.Interfaces
{
    internal interface IUser<TKey> : IEntity<TKey>
    {
        public string? Jmeno { get; set; }
        public string? Prijmeni { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Heslo { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public string? role { get; set; }
    }
}
