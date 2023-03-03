using NavalWar.DTO.GameDto;


namespace NavalWar.DAL.Repository.Sessions
{
    public interface ISessionRepository
    {
        public List<SessionDto> GetSessions();
        public SessionDto? GetSessionById(int id);
        public SessionDto NewSession();
        public void AddSession(SessionDto sessionDto);
        public void UpdateSession(SessionDto currentSessionDto, SessionDto newSessionDto);
        public void RemoveSession(int id);
    }

}
