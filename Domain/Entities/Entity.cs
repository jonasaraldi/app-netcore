using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public Entity(long id)
        {
            SetId(id);
            SetCreatedDate(DateTime.Now);
            Errors = new List<string>();
        }

        public DateTime CreatedDate { get; private set; }

        [NotMapped]
        public ICollection<string> Errors { get; private set; }

        public long Id { get; private set; }

        public void AddError(string error) => Errors.Add(error);

        public bool IsValid() => !Errors.Any();

        private void SetCreatedDate(DateTime createdDate) => CreatedDate = createdDate;

        private void SetId(long id) => Id = id;
    }
}