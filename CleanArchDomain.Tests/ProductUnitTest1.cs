using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {

        [Fact(DisplayName = "Creates product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "any_product", "any_description", 77.77m, 100, "any_image");

            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "It does not create category with invalid parameters")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionValidation()
        {
            Action action = () => new Product(-11, "any_product", "any_description", 77.77m, 100, "any_image");

            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "an", "any_description", 77.77m, 100, "any_image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name length. It must be greater than 3.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongName()
        {
            Action action = () => new Product(1, "any_product", "any_description", 77.77m, 100, "any_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaaany_imageaaaaaaaaaaa");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid image. It must be lower than 250 characters.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "any_product", "any_description", 77.77m, 100, null);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Theory]
        [InlineData(-7)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int stockValue)
        {
            Action action = () => new Product(1, "any_product", "any_description", 77.77m, stockValue, "any_image");

            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid stock value.");
        }

        [Theory]
        [InlineData(-77.77)]
        public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue(decimal priceValue)
        {
            Action action = () => new Product(1, "any_product", "any_description", priceValue, 100, "any_image");

            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid price value.");
        }
    }
}

