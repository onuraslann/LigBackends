using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPlayerDal : EntityRepositoryBase<Player, LeagueContext>, IPlayerDal
    {
        public List<PlayerDetailDto> GetByDto()
        {
            using (LeagueContext context = new LeagueContext())
            {
                var result = from l in context.Leagues
                             join p in context.Players on l.Id equals p.LeagueId
                             join t in context.Teams on p.TeamsId equals t.Id
                             select new PlayerDetailDto
                             {

                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 Number = p.Number,
                                 TeamName = t.TeamName,
                                 LeagueName = l.LeagueName
                             };
                return result.ToList();
                             
            }
        }
    }
}
