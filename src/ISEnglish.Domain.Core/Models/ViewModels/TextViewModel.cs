using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.Domain.Core.Models.ViewModels
{
    public class TextViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "None")]
        public string Name { get; set; }
        [Required(ErrorMessage = "None")]
        public string Content { get; set; }

    }
}
