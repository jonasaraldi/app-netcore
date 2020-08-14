using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.Dtos
{
    public class BaseDto
    {
        public BaseDto()
        {
            Errors = new List<string>();
        }

        public ICollection<string> Errors { get; set; }

        public void AddError(string error) => Errors.Add(error);

        public bool IsValid() => !Errors.Any();
    }
}