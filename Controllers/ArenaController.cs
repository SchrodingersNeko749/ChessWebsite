using ChessWebsite.DTOs;
using Microsoft.AspNetCore.Mvc;
using ChessWebsite.Services;

namespace ChessWebsite.Controllers
{
    public class ArenaController : Controller
    {
        private protected GameManager Arena_GameManager;
        public ArenaController()
        {
            Arena_GameManager = new GameManager();
        }
        public IActionResult Index()
        {
            return View();
        }
        public void RestartGame()
        {
            Arena_GameManager.RestartGame();
        }
        public Square[] LoadGame()
        {
            return Board.ChessBoard;
        }

    }

}