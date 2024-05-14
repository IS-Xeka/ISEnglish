using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace ISEnglish.Domain.Core.Models
{
    public class Category
    {
        public const int MAX_LENGTH = 50;
        [Key]
        public Guid Id { get; set; }

        public string Name { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        private Category(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static Result<Category> Create(Guid id, string name, string description)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                return Result.Failure<Category>("Properties can not be Empty");
            }

            var category = new Category(id, name, description);

            return Result.Success<Category>(category);
        }
    }
}
