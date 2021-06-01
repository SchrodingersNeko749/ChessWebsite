using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChessWebsite.Services;
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
        public string GetMove()
        {
            return Arena_GameManager.RandomSquareName();
        }       
        public void SendMove(string square)
        {

        } 
        public void GetLegalMovesForPiece(char piece, string square)
        {

        }
    }

}