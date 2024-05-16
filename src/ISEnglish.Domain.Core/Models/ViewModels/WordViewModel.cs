using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.Domain.Core.Models.ViewModels
{
    public class WordViewModel
    {
        
        public string? Transcription {get; set;} = string.Empty;
        [Required]
        [MinLength(1)]
        public string RusTitle { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        public string EngTitle { get; set; } = string.Empty;
    }
}
