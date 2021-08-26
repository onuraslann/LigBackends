using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class LeagueManager : ILeagueService
    {
        ILeagueDal _leagueDal;
        ITeamService _teamService;

        public LeagueManager(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public LeagueManager(ILeagueDal leagueDal)
        {
            _leagueDal = leagueDal;
        }

        [ValidationAspect(typeof(LeagueValidator))]
        public IResult Add(League league)
        {
            IResult result = BusinessRules.Run(CheckIfNameExist(league.LeagueName),CheckIfTeamsLimit());
            if (result != null)
            {
                return result;
            }
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
        private IResult CheckIfNameExist(string name)
        {
            var result = _leagueDal.GetAll(x => x.LeagueName == name).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfTeamsLimit()
        {
            var result = _teamService.GetAll();
            if (result.Data.Count > 18)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
