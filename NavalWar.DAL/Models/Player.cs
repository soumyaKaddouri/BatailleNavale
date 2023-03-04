using NavalWar.DTO.GameDto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public Player(PlayerDto player)
        {
            Id = player.Id;
            Name = player.Name;
            etat_joueur= player.etat_joueur;
            IdSession= player.IdSession;
            var options = new JsonSerializerOptions { WriteIndented = true };
            _PlayerBoardsJson = JsonSerializer.Serialize(player.PlayerBoards, options);
        }
        public PlayerDto ToDto()
        {
            PlayerDto player = new PlayerDto();

            player.Id = Id;
            player.Name = Name;
            player.IdSession = IdSession;
            player.etat_joueur= etat_joueur;
            player.PlayerBoards = JsonSerializer.Deserialize<GameMapDto>(_PlayerBoardsJson);

            return player;
        }
    }
}   

