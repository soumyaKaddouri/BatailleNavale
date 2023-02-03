using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.WebDto
{
    public class GetbateauDto
    {
        public int x;
        public int y;
        public string direction = "";
        public string type = "";
        public GetbateauDto(int x, int y, string direction, string type)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.type = type;
        }
    }
}
