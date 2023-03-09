using Microsoft.AspNetCore.Mvc;
using NavalWar.DTO.GameDto;
using NavalWar.DTO.WebDto;
using NavalWar.Business;

namespace NavalWar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PlayerController : Controller
    {
        private readonly IPlayerService _player;
        private readonly ISessionService _sess;
        
        public PlayerController(IPlayerService play, ISessionService sess)
        {
            _player = play;
            _sess = sess;
        }

        // ---------------------------- ROUTES FOR PLAYERS ----------------------------  //

        [HttpGet("/Players/{id}")]
        public ActionResult GetPlayerBy(int id)
        {

            try
            {
                var player = _player.GetPlayerById(id);
                return Ok(player);
            }
            catch (Exception)
            {
                return NotFound("Cannot find the player you asked for");
            }
        }


        [HttpPut("/Players/{id}/Is_Ready")]
        public ActionResult SetPlayerState(int id)
        {
            try
            {
                var player = _player.GetPlayerById(id);
                var session = _sess.GetSessionById(player.IdSession);
                player.etat_joueur = 1;
                if (session.Players[0].Id == player.Id)
                {
                    session.Players[0] = player;
                }
                else
                {
                    session.Players[1] = player;
                }
                _sess.sauvegarde(session);
                _player.UpdatePlayer(player);

                return Ok("Successful update");
            }
            catch (Exception)
            {
                return NotFound("Cannot find any player");
            }
        }

        [HttpPut("/Players/{id}/Shoot")]
        public ActionResult Shoot(int id, int x, int y)
        {
            int resultat;
            x = x - 4;
            y = y - 4;
            var player = _player.GetPlayerById(id);
            var session = _sess.GetSessionById(player.IdSession);
            if (session.GameState == 1)
            {
                if (session.joueurid == id)
                {
                    List<PlayerDto> listplay = session.Players;
                    if (listplay[1].Id == id)
                    {
                        session.Players = _player.Shoot(listplay[0], listplay[1], x, y);
                        if (session.joueurid == _player.prochainjoueur(listplay[0], listplay[1], x, y))
                        {
                            resultat = 1;
                        }
                        else
                        {
                            resultat = -1;
                        }

                        if (_player.TestGagné(session.Players[1]))
                        {
                            session.GameState= -1;
                        }
                        session.joueurid = _player.prochainjoueur(listplay[0], listplay[1], x, y);
                    }
                    else
                    {
                        session.Players = _player.Shoot(listplay[1], listplay[0], x, y);
                        
                        if (session.joueurid == _player.prochainjoueur(listplay[1], listplay[0], x, y))
                        {
                            resultat = 1;
                        }
                        else
                        {
                            resultat = -1;
                        }
                        if (_player.TestGagné(session.Players[0]))
                        {
                            session.GameState = -1;
                        }
                        session.joueurid = _player.prochainjoueur(listplay[1], listplay[0], x, y);
                    }
                    _sess.sauvegarde(session);
                    _player.UpdatePlayer(session.Players[0]);
                    _player.UpdatePlayer(session.Players[1]);
                    return Ok((x+4, y+4, resultat));
                }
                else
                {
                    return BadRequest("Ce n'est pas à ton tour");
                }
            }
            else if (session.GameState == -1)
            {
                return Ok(session.joueurid + "a gagné la partie la partie");
            }
            else
            {
                return BadRequest("la partie n'a pas commencé");
            }
        }

        [HttpDelete("/Players/{id}/Delete")]
        public ActionResult DeletePlayer(int id)
        {
            try
            {
                DeletePlayer(id);
                return Ok("Successful deletion");
            }
            catch (Exception)
            {
                return NotFound("Cannot delete the specified player");
            }
        }

        // ---------------------------- ROUTES FOR GAMEMAPS ----------------------------  //

        [HttpGet("/Players/{id}/GameMaps")]
        public ActionResult GetGameMaps(int id)
        {
            PlayerDto player = new PlayerDto();
            GameMapDto gameMaps = new GameMapDto();
            try
            {  
                player = _player.GetPlayerById(id);
                gameMaps = player.GetPlayerBoards();

                return View(gameMaps);
            }
            catch(Exception) 
            {
                return NotFound("Cannot find the ganeMap you're looking for");
            }
        }

        // ---------------------------- ROUTES FOR SHIPS ----------------------------  //

        [HttpPost("/GameMaps/{id}/Add_Ship")]
        public ActionResult Add_Ship(int id,int x, int y, int direction,int longueur )
        {
            var player = _player.GetPlayerById(id);

            if (player.etat_joueur != 1)
            {
                GetbateauDto r = new GetbateauDto(x-4,y-4,direction,longueur);

                try
                {
                     player = _player.AddShipToGrid(player, r);
                    _player.UpdatePlayer(player);

                    return Ok(player);
                }
                catch
                {
                    return BadRequest("Ship cannot be added to the position given");
                }
            }
            else
            {
                return BadRequest("The game has already begun. You can't add more ships");
            }
        }
    }
}
