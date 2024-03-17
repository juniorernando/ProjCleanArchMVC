using ProjCleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCleanArchMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category( string name)
        {         
            ValidateName(name);
        }

        public Category(int id, string name)
        {
            DomanExeptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateName(name);
        }

        public void Update(string name)
        {
            ValidateName(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateName(string name)
        {
            DomanExeptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomanExeptionValidation.When(name.Length < 3, "Invalid name. Too short, minimum 3 characters");

            Name = name;
        }
    }
}
