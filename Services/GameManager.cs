using System;
using System.Linq;
using System.Collections.Generic;
using ChessWebsite.DTOs;
namespace ChessWebsite.Services
{
    public class GameManager
    {
        public static Move LastMove = new Move("","");
        public static bool isWhiteTurn = true;
        public static int MoveCount = 1;
        public ChessLogic chessLogic;//entity that calculates legal moves 
        public GameManager()
        {
            chessLogic = new ChessLogic();
        }
        public Move RandomMove()
        {
            chessLogic.CalculateLegalMoves();
            return ChessLogic.LegalMoves[Random.RandomNumber(ChessLogic.LegalMoves.Count)];
        }
        public List<Move> LegalMovesForPiece(string currentsquarename)
        {
            List<Move> LegalListSubset = new List<Move>();

            chessLogic.CalculateLegalMoves();
            foreach (var mv in ChessLogic.LegalMoves)
            {
                if(mv.CurrentSquareName == currentsquarename)
                    LegalListSubset.Add(mv);
            }
            return LegalListSubset;
        }

        public void PlayMove(string currentsquarename, string targetsquarename, string promotingpiece)
        {

            LastMove = ChessLogic.GetMoveBySquareNames(currentsquarename, targetsquarename);

            var CurrentSquare = Board.GetSquareByName(currentsquarename);
            var TargetSquare = Board.GetSquareByName(targetsquarename);
            switch (LastMove.SpecialMove)
            {
                case "promotion":
                    TargetSquare.OccupingPiece = $"{CurrentSquare.OccupingPiece[0]}{promotingpiece[1]}";
                    CurrentSquare.OccupingPiece = "";
                break;
                default:
                    TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                    CurrentSquare.OccupingPiece = "";
                break;
            }
            isWhiteTurn = !isWhiteTurn;
            MoveCount ++;      
        }
    }
}