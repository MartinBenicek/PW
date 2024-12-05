using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain
{
    [Table(nameof(UserRole))]
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleID { get; set; }


    }
}
