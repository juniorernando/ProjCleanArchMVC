using FluentAssertions;
using ProjCleanArchMVC.Domain.Entities;
using Xunit;

namespace ProjCleanArchMvc.Domain.Test
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategoy_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>();              
        }

        [Fact]
        public void CreateCategoy_WithInvalidIdValue_ResultObjectInvalidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategoy_WithShortNameValue_ResultObjectInvalidState()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<ProjCleanArchMVC.Domain.Validation.DomanExeptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }
    }
}