using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.Domain.Core.Models
{
    public class Text
    {
        private Text(Guid id, string name, string content)
        {
            Id = id;
            Name = name;
            Content = content;
        }
        public Guid Id { get;  }
        public string Name { get;  }
        public string Content { get; }

        public static Result<Text> Create(Guid id, string name, string content)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(content))
            {
                return Result.Failure<Text>("Can not be Empty!");
            }
            var text = new Text(id, name, content);
            return Result.Success<Text>(text);
        }

    }
}
