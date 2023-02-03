using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.GameDto;

namespace NavalWar.DTO.WebDto
{
    internal class PlayerWebDto
    {
        public MapDto? ShipBoard { get; set; }
        public MapDto? ShotBoard { get; set; }

    }
}
