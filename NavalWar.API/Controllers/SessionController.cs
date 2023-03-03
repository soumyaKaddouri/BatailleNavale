using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NavalWar.Business;
using NavalWar.DTO.GameDto;
using NavalWar.DAL.Repository.Sessions;
using NavalWar.DAL.Repository.Players;


namespace NavalWar.API.Controllers
{
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _sess;
        public SessionController( ISessionRepository sess)
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