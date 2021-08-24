using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public  class PlayerValidator:AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(p => p.Number).LessThanOrEqualTo(99).WithMessage("Numara Sayısı max 99 olur");
            RuleFor(p => p.Age).LessThanOrEqualTo(42);
            RuleFor(p => p.PositionName).NotEmpty();
        }
    }
}
