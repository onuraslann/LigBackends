using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FixtureManager : IFixtureService
    {
        IFixtureDal _fixtureDal;

        public FixtureManager(IFixtureDal fixtureDal)
        {
            _fixtureDal = fixtureDal;
        }

        public IResult Add(Fixture fixture)
        {
            fixture.MatchDate = DateTime.Now;
            _fixtureDal.Add(fixture);
            return new SuccessResult();

        }

        public IResult Delete(Fixture fixture)
        {
            _fixtureDal.Delete(fixture);
            return new SuccessResult(Messages.FixtureDelete);
        }

        public IDataResult<List<Fixture>> GetAll()
        {
            return new SuccessDataResult<List<Fixture>>(_fixtureDal.GetAll(),Messages.FixtureList);      
        
        }
    }
}
