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
        public PlayerDto GetPlayerByIdDal(int id);
        public void AddPlayerDal(PlayerDto playerDto);
        public void UpdatePlayer(PlayerDto currentPlayerDto, PlayerDto newPlayerDto);
        public void RemovePlayer(int id);
    }

}
