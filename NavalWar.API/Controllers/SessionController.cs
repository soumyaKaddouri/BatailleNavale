﻿using Microsoft.AspNetCore.Mvc;
using NavalWar.Business;
using NavalWar.DTO.GameDto;

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
            try
            {
                var session = _sess.GetSessionById(id);
                return Ok(session.Id);
            }
            catch (Exception ex)
            {
                return NotFound("Cannot find the session you asked for");
            }
        }

        [HttpGet("Sessions/{id}/Active_Player")]
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
                if (session.Players != null && session.Players.Count() == 2)
                {
                        return BadRequest("trop de joueur: max 2");
                }
                else
                {
                    PlayerDto player = new PlayerDto();
                    player.Name = playername;
                    player.IdSession = id;
                    player.PlayerBoards = new GameMapDto();
                    int idPlayer = _play.AddPlayer(player);
                    if (session.joueurid == 0)
                    {
                        session.joueurid = idPlayer;
                        session.Players = new List<PlayerDto>();
                        session.Players.Add(player);
                        session.Players[0].Id = idPlayer;
                    }
                    else
                    {
                        session.Players.Add(player);
                        session.Players[1].Id = idPlayer;
                    }

                    _sess.sauvegarde(session);
                    return Ok(idPlayer);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPost("Sessions/{id}/ChangeGameState")]
        public IActionResult SetGameState([FromBody] int id, string playername)
        {
            var session = _sess.GetSessionById(id);
            try
            {

                if (session.Players[0].etat_joueur == 1 && session.Players[1].etat_joueur == 1)
                {
                    session.GameState = 1;
                    _sess.sauvegarde(session);
                    return Ok();
                }
                else
                {
                    return BadRequest("Tous les joueurs ne sont pas prêt");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
