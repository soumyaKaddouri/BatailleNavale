using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;

namespace NavalWar.Business
{
   public interface IPlayerService
    {
        public GameMapDto? GetGameMap(int gameMapId);
        public GameMapDto? GetGameMap();
        public PlayerDto ajout_bateau(PlayerDto player, GetbateauDto r);
        public List<PlayerDto> Shoot(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);
        public int prochainjoueur(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);

    }
}
