using NavalWar.DTO.GameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL.Models
{
    public class Map
    {

        public double[][] grille { get; set; }
        
        public Map(int _boardsize)
        {
            double[][] grille1 = new double[_boardsize][];
            for (int i = 0; i < _boardsize; i++)
            {
                grille1[i] = new double[_boardsize];
            }
            for (int i = 0; i < _boardsize; i++)
            {
                for (int j = 0; j < _boardsize; j++)
                    grille1[i][j] = 0;
            }
            grille = grille1;
        }
        public Map() 
        {
            double[][] grille1 = new double[10][];
            for (int i = 0; i < 10; i++)
            {
                grille1[i] = new double[10];
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    grille1[i][j] = 0;
            }
            grille = grille1;
        }
        public MapDto ToDto()
        {
            MapDto dto= new MapDto();
            return dto;
        }
      
    }

}
