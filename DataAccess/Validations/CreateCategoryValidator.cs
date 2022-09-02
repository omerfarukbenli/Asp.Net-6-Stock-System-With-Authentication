using FluentValidation;
using StokApp.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.DataAccess.Validations
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().NotEmpty().WithMessage("name alanı boş bırakılamaz");
        }
    }
}
