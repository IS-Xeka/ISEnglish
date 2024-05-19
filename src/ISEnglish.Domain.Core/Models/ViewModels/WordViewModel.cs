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
        [DataType(DataType.Text)]
        public string ? Transcription {get; set;}
        [Required(ErrorMessage = "None")]
        [DataType(DataType.Text)]
        [StringLength(80, MinimumLength = 1)]
        public string RusTitle { get; set; }
        [Required(ErrorMessage = "None")]
        [DataType(DataType.Text)]
        [StringLength(80, MinimumLength = 1)]
        public string EngTitle { get; set; }


    }
}
