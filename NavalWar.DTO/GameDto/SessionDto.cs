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
        public int Id { get; set; }
        public int GameState { get; set; }
        public string GameName { get; set; }

        public int joueurid { get; set; }
        public List<PlayerDto> Players { get; set; }

        public int GetId()
        {
            return Id;
        }
        public int GetActivePlayer()
        {
            return joueurid;
        }
        public void SetId(int InId)
        {
            Id = InId;
        }

        public int GetGameState()
        {
            return GameState;
        }

        public List<PlayerDto> GetPlayers()
        {
            return Players;
        }

        public bool isGameFull()
        {
            return Players.Count == 2;
        }

        public void AddPLayer(PlayerDto InPlayer)
        {
            if (isGameFull())
            {
                throw new Exception("Game is full (Max 2 players)");
            }

            Players.Add(InPlayer);
        }
    }
}

