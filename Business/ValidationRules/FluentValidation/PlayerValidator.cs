using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PlayerValidator:AbstractValidator<Player>
    {
     
        public PlayerValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.Age).LessThanOrEqualTo(42);
            RuleFor(p => p.Number).LessThanOrEqualTo(99);
        }

    }
}
