﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.domain
{
    [Table(nameof(Pacient))]
    public class Pacient
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UserRole))]
        public int UserRoleID { get; set; }

    }
}