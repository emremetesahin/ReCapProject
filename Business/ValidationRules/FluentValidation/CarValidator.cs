using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {   
        public CarValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThan(200).When(p => p.ModelYear>2015);
            RuleFor(p => p.Description).Must(ContainGearType).WithMessage("Ürün açıklamasında vites bilgisi yazılmalı");
        }

        private bool ContainGearType(string arg)
        {
            return arg.ToLower().Contains("vites");
        }
    }
}
