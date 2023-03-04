using NavalWar.DAL.Models;
using NavalWar.DTO.GameDto;
namespace NavalWar.DAL.Repository.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        private readonly NavalContext _context;
        public SessionRepository(NavalContext context)
        {
            _context = context;
        }
        public SessionDto NewSessionDal()
        {
            try
            {
                Session session = new Session();

                _context.Sessions.Add(session);
                _context.SaveChanges();
                return session.ToDto();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public List<SessionDto> GetSessions()
        {
            try
            {
                List<SessionDto> sessions = new List<SessionDto>();
                var rawSessions = _context.Sessions;

                foreach (Session s in rawSessions)
                {
                    sessions.Add(s.ToDto());
                }

                return sessions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SessionDto? GetSessionByIdDal(int id)
        {
            try
            {
                Session session = _context.Sessions.First(x => x.Id == id);
                return session.ToDto(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddSession(Session session)
        {
            try
            { 
               
                _context.Sessions.Add(session);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSessionDal(Session newSession)
        {
            try
            {
                RemoveSession(newSession.Id);
                AddSession(newSession);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveSession(int id)
        {
            try
            {
                Session session = _context.Sessions.Find(id);
                if (session != null)
                {
                    _context.Sessions.Remove(session);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
