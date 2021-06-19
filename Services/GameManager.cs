using System;
using System.Collections.Generic;
using ChessWebsite.DTOs;
namespace ChessWebsite.Services
{
    public class GameManager
    {
        public static Move LastMove = new Move("","");
        public static bool isWhiteTurn = true;
        public int MoveCount = 0;
        static Board board_context = new Board("whitename", "blackname");
        
        public Move RandomMove()
        {
            board_context.BlackPlayer.CalculateLegalMoves();
            return board_context.BlackPlayer.LegalMoves[Random.RandomNumber(board_context.BlackPlayer.LegalMoves.Count)];
        }
        public List<Move> LegalMoves()
        {
            if(isWhiteTurn)
            {
                board_context.WhitePlayer.CalculateLegalMoves();
                return board_context.WhitePlayer.LegalMoves;
            }
            else
            {
                board_context.BlackPlayer.CalculateLegalMoves();
                return board_context.BlackPlayer.LegalMoves;
            }
        }
        public void PlayMove(Move move)
        {
            LastMove = move;
            var TargetSquare = Board.GetSquareByName(move.TargetSquareName);
            var CurrentSquare = Board.GetSquareByName(move.CurrentSquareName);

            if(TargetSquare.OccupingPiece != "") //is a capture
            {
                if(isWhiteTurn)
                {
                    for (int i = 0; i < board_context.BlackPlayer.Pieces.Length; i++)
                    {
                        if(board_context.BlackPlayer.Pieces[i] == null)
                            continue;
                        if(board_context.BlackPlayer.Pieces[i].Name == TargetSquare.Name)
                        {
                            board_context.BlackPlayer.Pieces[i] = null;
                            break;
                        }
                    }
                    for (int i = 0; i < board_context.WhitePlayer.Pieces.Length; i++)
                    {
                        if(board_context.WhitePlayer.Pieces[i] == null)
                            continue;
                        if(board_context.WhitePlayer.Pieces[i].Name == CurrentSquare.Name)
                        {
                            TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                            board_context.WhitePlayer.Pieces[i] = TargetSquare;
                            CurrentSquare.OccupingPiece = "";
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < board_context.WhitePlayer.Pieces.Length; i++)
                    {
                        if(board_context.WhitePlayer.Pieces[i] == null)
                            continue;
                        if(board_context.WhitePlayer.Pieces[i].Name == TargetSquare.Name)
                        {
                            board_context.WhitePlayer.Pieces[i] = null;
                            break;
                        }
                    }
                    for (int i = 0; i < board_context.BlackPlayer.Pieces.Length; i++)
                    {
                        if(board_context.BlackPlayer.Pieces[i] == null)
                            continue;
                        if(board_context.BlackPlayer.Pieces[i].Name == CurrentSquare.Name)
                        {
                            TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                            board_context.BlackPlayer.Pieces[i] = TargetSquare;
                            CurrentSquare.OccupingPiece = "";
                            break;
                        }
                    }
                }
            }
            else //its not a capture
            {
                if(isWhiteTurn)
                {
                    for (int i = 0; i < board_context.WhitePlayer.Pieces.Length; i++)
                    {
                        if(board_context.WhitePlayer.Pieces[i] == null)
                            continue;
                        if(board_context.WhitePlayer.Pieces[i].Name == CurrentSquare.Name)
                        {
                            TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                            board_context.WhitePlayer.Pieces[i] = TargetSquare;
                            CurrentSquare.OccupingPiece = "";
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < board_context.BlackPlayer.Pieces.Length; i++)
                    {
                        if(board_context.BlackPlayer.Pieces[i] == null)
                            continue;
                        if(board_context.BlackPlayer.Pieces[i].Name == CurrentSquare.Name)
                        {
                            TargetSquare.OccupingPiece = CurrentSquare.OccupingPiece;
                            board_context.BlackPlayer.Pieces[i] = TargetSquare;
                            CurrentSquare.OccupingPiece = "";
                            break;
                        }
                    }
                }
            }
            isWhiteTurn = !isWhiteTurn;
        }
    }
}