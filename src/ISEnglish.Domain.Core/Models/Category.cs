using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.Domain.Core.Models
{
    public class Category
    {
        public const int MAX_LENGTH = 50;
        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        private Category(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static (Category category, string Error) Create(Guid id, string name, string description)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                error = "Properties can not be Empty";
            }

            var category = new Category(id, name, description);

            return (category, error);
        }
    }
}
