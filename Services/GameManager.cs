using System;
using System.Linq;
using System.Collections.Generic;
using ChessWebsite.DTOs;
namespace ChessWebsite.Services
{
    public class GameManager
    {
        public static Board board_context;
        public static Move LastMove = new Move("","");
        public static bool isWhiteTurn = true;
        public static int MoveCount = 1;
        public ChessLogic chessLogic;
        public GameManager()
        {
            board_context = new Board("whitename", "blackname");
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
        public void RelocatePiece(Square current, Square target)
        {
            target.OccupingPiece = current.OccupingPiece;
        }
        public void PlayMove(string currentsquarename, string targetsquarename)
        {
            Console.Write(board_context.ChessBoard[0]);
            LastMove = ChessLogic.GetMoveBySquareNames(currentsquarename, targetsquarename);

            var CurrentSquare = board_context.GetSquareByName(currentsquarename);
            var TargetSquare = board_context.GetSquareByName(targetsquarename);

            board_context.GetSquareByName(targetsquarename).OccupingPiece = board_context.GetSquareByName(currentsquarename).OccupingPiece;
            board_context.GetSquareByName(currentsquarename).OccupingPiece = "";
            isWhiteTurn = !isWhiteTurn;
            MoveCount ++;
                
            }

    }
}