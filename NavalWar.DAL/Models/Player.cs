using NavalWar.DTO.GameDto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NavalWar.DAL.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public int idSession { get; set; }
        public static readonly int _boardSize = 9;

        public GameMap _playerBoards = new GameMap(_boardSize);
        public GameMap GetBoards
        {
            get { return _playerBoards; }
        }
        public PlayerDto ToDto()
        {
            PlayerDto dto = new PlayerDto();
            GameMapDto  _playerBoardsDto = _playerBoards.ToDto();
            dto._playerBoards = _playerBoards.ToDto();
            return dto;
        }
      
        public Session? Sessions { get; set; }
        

    }
}   

