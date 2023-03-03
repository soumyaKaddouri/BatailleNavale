using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public PlayerDto GetPlayerById(int id)
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

        public void AddPlayer(PlayerDto playerDto)
        {
            try
            {
                Player player = new Player();

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
                AddPlayer(newPlayerDto);
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
        public GameMapDto GetGameMaps(int id_play)
        {
            GameMapDto maps = new GameMapDto();
            maps = GetPlayerById(id_play).GetPlayerBoards();
            return maps;

        }
    }
}
