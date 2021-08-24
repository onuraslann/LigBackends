using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class PlayerDetailDto:IDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Number { get; set; }
        public string TeamName { get; set; }

        public string LeagueName { get; set; }

    }
}
