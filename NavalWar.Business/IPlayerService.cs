using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.Business
{
   public interface IPlayerService
    {
        public GameMapDto? GetGameMap(int id_joueur, int id_session);
        public GameMapDto? GetGameMap(int gameMapId);
        public GameMapDto? GetGameMap();
        public PlayerDto ajout_bateau(PlayerDto player, GetbateauDto r);
        public List<PlayerDto> Shoot(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);
        public int prochainjoueur(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);

    }
}
