using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Fixture:IEntity
    {

        public int Id { get; set; }
        public int HomeTeamId { get; set; }

        public int GuestTeamId { get; set; }

        public DateTime MatchDate { get; set; }

    }
}
