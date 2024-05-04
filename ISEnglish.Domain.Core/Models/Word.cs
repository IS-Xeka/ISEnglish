namespace ISEnglish.Domain.Core.Models
{
    public class Word
    {
        public const int MAX_LENGTH = 50;
        public Guid Id { get; }

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

        public static (Word word, string Error) Create(Guid id, string rusTitle, string engTitle, string transcription, string categoryName)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(rusTitle) || string.IsNullOrEmpty(engTitle) || string.IsNullOrEmpty(transcription) || string.IsNullOrEmpty(categoryName))
            {
                error = "Properties can not be Empty";
            }

            var word = new Word(id, rusTitle, engTitle, transcription, categoryName);

            return (word, error);
        }
    }
}
