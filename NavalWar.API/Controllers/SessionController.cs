using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NavalWar.Business;
using NavalWar.DTO.GameDto;

namespace NavalWar.API.Controllers
{
    public class SessionController : ControllerBase
    {
        private readonly  ISessionService _gameService;
        public SessionController(ISessionService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/<GameAreaController>
        [HttpGet("NouvellePartie")]
        public IActionResult NouvellePartie()
        {
            _gameService.NewSession();
            return Ok(_gameService.GetSession().GetId());
        }
        [HttpPost("{id}/PlayerSession")] 
        public IActionResult GetPlayerBoards(int id)
        {

            _gameService.GetSession().AddPLayer();
            List<PlayerDto> dto = new List<PlayerDto>();
            foreach (var player in dto)
            {
                dto.Add(new PlayerDto
                {

                    _playerBoards = player.GetBoards

                });
            }

            return Ok(dto);
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

