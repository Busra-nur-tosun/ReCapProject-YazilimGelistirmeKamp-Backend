using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(clr => clr.ColorName).MinimumLength(3).WithMessage("RENK ADI EN AZ 3 KARAKTER OLMALI");
        }
    }
}
