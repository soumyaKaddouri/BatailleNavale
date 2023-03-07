using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.WebDto
{
    public class GetbateauDto
    {
        public int startOffsetX;
        public int startOffsetY;
        public int direction ;      //up,down,Left,Right
        public int shipLength;      //longueur
        
        public GetbateauDto(int x, int y, int direction, int type)
        {
            this.startOffsetX = x;
            this.startOffsetY = y;
            this.direction = direction;
            this.shipLength = type;
        }
    }
}
