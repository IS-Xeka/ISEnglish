using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace ISEnglish.Domain.Core.Models
{
    public class Word
    {
        public const int MAX_LENGTH = 50;
        [Key]
        public Guid Id { get; set; }

        public string RusTitle { get; } = string.Empty;
        public string EngTitle { get; } = string.Empty;

        public string Transcription { get; } = string.Empty;

        public string CategoryName { get; } = string.Empty;

        private Word(Guid id, string rusTitle, string engTitle, string transcription, string categoryName)
        {
            Id = id;
            RusTitle = rusTitle;
            EngTitle = engTitle;
            Transcription = transcription;
            CategoryName = categoryName;
        }

        public static Result<Word> Create(Guid id, string rusTitle, string engTitle, string transcription, string categoryName)
        {
            if (string.IsNullOrEmpty(rusTitle) || string.IsNullOrEmpty(engTitle) || string.IsNullOrEmpty(transcription) || string.IsNullOrEmpty(categoryName))
            {
                return Result.Failure<Word>("Properties can not be Empty");
            }

            var word = new Word(id, rusTitle, engTitle, transcription, categoryName);

            return Result.Success<Word>(word);
        }
    }
}
