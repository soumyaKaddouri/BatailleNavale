using Microsoft.AspNetCore.Mvc;
using NavalWar.Business;
using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;



namespace NavalWar.API.Controllers
{
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sess;
        private readonly IPlayerService _play;
        public SessionController(ISessionService sess,IPlayerService play)
        {
            _sess = sess;
            _play = play;
        }

        // GET: api/<GameAreaController>
        [HttpGet("NouvellePartie")]
        public IActionResult NouvellePartie()
        {
            var session = _sess.NewSession();
            return Ok(session.GetId());
        }
        [HttpGet("Sessions/{id}")]
        public IActionResult GetSession(int id)
        {
            var session = _sess.GetSessionById(id);
            return Ok(session);
        }
        [HttpGet("Sessions/{id}/joueuractif")]
        public IActionResult Getjoueur(int id)
        {
            var session = _sess.GetSessionById(id);
            return Ok(session.joueurid);
        }


        [HttpPost("/RejoindreUneSession")]
        public IActionResult AjoutJoueur([FromBody] int id, string playername)
        {
            var session = _sess.GetSessionById(id);
            try
            {
                
                PlayerDto player = new PlayerDto();
                player.Name = playername;
                player.IdSession = id;
                player.PlayerBoards = new GameMapDto();
                session.AddPLayerWeb(player);
                int idPlayer = _play.AddPlayer(player);
                if (session.joueurid ==0)
                    session.joueurid = idPlayer;
                _sess.sauvegarde(session);
                return Ok(idPlayer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET api/<GameAreaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameAreaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameAreaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameAreaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}