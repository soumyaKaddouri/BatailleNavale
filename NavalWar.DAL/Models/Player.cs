using NavalWar.DTO.GameDto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace NavalWar.DAL.Models
{

    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int etat_joueur { get; set; } // 0 pas prêt, 1 pas a lui de jouer, 2 a son tour 

        // Foreign Key
        [ForeignKey("Session")]
        public int IdSession { get; set; }

        public string  _PlayerBoardsJson{ get; set; }
         public Player() {
            Id = 0;
            etat_joueur= 0;
        }

        public PlayerDto ToDto()
        {
            PlayerDto player = new PlayerDto();

            player.Id = Id;
            player.Name = Name;
            player.IdSession = IdSession;


            return player;
        }
    }
}   

