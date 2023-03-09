using NavalWar.DAL.Models;
using NavalWar.DTO.GameDto;
using System.Text.Json;

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
                var player = _context.Players.Find(id);
                return player.ToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddPlayerDal(PlayerDto playerDto)
        {
            try
            {
                Player player = new Player();
                
                player.IdSession = playerDto.IdSession;
                player.Name = playerDto.Name;
                
                var options = new JsonSerializerOptions { WriteIndented = true };
                
                if (playerDto.PlayerBoards != null)
                    player._PlayerBoardsJson = JsonSerializer.Serialize(playerDto.PlayerBoards, options);
                
                _context.Players.Add(player);
                _context.SaveChanges();
                
                return player.Id;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void UpdatePlayerDal(PlayerDto newPlayerDto)
        {
            try
            {
                var player = _context.Players.Find(newPlayerDto.Id);
                
                if (player != null)
                {
                    player.Id = newPlayerDto.Id;
                    player.Name = newPlayerDto.Name;
                    player.etat_joueur = newPlayerDto.etat_joueur;
                    player.IdSession = newPlayerDto.IdSession;
                    
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    
                    if (newPlayerDto.PlayerBoards != null)
                        player._PlayerBoardsJson= JsonSerializer.Serialize(newPlayerDto.PlayerBoards, options);
                    
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemovePlayerDal(int id)
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
