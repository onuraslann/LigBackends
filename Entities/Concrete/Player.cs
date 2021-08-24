using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Player:IEntity
    {


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TeamsId { get; set; }

        public int Number { get; set; }

        public string PositionName { get; set; }

        public int Age { get; set; }

        public int LeagueId { get; set; }


    }
}
