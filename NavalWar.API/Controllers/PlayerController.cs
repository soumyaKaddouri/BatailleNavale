using Microsoft.AspNetCore.Mvc;
using NavalWar.DTO.GameDto;
using NavalWar.DAL;
using NavalWar.Business;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;
using NavalWar.DAL.Repository.Sessions;
using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

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

        // ---------------------- ROUTES FOR PLAYER ---------------------- //

        [HttpGet("/Players/{id}")]
        public ActionResult GetPlayerById(int id)
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

        [HttpPost("/Players/{id}/Add_Player")]
        public ActionResult Add_Player(int id, string name)
        {
            try
            {
                PlayerDto player = new PlayerDto();

                player.Id = id;
                player.Name = name;
                player.etat_joueur = 0;

                _player.AddPlayer(player);

                return Ok(player.Id + ". Hello " + player.Name);
            }
            catch (Exception)
            {
                return NotFound("Cannot add a player");
            }
        }

        [HttpPut("/Players/{id}/Is_Ready")]
        public ActionResult SetPlayerState(int id)
        {    
            try
            {
                var player = _player.GetPlayerById(id);
            
                player.etat_joueur = 1;    
                _player.UpdatePlayer(player);

                return Ok("Successful update");
            }
            catch (Exception)
            {
                return NotFound("Cannot find any player");
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

        // ---------------------- ROUTES FOR GAMEMAPS ---------------------- //

        [HttpGet("/Players/{id}/GameMaps")]
        public ActionResult GetGameMaps(int id)
        {
            try
            {  
                PlayerDto player = new PlayerDto();
                GameMapDto gameMaps = new GameMapDto();

                player = _player.GetPlayerById(id);
                gameMaps = player.GetPlayerBoards();
                
                return Ok(gameMaps);
            }
            catch(Exception) 
            {
                return NotFound("Cannot find the game you're looking for");
            }
        }

        // ---------------------- ROUTES FOR SHIPS ---------------------- //

        [HttpPost("Players/{id}/GameMaps/Add_Ship")]
        public ActionResult Add_Ship(int id_player, GetbateauDto newShip)
        {
            var player = _player.GetPlayerById(id_player);

            if (player.etat_joueur != 1)
            {
                try
                {
                    GetbateauDto r = new GetbateauDto(newShip.startOffsetX, newShip.startOffsetY, newShip.direction, newShip.shipLength);
                    
                    player = _player.AddShipToGrid(player, r);
                    _player.UpdatePlayer(player);
                    
                    return Ok(player.PlayerBoards.ShipPositionsBoard);
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

        [HttpPut("Players/{id}/GameMaps/Update_Ship")]
        /*public ActionResult Update_Ship(int id_player, GetbateauDto actualShip, GetbateauDto newShip)
        {
            var player = _player.GetPlayerById(id_player);

            if (player.etat_joueur != 1)
            {
                try
                {
                    player = _player.UpdateShipInGrid(player, actualShip, newShip);
                    _player.UpdatePlayer(player);

                    return Ok(player.PlayerBoards.ShipPositionsBoard);
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

        [HttpDelete("Players/{id}/GameMaps/{id}/Remove_Ship")]
        public ActionResult Remove_Ship(int id_player, int id_gameMap, int x, int y, int direction, int type)
        {
            var player = _player.GetPlayerById(id_player);

            if (player.etat_joueur != 1)
            {
                try
                {
                    GetbateauDto r = new GetbateauDto(x, y, direction, type);

                    player = _player.AddShipToGrid(player, r);
                    _player.UpdatePlayer(player);

                    return Ok(player.PlayerBoards.ShipPositionsBoard);
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
        }*/


        [HttpPut("/Players/{id}/Shoot")]
        public ActionResult Shoot(int id, int x, int y)
        {
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
                        session.joueurid = _player.prochainjoueur(listplay[0], listplay[1], x, y);
                    }
                    else
                    {
                        session.Players = _player.Shoot(listplay[1], listplay[0], x, y);
                        session.joueurid = _player.prochainjoueur(listplay[1], listplay[0], x, y);
                    }
                    _sess.sauvegarde(session);
                    _player.UpdatePlayer(session.Players[0]);
                    _player.UpdatePlayer(session.Players[1]);
                    return Ok(session);
                }
                else
                {
                    return BadRequest("Ce n'est pas à ton tour");
                }
            }
            else
            {
                return BadRequest("la partie n'a pas commencé");
            }
        }
        
    }
}
