namespace NavalWar.DTO.GameDto
{
    public class GameMapDto
    {
        public MapDto ShipPositionsBoard { get; set; }
        public MapDto ShotsBoard { get; set; }

        public GameMapDto()
        {
            ShipPositionsBoard = new MapDto();
            ShotsBoard = new MapDto();
        }

        public GameMapDto(int InWidth, int InHeight)
        {
            ShipPositionsBoard = new MapDto(InWidth, InHeight);
            ShotsBoard = new MapDto(InWidth, InHeight);
        }

        public MapDto GetShipPositionsBoard()
        {
            return ShipPositionsBoard;
        }

        public MapDto GetShotsBoard()
        {
            return ShotsBoard;
        }

        /*static GameMapDto MajMapAttaques(GameMapDto GM, MapDto MapAttaque)
        {
            GM.ShotsBoard = MapAttaque;
            return GM;
        }*/
    }
}