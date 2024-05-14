using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISEnglish.Domain.Core.Models
{
    public class Test
    {
        private Test(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public const int MAX_NAME_LENGTH = 100;
        [Key]
        public Guid Id { get; set; }
        public string Name { get; }
        public string Description {  get; }

        public static Result<Test> Create(Guid id, string name, string description)
        {

            if(string.IsNullOrEmpty(name))
            {
                return Result.Failure<Test>($"{nameof(name)} can not be Emptry!");
            }
            var testResult = new Test(id, name, description);

            return Result.Success<Test>(testResult);

        }
    }
}
