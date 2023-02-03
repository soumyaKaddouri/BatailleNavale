using NavalWar.DTO.GameDto;
namespace NavalWar.Business
{
    public class SessionService : ISessionService
    {
        static SessionDto? _session;
        public SessionDto? GetSession()
        {
            return _session;
        }
        public string GetGameName() 
        {
            string s = "";
            return s;
        }
        public SessionDto NewSession()
        {
            _session = new SessionDto();
            return _session;
             
        }
        static  PlayerDto GetGamePlayer(SessionDto Session ,int playerId)
        {
            return Session.Players[playerId];
        }
        
    }
}
