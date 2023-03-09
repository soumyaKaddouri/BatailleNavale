using NavalWar.DTO.GameDto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace NavalWar.DAL.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int etat_joueur { get; set; } // 0 : Not ready, 1 : It's not your turn, 2 : It's your turn 

        [ForeignKey("Session")]
        public int IdSession { get; set; }

        public string  _PlayerBoardsJson{ get; set; }
        
        public Player() {
            Id = 0;
            etat_joueur= 0;
        }

        public Player(PlayerDto player)
        {
            Id = player.Id;
            Name = player.Name;
            etat_joueur = player.etat_joueur;
            IdSession = player.IdSession;
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            
            if (player.PlayerBoards!=null)
                _PlayerBoardsJson = JsonSerializer.Serialize(player.PlayerBoards, options);
        }

        public PlayerDto ToDto()
        {
            PlayerDto player = new PlayerDto();

            player.Id = Id;
            player.Name = Name;
            player.etat_joueur = etat_joueur;
            player.IdSession = IdSession;
            
            if (_PlayerBoardsJson!= null) 
                player.PlayerBoards = JsonSerializer.Deserialize<GameMapDto>(_PlayerBoardsJson);

            return player;
        }
    }
}   
