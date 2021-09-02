using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PlayerManager : IPlayerService
    {

        IPlayerDal _playerDal;

        public PlayerManager(IPlayerDal playerDal)
        {
            _playerDal = playerDal;
        }

        [ValidationAspect(typeof(PlayerValidator))]
        public IResult Add(Player player)
        {
           
            IResult result = BusinessRules.Run(CheckIfLeagueId(player.LeagueId), CheckIfTeamId(player.TeamsId));
            if (result != null)
            {
                return result;
            }
            _playerDal.Add(player);
            return new SuccessResult(Messages.PlayerAdded);
        }

        public IResult Delete(Player player)
        {
            _playerDal.Delete(player);
            return new SuccessResult(Messages.PlayerDeleted);
        }

        public IDataResult<List<Player>> GetAll()
        {
            return new SuccessDataResult<List<Player>>(_playerDal.GetAll());
        }

        public IDataResult<List<Player>> GetByAge(int age)
        {
            return new SuccessDataResult<List<Player>>(_playerDal.GetAll(x=> x.Age>age));
        }

        public IDataResult<List<Player>> GetByTeamId(int id)
        {
            return new SuccessDataResult<List<Player>>(_playerDal.GetAll(x=> x.TeamsId==id));
        }
        private IResult CheckIfLeagueId(int leagueId)
        {
            var result = _playerDal.GetAll(x => x.LeagueId == leagueId).Count;
            if (result > 1)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfTeamId(int teamId)
        {
            var result = _playerDal.GetAll(x => x.TeamsId == teamId).Count;
            if (result > 1)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        
    }
}
