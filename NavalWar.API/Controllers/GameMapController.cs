using Microsoft.AspNetCore.Mvc;
using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;

namespace NavalWar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GameMapController : Controller
    {
        private SessionDto _area = new SessionDto();
        [HttpGet("NouvellePartie")]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Get_partie_by_id(int id)
        {

            return Ok();
        }
        [HttpPost("{id}/AjoutBateau")]
        public ActionResult Post_AjoutBateau(int id,[FromBody] GetbateauDto r)
        {
            if (_area.GetEtat() != 0)
            {
                bool result = _area.Players[id].GetBoards.GetPersonalBoard.TestEmplacement(_area.Players[id].GetBoards.GetPersonalBoard, r.x, r.y, r.direction, r.type);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("bateau mal positionné");
                }
            }
            else
            {
                return BadRequest(" la partie a commencée ");
            }
            
            
           
            
        }
        [HttpPost("{id}/SupressionBateau")]
        public ActionResult Post_SupressionBateau(int id,[FromBody] GetbateauDto r)
        {
           
            _area.Players[id].GetBoards.GetPersonalBoard.SupressionBateau(_area.Players[id].GetBoards.GetPersonalBoard, r.x, r.y, r.direction, r.type);
            return Ok();
        }
    }
}
