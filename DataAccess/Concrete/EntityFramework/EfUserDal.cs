using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EntityRepositoryBase<User, LeagueContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (LeagueContext context  = new LeagueContext())
            {
                var result = from operationclaims in context.OperationClaims
                             join useroperationclaims in context.UserOperationClaims
                             on operationclaims.Id equals useroperationclaims.OperationClaimId
                             join u in context.Users
                             on useroperationclaims.UserId equals u.Id
                             select new OperationClaim
                             {

                                 Id = operationclaims.Id,

                                 Name = operationclaims.Name
                             };
                return result.ToList();

            }
           
            
        }
    }
}
