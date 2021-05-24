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
        
    }

}