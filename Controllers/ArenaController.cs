using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChessWebsite.Services;
using ChessWebsite.DTOs;
using System.Text.Encodings.Web;
namespace ChessWebsite.Controllers
{
    public class ArenaController : Controller
    {
        public GameManager Arena_GameManager;
        public ArenaController()
        {
            Arena_GameManager = new GameManager();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IEnumerable<Move> GetMove(string currentsquare)
        {
            return Arena_GameManager.LegalMovesForPiece(currentsquare);
        }    
        public void SendMove(string currentsquare, string targetsquare, string promotingpiece)
        {
            Arena_GameManager.PlayMove(currentsquare,targetsquare,promotingpiece);
        }

    }

}