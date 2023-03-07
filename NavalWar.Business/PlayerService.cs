using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;
using Microsoft.AspNetCore.Http.HttpResults;
using NavalWar.DAL.Models;
using System.Numerics;

namespace NavalWar.Business
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _play;
        
        public PlayerService(IPlayerRepository play)
        {
            _play = play;
        }
        
        public PlayerDto GetPlayerById(int id)
        {
            PlayerDto player = _play.GetPlayerByIdDal(id);
            return player;
        }

        public GameMapDto? GetGameMap(int Id)
        {
            GameMapDto game = _play.GetPlayerByIdDal(Id).PlayerBoards;
            return game;
            

        }

        public PlayerDto ajout_bateau(PlayerDto player, GetbateauDto r)
        {
            if (player.etat_joueur == 0)
            {

            }
            return player;
        }
        
        public PlayerDto ajout_bateau(PlayerDto player, int id_Session)
        {
            return new PlayerDto();
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
            else
            {
                throw new Exception("tire hors-porté");
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

        public int AddPlayer(PlayerDto player)
        {
            return _play.AddPlayerDal(player);
            
        }

        public void DeletePlayer(int id)
        {
            _play.RemovePlayerDal(id);
        }

        public void UpdatePlayer(PlayerDto player)
        {
            _play.UpdatePlayerDal(player);
        }

        public PlayerDto AddShipToGrid(PlayerDto player, GetbateauDto r)
        {
            if (TestShipPlacement(player ,r.startOffsetX, r.startOffsetY, r.shipLength, r.direction))
            {
                return PlaceShip(player ,r.startOffsetX, r.startOffsetY, r.shipLength, r.direction);
            }
            else
            {
                throw new Exception("Placement de bateau invalide. Veuillez choisir une position et une direction valides.");
            }
        }

        public PlayerDto UpdateShipInGrid(PlayerDto player, GetbateauDto actualShip, GetbateauDto newShip)
        {
            if (ShipExists(player, actualShip.startOffsetX, actualShip.startOffsetY, actualShip.shipLength, actualShip.direction))
            {
                var UpdatedPlayer = AddShipToGrid(player, newShip);
                return UpdatedPlayer;
            }
            else
            {
                throw new Exception("Placement de bateau invalide. Veuillez choisir une position et une direction valides.");
            }
        }

        /*public bool RemoveShipFromGrid(PlayerDto player, GetbateauDto Ship)
        {

            if (ShipExists(player, Ship.startOffsetX, Ship.startOffsetY, Ship.shipLength, Ship.direction))
            {
                RemoveShip(Ship.startOffsetX, Ship.startOffsetY, Ship.shipLength, Ship.direction);
            }
            else
            {
                result = true;
                Console.WriteLine("Error: Cannot add this ship. You're outside the map");
            }

            return result;
        }*/

        public void RemoveShip(PlayerDto player, int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            if (direction == 1)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY + k] = 0;
                }
            }
            else if (direction == 2)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY - k] = 0;
                }
            }
            else if (direction == 3)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX - k][startOffsetY] = 0;
                }
            }
            else if (direction == 4)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX + k][startOffsetY] = 0;
                }
            }
        }

        public bool TestShipPlacement(PlayerDto player,int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            bool result = true;
            int Width = player.PlayerBoards.ShipPositionsBoard.Width;
            int Height = player.PlayerBoards.ShipPositionsBoard.Height;
            
            if (startOffsetX < 0 || startOffsetX > Width - 1 || startOffsetY < 0 || startOffsetY > Height - 1)
            {
                result = false;
            }
            else
            {
                if (direction == 1)
                {
                    if (startOffsetY + shipLength - 1 > Height - 1)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY + k] == 1)
                            {
                                result = false;
                            }
                        }
                    }
                }
                else if (direction == 2)
                {
                    if (startOffsetY - shipLength + 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY - k] == 1)
                            {
                                result = false;
                            }
                        }
                    }
                }
                else if (direction == 3)
                {
                    if (startOffsetX - shipLength + 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX - k][startOffsetY] == 1)
                            {
                                result = false;
                            }
                        }
                    }
                }
                else if (direction == 4)
                {
                    if (startOffsetX + shipLength - 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX + k][startOffsetY] == 1)
                            {
                                result = false;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public PlayerDto PlaceShip(PlayerDto player, int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            if (direction == 1)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY + k] = 1;
                }
            }
            else if (direction == 2)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY - k] = 1;
                }
            }
            else if (direction == 3)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX - k][startOffsetY] = 1;
                }
            }
            else if (direction == 4)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX + k][startOffsetY] = 1;
                }
            }
            return player;
        }

        public bool ShipExists(PlayerDto player, int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            bool result = true;

            var Width = player.PlayerBoards.ShipPositionsBoard.Width;
            var Height = player.PlayerBoards.ShipPositionsBoard.Height;

            if (startOffsetX < 0 || startOffsetX > Width - 1 || startOffsetY < 0 || startOffsetY > Height - 1)
            {
                if (direction == 1)
                {
                    if (startOffsetY + shipLength - 1 > Height - 1)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY + k] == 0)
                            {
                                result = false;
                            }
                        }
                    }
                }
                else if (direction == 2)
                {
                    if (startOffsetY - shipLength + 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX][startOffsetY - k] == 0)
                            {
                                result = false;
                            }
                        }
                    }
                }
                else if (direction == 3)
                {
                    if (startOffsetX - shipLength + 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX - k][startOffsetY] == 0)
                            {
                                result = false;
                            }
                        }
                    }
                }
                else if (direction == 4)
                {
                    if (startOffsetX + shipLength - 1 < 0)
                    {
                        result = false;
                    }
                    else
                    {
                        for (int k = 0; k < shipLength; k++)
                        {

                            if (player.PlayerBoards.ShipPositionsBoard.Grid[startOffsetX + k][startOffsetY] == 0)
                            {
                                result = false;
                            }
                        }
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
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
