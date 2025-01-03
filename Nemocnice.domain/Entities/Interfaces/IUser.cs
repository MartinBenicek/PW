﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.domain.Validations;

namespace Nemocnice.domain.Entities.Interfaces
{
    public interface IUser<TKey> : IEntity<TKey>
    {
        string? UserName { get; set; }
        string? Email { get; set; }
        string? PhoneNumber { get; set; }
        [FirstLetterCapitalizedCZ]
        string? FirstName { get; set; }
        string? LastName { get; set; }
    }
}
