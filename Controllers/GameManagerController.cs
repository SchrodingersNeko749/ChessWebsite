using Microsoft.AspNetCore.Mvc;
using ChessWebsite.Services;
using ChessWebsite.DTOs;
using System.Collections.Generic;
namespace ChessWebsite.Controllers
{
    public class GameManagerController : ArenaController
    {
        public IEnumerable<Move> GetMove(string currentsquare)
        {
            return Arena_GameManager.LegalMovesForPiece(currentsquare);
        }    
        public void SendMove(string currentsquare, string targetsquare, string specialmove)
        {
            Arena_GameManager.PlayMove(currentsquare,targetsquare, specialmove);
        }
    }
}