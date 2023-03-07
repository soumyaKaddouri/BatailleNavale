using Microsoft.EntityFrameworkCore;
using NavalWar.DAL.Models;
using NavalWar.DTO.GameDto;
using System.Text.Json;

namespace NavalWar.DAL.Repository.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        private readonly NavalContext _context;
        public SessionRepository(NavalContext context)
        {
            _context = context;
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
                Session session = _context.Sessions.Find(id);
                return session.ToDto(); 
            }
            catch (Exception)
            {
                throw;
            }
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

        public void UpdateSessionDal(SessionDto newSession)
        {
            try
            {
                var session = _context.Sessions.Find(newSession.Id);
                if (session != null)
                {
                    session.Id = newSession.Id;
                    session.GameState = session.GameState;
                    
                    if (newSession.GameName != null)
                        session.GameName = newSession.GameName;
                    
                    session.joueurid = newSession.joueurid;
                    
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    
                    if (newSession.Players != null)
                        session._playersJson = JsonSerializer.Serialize(newSession.Players, options);
                    
                    _context.SaveChanges();
                }
                
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
