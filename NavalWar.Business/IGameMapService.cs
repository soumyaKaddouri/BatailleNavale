using NavalWar.DTO.GameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.Business
{
   public interface IGameMapService
    {
        public GameMapDto? GetGameMap(int id_joueur, int id_session);
    }
}
