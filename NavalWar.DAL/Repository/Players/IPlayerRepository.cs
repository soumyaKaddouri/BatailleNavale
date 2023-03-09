using NavalWar.DTO.GameDto;

namespace NavalWar.DAL.Repository.Players
{
    public interface IPlayerRepository
    {
        public List<PlayerDto> GetPlayers();
        public PlayerDto GetPlayerByIdDal(int id);
        public int AddPlayerDal(PlayerDto playerDto);
        public void UpdatePlayerDal(PlayerDto newPlayerDto);
        public void RemovePlayerDal(int id);
    }

}
