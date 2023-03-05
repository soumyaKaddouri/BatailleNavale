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
        public int AddPlayerDal(PlayerDto playerDto);
        public void UpdatePlayer(PlayerDto newPlayerDto);
        public void RemovePlayerDal(int id);
    }

}
