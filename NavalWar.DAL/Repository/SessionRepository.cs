using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.GameDto;
namespace NavalWar.DAL.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly NavalContext _context;
        public SessionRepository(NavalContext context)
        {
            _context = context;
        }
        public SessionDto GetSession(int id)
        {
            try
            {
                var session = _context.Sessions.FirstOrDefault(x => x.GetId() == id);
                return session.ToDto(); 
            }
            catch(Exception) 
            {
                throw;
            }


        }
    }
}
