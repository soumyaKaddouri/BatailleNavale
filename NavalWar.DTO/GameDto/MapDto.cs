using NavalWar.DTO.WebDto;

namespace NavalWar.DTO.GameDto
{
    public class MapDto
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public double[][] Grid { get; set; }

        public MapDto()
        {
            Width = 10;
            Height = 10;
            InitializeGrid(Width, Height);
        }

        public MapDto(int InWeight, int InHeight)
        {
            InitializeGrid(InWeight, InHeight);
        }

        /*static MapDto MAJgrille(MapDto MapAttaque, int i, int j, double value)
        {
            MapAttaque.Grille[i][j] = value;
            return MapAttaque;
        }*/

        public bool AddShipToGrid(GetbateauDto r)
        {
            bool result = true;

            if (TestShipPlacement(r.startOffsetX, r.startOffsetY, r.shipLength, r.direction))
            {
                PlaceShip(r.startOffsetX, r.startOffsetY, r.shipLength, r.direction);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool UpdateShipInGrid(GetbateauDto r,GetbateauDto rnew)
        {
            bool result = true;

            if (ShipExists(r.startOffsetX, r.startOffsetY, r.shipLength, r.direction))
            {
                result = AddShipToGrid(rnew);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool RemoveShipFromGrid(GetbateauDto r)
        {
            bool result = true;

            if (ShipExists(r.startOffsetX, r.startOffsetY, r.shipLength, r.direction))
            {
                RemoveShip(r.startOffsetX, r.startOffsetY, r.shipLength, r.direction);
            }
            else
            {
                result = true;
                Console.WriteLine("Error: Cannot add this ship. You're outside the map");
            }

            return result;
        }

        private bool TestShipPlacement(int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            bool result = true;

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

                            if (Grid[startOffsetX][startOffsetY + k] == 1)
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

                            if (Grid[startOffsetX][startOffsetY - k] == 1)
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

                            if (Grid[startOffsetX - k][startOffsetY] == 1)
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

                            if (Grid[startOffsetX + k][startOffsetY] == 1)
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

        private bool ShipExists(int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            bool result = true;

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

                            if (Grid[startOffsetX][startOffsetY + k] == 0)
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

                            if (Grid[startOffsetX][startOffsetY - k] == 0)
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

                            if (Grid[startOffsetX - k][startOffsetY] == 0)
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

                            if (Grid[startOffsetX + k][startOffsetY] == 0)
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

        private void PlaceShip(int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            if (direction == 1)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX][startOffsetY + k] = 1;
                }
            }
            else if (direction == 2)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX][startOffsetY - k] = 1;
                }
            }
            else if (direction == 3)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX - k][startOffsetY] = 1;
                }
            }
            else if (direction == 4)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX + k][startOffsetY] = 1;
                }
            }
        }

        private void RemoveShip(int startOffsetX, int startOffsetY, int shipLength, int direction)
        {
            if (direction == 1)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX][startOffsetY + k] = 0;
                }
            }
            else if (direction == 2)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX][startOffsetY - k] = 0;
                }
            }
            else if (direction == 3)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX - k][startOffsetY] = 0;
                }
            }
            else if (direction == 4)
            {
                for (int k = 0; k < shipLength; k++)
                {
                    Grid[startOffsetX + k][startOffsetY] = 0;
                }
            }
        }


        private void InitializeGrid(int InWidth, int InHeight)
        {
            Grid = new double[InWidth][];

            for (int i = 0; i < InWidth; i++)
            {
                Grid[i] = new double[InHeight];

                for (int j = 0; j < InHeight; j++)
                    Grid[i][j] = 0;
            }
        }
    }
}
