﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Entities
{
    public class WordEntity
    {
        public const int MAX_LENGTH = 50;

        [Key]
        public Guid Id { get; set; }

        public string RusTitle { get; set; }
        public string EngTitle { get; set; }

        public string Transcription { get; set; }
        public string CategoryName { get; set; }
    }
}
