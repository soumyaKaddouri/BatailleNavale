using Microsoft.AspNetCore.Mvc;
using NavalWar.Business;
using NavalWar.DTO.WebDto;



namespace NavalWar.API.Controllers
{
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sess;
        public SessionController( ISessionService sess)
        {
            _sess = sess;
        }

        // GET: api/<GameAreaController>
        [HttpGet("NouvellePartie")]
        public IActionResult NouvellePartie()
        {
            var session = _sess.NewSession();
            return Ok(session.GetId());
        }
        [HttpGet("{id}/Session")] 
        public IActionResult GetSession(int id)
        {
            var session = _sess.GetSessionById(id);
            return Ok(session);
        }


        [HttpPost("/RejoindreUneSession")]
        public IActionResult AjoutJoueur([FromBody] int id,PlayerWebDto player)
        {
            var session = _sess.GetSessionById(id);
            try
            {
                session.AddPLayerWeb(player);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(session);
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