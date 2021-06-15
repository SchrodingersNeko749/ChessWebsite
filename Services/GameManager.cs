using System;
using System.Collections.Generic;
using ChessWebsite.DTOs;
namespace ChessWebsite.Services
{
    public class GameManager
    {
        public bool isWhiteTurn = true;
        public int MoveCount = 0;
        Board board_context;
        public GameManager()
        {
            var whitename = "neko";
            var blackname = "alu";
            board_context = new Board(whitename, blackname);
        }
        
        public Move RandomMove()
        {
            board_context.BlackPlayer.GetLegalMoves();
            return board_context.BlackPlayer.LegalMoves[Random.RandomNumber(board_context.BlackPlayer.LegalMoves.Count)];
        }
        public void PlayMove(Square currentsquare, Square targetSquare)
        {
            targetSquare.OccupingPiece = currentsquare.OccupingPiece;
        }
    }
}