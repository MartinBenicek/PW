using System;
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
        string? Jmeno { get; set; }
        string? Prijmeni { get; set; }
        string? Email { get; set; }
        string? Telefon { get; set; }
        string? Heslo { get; set; }
        DateTime DateOfBirth { get; set; }

    }
}
