using FluentAssertions;
using ProjCleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjCleanArchMvc.Domain.Test
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_withValidParameters_ResultObjectValidState()
        { 
            Action action = () => new Product(1, "Product Name", "Description", 9.99m, 99, "Product Image");
            action.Should().NotThrow<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>();
        }


        [Fact]
        public void CreateProduct_withInvalidIdValue_ResultObjectInvalidState()
        {
            Action action = () => new Product(-1, "Product Name", "Description", 9.99m, 99, "Product Image");
            action.Should().Throw<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_withShortNameValue_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Pr", "Description", 9.99m, 99, "Product Image");
            action.Should().Throw<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_withShortDescriptionValue_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 9.99m, 99, "Product Image");
            action.Should().Throw<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>().WithMessage("Invalid description. Too short, minimum 5 characters");
        }

        [Fact]
        public void CreateProduct_withInvalidPriceValue_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "Description", -9.99m, 99, "Product Image");
            action.Should().Throw<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>().WithMessage("Invalid price value");
        }

        [Fact]
        public void CreateProduct_withInvalidStockValue_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "Description", 9.99m, -99, "Product Image");
            action.Should().Throw<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>().WithMessage("Invalid stock value");
        }
    }
}
