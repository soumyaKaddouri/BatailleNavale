using NavalWar.DTO.GameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
