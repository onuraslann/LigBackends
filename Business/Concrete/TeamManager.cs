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
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        [ValidationAspect(typeof(TeamValidator))]
        public IResult Add(Team team)
        {
            IResult result = BusinessRules.Run(CheckIfTeamNameExist(team.TeamName));
            if (result != null)
            {
                return result;
            }
            _teamDal.Add(team);
            return new SuccessResult(Messages.TeamAdded);
        }

        public IResult Delete(Team team)
        {
            _teamDal.Delete(team);
            return new SuccessResult();
        }

        public IDataResult<List<Team>> GetAll()
        {
            return new SuccessDataResult<List<Team>>(_teamDal.GetAll(),Messages.TeamList);
        }

        public IDataResult<List<Team>> GetByLeagueId(int leagueid)
        {
            return new SuccessDataResult<List<Team>>(_teamDal.GetAll(x=>x.LeagueId==leagueid), Messages.TeamList);
        }
        private IResult CheckIfTeamNameExist(string name)
        {
            var result = _teamDal.GetAll(x => x.TeamName == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
