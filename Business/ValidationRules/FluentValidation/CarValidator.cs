using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
   public  class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(500).WithMessage("Aracın günlük fiyatı 500 den büyük olmalıdır");
            
        }
    }
}
