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
        public SessionDto NewSession()
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

        public SessionDto? GetSessionById(int id)
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

        public void AddSession(SessionDto sessionDto)
        {
            try
            {
                List<Player> players = new List<Player>();

                foreach (PlayerDto p in sessionDto.Players)
                {
                    Player player= new Player();  

                    players.Add(player);
                }

                Session session = new Session();
               
                _context.Sessions.Add(session);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSession(SessionDto currentSessionDto, SessionDto newSessionDto)
        {
            try
            {
                RemoveSession(currentSessionDto.Id);
                AddSession(newSessionDto);
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
