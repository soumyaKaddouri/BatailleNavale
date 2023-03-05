﻿using Microsoft.AspNetCore.Mvc;
using NavalWar.DTO.GameDto;
using NavalWar.DAL;
using NavalWar.Business;
using NavalWar.DTO.WebDto;
using NavalWar.DAL.Repository.Players;
using NavalWar.DAL.Repository.Sessions;
using System.Collections.Generic;

namespace NavalWar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PlayerController : Controller
    {


        SessionDto gameArea = new SessionDto();
        private readonly IPlayerService _player;
        private readonly ISessionService _sess;
        public PlayerController(IPlayerService play, ISessionService sess)
        {
            _player = play;
            _sess = sess;
        }

        [HttpGet("/Players/{id}")]
        public ActionResult GetPlayerby(int id)
        {

            try
            {
                var player = _player.GetPlayerById(id);
                return View(player);
            }
            catch (Exception)
            {
                return NotFound("Cannot find any game map");
            }
        }


        [HttpGet("/Players/{id}/GameMaps")]
        public ActionResult GetGameMaps(int id)
        {
            GameMapDto gameMaps = new GameMapDto();
            try
            { 
                gameMaps = _player.GetGameMap(id);
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
        [HttpPut("/Players/{id}/Shoot")]
        public ActionResult Shoot(int id, int x, int y)
        {
            var player = _player.GetPlayerById(id);
            var session = _sess.GetSessionById(player.IdSession);
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
        [HttpDelete("/Players/{id}/Delete")]
        public ActionResult DeletePlayer(int id)
        {
            try
            {
                DeletePlayer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}