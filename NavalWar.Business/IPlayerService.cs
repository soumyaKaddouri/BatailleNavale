using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;

namespace NavalWar.Business
{
   public interface IPlayerService
    {
        public int AddPlayer(PlayerDto player);
        public PlayerDto GetPlayerById(int id);
        public void UpdatePlayer(PlayerDto Player);
        public void DeletePlayer(int Id);
        
        public GameMapDto? GetGameMap(int gameMapId);

        public PlayerDto ajout_bateau(PlayerDto player, GetbateauDto r);

        public List<PlayerDto> Shoot(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);

        public int prochainjoueur(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j);

        public PlayerDto AddShipToGrid(PlayerDto player, GetbateauDto r);
        public PlayerDto UpdateShipInGrid(PlayerDto player, GetbateauDto actualShip, GetbateauDto newShip);

        public void RemoveShip(PlayerDto player, int startOffsetX, int startOffsetY, int shipLength, int direction);
        public bool TestShipPlacement(PlayerDto player, int startOffsetX, int startOffsetY, int shipLength, int direction);
        public PlayerDto PlaceShip(PlayerDto player, int startOffsetX, int startOffsetY, int shipLength, int direction);
        public bool ShipExists(PlayerDto player, int startOffsetX, int startOffsetY, int shipLength, int direction);
    }
}
