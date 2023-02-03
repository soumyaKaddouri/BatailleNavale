namespace NavalWar.DTO.GameDto
{
    public class GameMapDto
    {
        
        public MapDto PersonalBoard { get; set; }
        public MapDto ShotsBoard { get; set; }
        public GameMapDto()
        {
            PersonalBoard = new MapDto(10);
            ShotsBoard = new MapDto();
        }

        public MapDto GetPersonalBoard
        {
            get { return PersonalBoard; }
        }
        public MapDto GetShotsBoard
        {
            get { return ShotsBoard; }
        }
        static GameMapDto MajMapAttaques(GameMapDto GM, MapDto MapAttaque)
        {
            GM.ShotsBoard = MapAttaque;
            return GM;
        }
    }
}