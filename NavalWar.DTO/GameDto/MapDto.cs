using Microsoft.AspNetCore.Http.HttpResults;
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
            Width = 9;
            Height = 9;
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
