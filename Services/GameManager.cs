using System;
using System.Linq;
using System.Collections.Generic;
using ChessWebsite.DTOs;
namespace ChessWebsite.Services
{
    public class GameManager
    {
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
                if(mv.CurrentSquare.Name == currentsquarename)
                    LegalListSubset.Add(mv);
            }
            return LegalListSubset;
        }

        public void PlayMove(string currentsquarename, string targetsquarename, string promotingpiece)
        {

            ChessLogic.LastMove = ChessLogic.GetMoveBySquareNames(currentsquarename, targetsquarename);

            var CurrentSquare = ChessLogic.LastMove.CurrentSquare;
            var TargetSquare = ChessLogic.LastMove.TargetSquare;
            switch (ChessLogic.LastMove.SpecialMove)
            {
                case "promotion":
                    TargetSquare.OccupingPiece = $"{CurrentSquare.OccupingPiece[0]}{promotingpiece[1]}";
                    CurrentSquare.OccupingPiece = "";
                break;
                case "en passant":
                    Square enpassant ;
                    if(isWhiteTurn)
                        enpassant = Board.GetSquareByRankAndFile(TargetSquare.Rank-1, TargetSquare.File);
                    else
                        enpassant = Board.GetSquareByRankAndFile(TargetSquare.Rank+1, TargetSquare.File);
                    TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                    CurrentSquare.OccupingPiece = "";
                    enpassant.OccupingPiece = "";
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