using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NavalWar.DTO.GameDto
{
    public class MapDto
    {
        private readonly int _boardsize = 10;

        public double[][] Grille { get; set; }
        static MapDto MAJgrille(MapDto MapAttaque, int i, int j, double value)
        {
            MapAttaque.Grille[i][j] = value;
            return MapAttaque;
        }
        public bool TestEmplacement(MapDto MapNavires, int i, int j, string direction, string _typeBateau) //1 Nord/ 2 Sud/ 3 Ouest/ 4 Est
        {
            if (_typeBateau is null)
            {
                throw new ArgumentNullException(nameof(_typeBateau));
            }

            MapDto map = MapNavires;
            bool test = true;
            int Longueur = 0;//fonction qui passe _typeBateau en int
            if (direction == "1")
            {
                if (i - Longueur < 0)
                {
                    test = false;
                }
                else
                {
                    for (int k = 0; k < Longueur; k++)
                    {

                        if (MapNavires.Grille[i - k][j] == 1)
                        {
                            test = false;
                        }
                        else
                        {
                            map.Grille[i - k][j] = 1;
                        }
                    }
                }
            }
            else if (direction == "2")
            {
                if (i + Longueur > MapNavires._boardsize)
                {
                    test = false;
                }
                else
                {
                    for (int k = 0; k < Longueur; k++)
                    {
                        if (MapNavires.Grille[i + k][j] == 1)
                        {
                            test = false;
                        }
                        else
                        {
                            map.Grille[i + k][j] = 1;
                        }
                    }
                }

            }
            else if (direction == "3")
            {
                if (j - Longueur < 0)
                {
                    test = false;
                }
                else
                {
                    for (int k = 0; k < Longueur; k++)
                    {
                        if (MapNavires.Grille[i][j - k] == 1)
                        {
                            test = false;
                        }
                        else
                        {
                            map.Grille[i][j - k] = 1;
                        }
                    }
                }
            }
            else
            {
                if (j + Longueur >= MapNavires._boardsize)
                {
                    test = false;
                }
                else
                {
                    for (int k = 0; k < Longueur; k++)
                    {
                        if (MapNavires.Grille[i][j + k] == 1)
                        {
                            test = false;
                        }
                        else
                        {
                            map.Grille[i][j + k] = 1;
                        }
                    }
                }
            }
            if (test) { MapNavires = map; }

            return test;
        }

        public void SupressionBateau(MapDto MapNavires, int i, int j, string direction, string type) //1 Nord/ 2 Sud/ 3 Ouest/ 4 Est
        {

            int Longueur = 4;
            if (MapNavires.Grille[i][j] != 0)
            {
                int k = 0;
                int k1 = 0;
                int l = Longueur;
                if (direction == "1" || direction == "2")
                {
                    while (l != 0)
                    {
                        if (i + k < MapNavires._boardsize)
                        {
                            if (MapNavires.Grille[i + k][j] == 1)
                            {
                                MapNavires.Grille[i + k][j] = 0;
                                l--;
                                k++;
                            }
                        }
                        if (i - k1 >= 0)
                        {
                            if (MapNavires.Grille[i - k1][j] == 1)
                            {
                                MapNavires.Grille[i - k1][j] = 0;
                                l--;
                                k1++;
                            }
                        }
                    }
                }
                else
                {
                    while (l != 0)
                    {
                        if (j + k < MapNavires._boardsize)
                        {
                            if (MapNavires.Grille[i][j + k] == 1)
                            {
                                MapNavires.Grille[i][j + k] = 0;
                                l--;
                                k++;
                            }
                        }
                        if (j - k1 >= 0)
                        {
                            if (MapNavires.Grille[i][j - k1] == 1)
                            {
                                MapNavires.Grille[i][j - k1] = 0;
                                l--;
                                k1++;
                            }
                        }
                    }
                }
            }
        }
        public MapDto()
        {
            _boardsize = 10;
            double[][] _grille1 = new double[_boardsize][];
            for (int i = 0; i < _boardsize; i++)
            {
                _grille1[i] = new double[_boardsize];
            }
            for (int i = 0; i < _boardsize; i++)
            {
                for (int j = 0; j < _boardsize; j++)
                    _grille1[i][j] = 0;
            }
            Grille = _grille1;
        }
        public MapDto(int a)
        {
            _boardsize= a;
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
            Grille = grille1;
        }
    }
}
