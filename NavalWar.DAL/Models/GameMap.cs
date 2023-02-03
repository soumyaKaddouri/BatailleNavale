using NavalWar.DTO.GameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL.Models
{
    public class GameMap
    {
        public Map _personalBoard { get; set; }
        public Map _shotsBoard { get; set; }

        public GameMap(int _boardSize)
        {
            _personalBoard = new Map(_boardSize);
            _shotsBoard = new Map(_boardSize);
        }
        public Map GetPersonalBoard
        {
            get { return _personalBoard; }
        }
        public Map GetShotsBoard
        {
            get { return _shotsBoard; }
        }
        public GameMapDto ToDto()
        {
            GameMapDto dto = new GameMapDto();
            return dto;
        }
    }
}
