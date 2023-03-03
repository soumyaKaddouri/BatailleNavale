using NavalWar.DTO.GameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL.Repository.Players
{
    public interface IPlayerRepository
    {
        public List<PlayerDto> GetPlayers();
        public PlayerDto GetPlayerById(int id);
        public void AddPlayer(PlayerDto playerDto);
        public void UpdatePlayer(PlayerDto currentPlayerDto, PlayerDto newPlayerDto);
        public void RemovePlayer(int id);

        public GameMapDto GetGameMaps(int id_play);
    }

}
