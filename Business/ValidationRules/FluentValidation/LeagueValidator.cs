using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class LeagueValidator:AbstractValidator<League>
    {
        public LeagueValidator()
        {
            RuleFor(l => l.LeagueName).NotEmpty();
        }
    }
}
