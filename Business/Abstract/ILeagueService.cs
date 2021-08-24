using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ILeagueService
    {
        IDataResult<List<League>> GetAll();

        IResult Add(League league);

        IResult Delete(League league);
    }
}
