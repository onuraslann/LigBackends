using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LeagueManager : ILeagueService
    {
        ILeagueDal _leagueDal;

        public LeagueManager(ILeagueDal leagueDal)
        {
            _leagueDal = leagueDal;
        }

        [ValidationAspect(typeof(LeagueValidator))]
        public IResult Add(League league)
        {
            _leagueDal.Add(league);
            return new SuccessResult(Messages.LeagueAdded);
        }

        public IResult Delete(League league)
        {
            _leagueDal.Delete(league);
            return new SuccessResult();
        }

        public IDataResult<List<League>> GetAll()
        {
            return new SuccessDataResult<List<League>>(_leagueDal.GetAll(), "Listeleme başarılı");
        }
    }
}
