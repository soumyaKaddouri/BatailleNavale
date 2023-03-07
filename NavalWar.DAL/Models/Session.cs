using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NavalWar.DTO.GameDto;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace NavalWar.DAL.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public int GameState { get; set; }
        public string GameName { get; set; }
        public int joueurid { get; set; }
        public string _playersJson { get; set; }

        public Session()
        {
            GameState = 0;
            GameName = "";
            joueurid = 0;
            _playersJson = "";
        }

        public Session(SessionDto session)
        {
            Id = session.Id;
            GameState = session.GameState;
            
            if (session.GameName != null)
                GameName = session.GameName;

            joueurid = session.joueurid;

            var options = new JsonSerializerOptions { WriteIndented = true };
            
            if (session.Players != null)
                _playersJson = JsonSerializer.Serialize(session.Players, options);
        }

        public int GetId()
        {
            return Id;
        }

        public SessionDto ToDto()
        {
            SessionDto session = new SessionDto();
            
            session.Id = Id;
            session.GameState = GameState;
            session.GameName = GameName;
            session.joueurid = joueurid;
            
            if (_playersJson != "")
                session.Players = JsonSerializer.Deserialize<List<PlayerDto>>(_playersJson);

            return session;
        }
    }
}
