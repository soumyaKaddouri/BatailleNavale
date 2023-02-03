using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NavalWar.DTO;
using NavalWar.DTO.GameDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        static int _etat;
        List<Player> _players = new List<Player>();
        public int GetId()
        { return Id; }
        public int GetEtat()
        { return _etat; }
        public List<Player> Players
        {
            get { return _players; }
        }

        public bool isGameFull()
        {
            return _players.Count == 2;
        }

        public void AddPLayer()
        {
            if (isGameFull())
            {
                throw new Exception("Game is full (Max 2 players");
            }
            _players.Add(new Player());
        }
        public Session()
        {
            _etat = 0;
        }
        public SessionDto ToDto()
        {
            SessionDto Se = new SessionDto();
            Se.SetId(Id);
            return Se;
        }
    }
}
