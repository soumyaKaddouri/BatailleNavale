using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
namespace NavalWar.DTO.GameDto
{
    public class PlayerDto
    {
        [Key]
        public GameMapDto? _playerBoards;
        public GameMapDto? GetBoards
        {
            get
            {
                return _playerBoards;
            }
        }
    }
}
