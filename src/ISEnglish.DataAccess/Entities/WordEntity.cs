using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.DataAccess.Entities
{
    public class WordEntity
    {
        public const int MAX_LENGTH = 50;
        public Guid Id { get; set; }

        public string RusTitle { get; set; } = string.Empty;
        public string EngTitle { get; set; } = string.Empty;

        public string Transcription { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
    }
}
