using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public  class Team:IEntity
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public string Color { get; set; }

        public int LeagueId { get; set; }
    }
}
