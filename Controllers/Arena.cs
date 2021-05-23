using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChessWebsite.Models;
using ChessWebsite.Services;

namespace ChessWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenaController : ControllerBase
    {
        public GameManager Arena_GameManager;
        public ArenaController()
        {
            Arena_GameManager = new GameManager();
        }
        [HttpGet]
        public bool GetSquareColor(string notation)
        {
            return Arena_GameManager.Board[notation].IsLightSquare;
        }
    }

}