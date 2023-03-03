using Microsoft.AspNetCore.Mvc;
using NavalWar.DTO.GameDto;
using NavalWar.DAL;
using NavalWar.Business;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;

namespace NavalWar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PlayerController : Controller
    {


        SessionDto gameArea = new SessionDto();
        private readonly IPlayerService _playerServ;
        public PlayerController(IPlayerService play)
        {
            _playerServ = play;
        }
        


        [HttpGet("/Players/{id}/GameMaps")]
        public ActionResult GetGameMaps(int id)
        {
            GameMapDto gameMaps = new GameMapDto();
            try
            { 
                gameMaps = _playerServ.GetGameMap(id);
                return View(gameMaps);
            }
            catch(Exception) 
            {
                return NotFound("Cannot find any game map");
            }
        }
        //OK
        [HttpPost("/GameMaps/{id}/Add_Ship")]
        public ActionResult Add_Ship(int id, [FromBody] GetbateauDto r)
        {
            if (gameArea.GetGameState() != 1)
            {
                bool result = _player.GetPlayerById(id).GetPlayerBoards().GetShipPositionsBoard().AddShipToGrid(r);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Ship cannot be added to the position given");
                }
            }
            else
            {
                return BadRequest("The game has already begun. You can't add more ships");
            }
        }


        [HttpPost("/GameMaps/{id}/Delete_Ship")]
        public ActionResult Delete_Ship(int id, [FromBody] GetbateauDto r)
        {
            if (gameArea.GetGameState() != 1)
            {
                bool result = gameArea.GetPlayers()[id].GetPlayerBoards().GetShipPositionsBoard().RemoveShipFromGrid(r);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Ship cannot be removed from the position given");
                }
            }
            else
            {
                return BadRequest("The game has already begun. You can't delete ships anymore");
            }
        }
    }
}