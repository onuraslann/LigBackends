using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPlayerService
    {
        IDataResult<List<Player>> GetAll();

        IResult Add(Player player);

        IDataResult<List<Player>> GetByTeamId(int id);

        IDataResult<List<Player>> GetByAge(int age);

        IResult Delete(Player player);
    }
}
