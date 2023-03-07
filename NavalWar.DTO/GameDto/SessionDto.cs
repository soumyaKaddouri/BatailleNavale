using NavalWar.DTO.WebDto;
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
            if (Players == null )
                return false;

            return Players.Count == 2;
        }

        public void AddPlayerWeb(PlayerDto playerWeb)
        {
            if (isGameFull())
            {
                throw new Exception("Game is full (Max 2 players)");
            }

            PlayerDto player = new PlayerDto();
            
            player.Name = playerWeb.Name;
            player.IdSession = playerWeb.IdSession;
            player.PlayerBoards = playerWeb.PlayerBoards;
            
            if (Players == null)
                Players = new List<PlayerDto>();
            
            Players.Add(player);
        }

        public void AddPLayer(PlayerDto InPlayer)
        {
            if (isGameFull())
            {
                throw new Exception("Game is full (Max 2 players)");
            }
            
            if (Players == null)
                Players = new List<PlayerDto>();
            
            Players.Add(InPlayer);
        }
        
    }
}
