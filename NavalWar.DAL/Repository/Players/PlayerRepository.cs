using NavalWar.DAL.Models;
using NavalWar.DTO.GameDto;
namespace NavalWar.DAL.Repository.Players
{
    public class PlayerRepository : IPlayerRepository
    {
        public readonly NavalContext _context;
        public PlayerRepository(NavalContext context)
        {
            _context = context;
        }
        
        public List<PlayerDto> GetPlayers()
        {
            try
            {
                List<PlayerDto> players = new List<PlayerDto>();
                var rawPlayers = _context.Players;

                foreach (Player p in rawPlayers)
                {
                    players.Add(p.ToDto());
                }

                return players;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PlayerDto GetPlayerByIdDal(int id)
        {
            try
            {
                var player = _context.Players.FirstOrDefault(player => player.Id == id);
                return player.ToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddPlayerDal(PlayerDto playerDto)
        {
            try
            {
                Player player = new Player();
                player.IdSession =playerDto.IdSession;
                _context.Players.Add(player);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePlayer(PlayerDto currentPlayerDto, PlayerDto newPlayerDto)
        {
            try
            {
                RemovePlayer(currentPlayerDto.Id);
                AddPlayerDal(newPlayerDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemovePlayer(int id)
        {
            Player player = _context.Players.Find(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }
        }
    }
}
