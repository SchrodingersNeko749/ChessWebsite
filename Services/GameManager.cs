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
            chessLogic = new ChessLogic(new Player ("whitename", 'w'), new Player ("blackname", 'b') );
        }
        public void RestartGame(string whitename, string blackname)
        {
            Board.SetupBoard();
            Board.SetupPieces();
            chessLogic = new ChessLogic(new Player (whitename, 'w'), new Player (blackname, 'b') );
        }
        public Move RandomMoveForPlayer(char playercolor)
        {
            if(ChessLogic.LegalMoves.Count == 0) 
                return null;
            Move random_move = ChessLogic.LegalMoves[Random.RandomNumber(ChessLogic.LegalMoves.Count)];
            return random_move;
        }
        public List<Move> LegalMovesForPiece(string currentsquarename)
        {
            List<Move> LegalListSubset = new List<Move>();

            chessLogic.CalculateLegalMoves();
            if(!isWhiteTurn)
            {
                LegalListSubset.Add(RandomMoveForPlayer('b'));
            }
            else
            {
                foreach (var mv in ChessLogic.LegalMoves)
                {
                    if(mv.CurrentSquare.Name == currentsquarename)
                        LegalListSubset.Add(mv);
                }
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
                case "f1": //white castle short
                    TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                    CurrentSquare.OccupingPiece = "";
                    Board.GetSquareByName("f1").OccupingPiece = Board.GetSquareByName("h1").OccupingPiece;
                    Board.GetSquareByName("h1").OccupingPiece = "";
                    ChessLogic.WhitePlayer.CanCastleShort = false;
                    ChessLogic.WhitePlayer.CanCastleLong = false;

                break;
                case "f8": //black castle short
                    TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                    CurrentSquare.OccupingPiece = "";
                    Board.GetSquareByName("f8").OccupingPiece = Board.GetSquareByName("h8").OccupingPiece;
                    Board.GetSquareByName("h8").OccupingPiece = "";
                    ChessLogic.BlackPlayer.CanCastleShort = false;
                    ChessLogic.BlackPlayer.CanCastleLong = false;
                break;
                case "d1"://white castle long
                    TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                    CurrentSquare.OccupingPiece = "";
                    Board.GetSquareByName("d1").OccupingPiece = Board.GetSquareByName("a1").OccupingPiece;
                    Board.GetSquareByName("a1").OccupingPiece = "";
                    ChessLogic.WhitePlayer.CanCastleShort = false;
                    ChessLogic.WhitePlayer.CanCastleLong = false;
                break;
                case "d8"://black castle long
                    TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                    CurrentSquare.OccupingPiece = "";
                    Board.GetSquareByName("d8").OccupingPiece = Board.GetSquareByName("a8").OccupingPiece;
                    Board.GetSquareByName("a8").OccupingPiece = "";
                    ChessLogic.WhitePlayer.CanCastleShort = false;
                    ChessLogic.WhitePlayer.CanCastleLong = false;
                break;
                default:
                    TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                    CurrentSquare.OccupingPiece = "";
                    if(currentsquarename != targetsquarename)
                    {
                        if(CurrentSquare.OccupingPiece == "wK")
                        {
                            ChessLogic.WhitePlayer.CanCastleShort = false;
                            ChessLogic.WhitePlayer.CanCastleLong = false;
                        }
                        if(CurrentSquare.OccupingPiece == "bK")
                        {
                            ChessLogic.BlackPlayer.CanCastleShort = false;
                            ChessLogic.BlackPlayer.CanCastleLong = false;
                        }
                    }
                break;
            }
            isWhiteTurn = !isWhiteTurn;
            MoveCount ++;      
        }
    }
}