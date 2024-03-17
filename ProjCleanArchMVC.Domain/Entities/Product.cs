using ProjCleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCleanArchMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string imagem)
        {
            ValidateDomain(name, description, price, stock, imagem);
          
        }

        public Product(int id, string name, string description, decimal price, int stock, string imagem)
        {
            DomanExeptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, imagem);
        }

        public void Update(string name, string description, decimal price, int stock, string imagem)
        {
            ValidateDomain(name, description, price, stock, imagem);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string imagem)
        {
            DomanExeptionValidation.When(string.IsNullOrEmpty(Name), "Invalid name. Name is required");
            DomanExeptionValidation.When(Name.Length < 3, "Invalid name. Too short, minimum 3 characters");
            DomanExeptionValidation.When(string.IsNullOrEmpty(Description), "Invalid description. Description is required");
            DomanExeptionValidation.When(Description.Length < 5, "Invalid description. Too short, minimum 5 characters");
            DomanExeptionValidation.When(Price < 0, "Invalid price value");
            DomanExeptionValidation.When(Stock < 0, "Invalid stock value");
            DomanExeptionValidation.When(Image?.Length > 250, "Invalid image. Image is required");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = imagem;

        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
