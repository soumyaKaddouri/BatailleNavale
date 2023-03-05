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
        public int Id { get; set; }
        public string Name { get; set; }

        public int etat_joueur { get; set; }
        // Foreign Key
        public int IdSession { get; set; }


        public GameMapDto? PlayerBoards { get; set; }

        public GameMapDto GetPlayerBoards()
        {
            return PlayerBoards;
        }
         
    }
}
