using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.GameDto
{

    public class SessionDto
    {
        static int Id { get; set; }

        static int _etat;
        public void SetId(int a)
        { 
            Id = a;
        }
        public int GetId()
        {
            return  Id;
        }
        public int GetEtat()
        {
            return _etat;
        }
        List<PlayerDto> _players = new List<PlayerDto>();

        public List<PlayerDto> Players
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
            _players.Add(new PlayerDto());
        }
        public SessionDto()
        {
            _etat = 0;
            Id++;
        }
    }
}

