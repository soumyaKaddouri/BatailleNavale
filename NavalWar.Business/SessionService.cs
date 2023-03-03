using NavalWar.DAL.Repository.Sessions;
using NavalWar.DTO.GameDto;
namespace NavalWar.Business
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sess;
        public SessionService(ISessionRepository sess)
        {
            _sess = sess;
        }
        public string GetGameName() 
        {
            string s = "";
            return s;
        }
        public SessionDto NewSession()
        {
            var _session = _sess.NewSessionDal();
            return _session;
             
        }
        public SessionDto AjoutJoueur(int id_session, PlayerDto playerDto)
        {
            var _session = _sess.NewSessionDal();
            return _session;

        }

        public SessionDto GetSessionById(int id)
        {
            var _session = _sess.GetSessionByIdDal(id);
            return _session;
        }
        static  PlayerDto GetGamePlayer(SessionDto Session ,int playerId)
        {
            return Session.Players[playerId];
        }
        
    }
}
