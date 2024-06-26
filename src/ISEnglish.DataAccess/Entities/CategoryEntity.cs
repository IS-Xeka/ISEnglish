﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Entities
{
    public class CategoryEntity
    {

        public const int MAX_LENGTH = 50;
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
