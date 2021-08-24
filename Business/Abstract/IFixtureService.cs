using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFixtureService
    {

        IDataResult<List<Fixture>> GetAll();

        IResult Add(Fixture fixture);

        IResult Delete(Fixture fixture);


    }
}
