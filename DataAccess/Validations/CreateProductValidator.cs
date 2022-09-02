using FluentValidation;
using StokApp.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.DataAccess.Validations
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("name alanı boş bırakılamaz");
        }
    }
}
