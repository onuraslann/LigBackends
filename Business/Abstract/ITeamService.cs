using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ITeamService
    {
        IDataResult<List<Team>> GetAll();

        IResult Add(Team team);

        IDataResult<List<Team>> GetByLeagueId(int leagueid);

        IResult Delete(Team team);
    }
}
