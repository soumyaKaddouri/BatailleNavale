using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;


namespace NavalWar.Business
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _play;
        public PlayerService(IPlayerRepository play)
        {
            _play = play;
        }
        public GameMapDto GetGameMap()
        {
            GameMapDto game = new GameMapDto();
            return game;
        }

        public GameMapDto? GetGameMap(int Id)
        {
            GameMapDto game = _play.GetPlayerById(Id).PlayerBoards;
            return game;

        }
        public PlayerDto ajout_bateau(PlayerDto player, GetbateauDto r)
        {
            if (player.etat_joueur == 0)
            {

            }
            return player;
        }
        public List<PlayerDto> Shoot(PlayerDto Attaquant, PlayerDto Defenseur,int i,int j)

        {
            if (i>=0 && i<= Attaquant.PlayerBoards.ShotsBoard.Width && j >= 0 && j <= Attaquant.PlayerBoards.ShotsBoard.Height)
            {
                if (Defenseur.PlayerBoards.ShipPositionsBoard.Grid[i][j] ==1)
                {
                    Defenseur.PlayerBoards.ShipPositionsBoard.Grid[i][j] = -1;
                    Attaquant.PlayerBoards.ShotsBoard.Grid[i][j] = 1;
                }
                else if (Defenseur.PlayerBoards.ShipPositionsBoard.Grid[i][j] == 0)
                {
                    Attaquant.PlayerBoards.ShotsBoard.Grid[i][j] = -1;
                }
                else 
                {
                }
            }
            List<PlayerDto> list = new List<PlayerDto>();
            list.Add(Attaquant);
            list.Add(Defenseur);
            return list;
        }
        public int prochainjoueur(PlayerDto Attaquant, PlayerDto Defenseur, int i, int j)
        {
            if (Defenseur.PlayerBoards.ShipPositionsBoard.Grid[i][j] == 1)
            {
                return Attaquant.Id;
            }
            else
            {
                return Defenseur.Id;
            }
        }
        /* 
         * do 
         * {
         * shoot
         * savecontext()
         * verifetatgrillebateau() change gameState
         * }
         * while ActivePlayer==prochainjoueur && gameState==1
         * ActivePlayer=prochainjoueur
         */
    }
}
