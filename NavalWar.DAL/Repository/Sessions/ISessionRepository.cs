using NavalWar.DTO.GameDto;
using NavalWar.DAL.Models;

namespace NavalWar.DAL.Repository.Sessions
{
    public interface ISessionRepository
    {
        public List<SessionDto> GetSessions();
        public SessionDto? GetSessionByIdDal(int id);
        public SessionDto NewSessionDal();
        public void AddSession(Session session);
        public void UpdateSessionDal(SessionDto newSession);
        public void RemoveSession(int id);
    }

}
