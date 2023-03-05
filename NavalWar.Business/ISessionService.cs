using NavalWar.DTO.GameDto;

namespace NavalWar.Business
{
    public interface ISessionService
    {
        public string GetGameName();
        public SessionDto NewSession();
        public SessionDto GetSessionById(int id);
        public void sauvegarde(SessionDto session);
    }
}
