namespace NavalWar.DTO.WebDto
{
    public class GetbateauDto
    {
        public int startOffsetX;
        public int startOffsetY;
        public int direction ;      // 0: up, 1: down, 2: Left, 3: Right
        public int shipLength;      // Each shipLength refers to a specific ship type

        public GetbateauDto(int x, int y, int direction, int type)
        {
            this.startOffsetX = x;
            this.startOffsetY = y;
            this.direction = direction;
            this.shipLength = type;
        }
    }
}
