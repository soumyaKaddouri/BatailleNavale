using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;

namespace NavalWar.Business
{
   public interface IPlayerService
    {
        public GameMapDto? GetGameMap(int gameMapId);
        public int AddPlayer(PlayerDto player);
        public PlayerDto GetPlayerById(int id);
        public GameMapDto? GetGameMap();
        public PlayerDto ajout_bateau(PlayerDto player, GetbateauDto r);
        public List<PlayerDto> Shoot(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);
        public int prochainjoueur(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);

        public void DeletePlayer(int Id);

        public void UpdatePlayer(PlayerDto Player);
    }
}
