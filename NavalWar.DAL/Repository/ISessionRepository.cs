using NavalWar.DTO.GameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL.Repository
{
    public interface ISessionRepository
    {
        public SessionDto GetSession(int id);
    }

}
