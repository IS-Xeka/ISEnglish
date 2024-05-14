﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}
