using System.Linq;
using ChessWebsite.Services;
using System.Collections.Generic;
namespace ChessWebsite.DTOs
{
    public class ChessLogic
    {
        public static List<Move> LegalMoves = new List<Move>();
        public void CalculateLegalMoves()
        {
            LegalMoves.Clear();
            foreach (Square piece in GameManager.board_context.ChessBoard)
            {
                if(piece.OccupingPiece != "")
                if(piece.OccupingPiece[1] == 'P')
                {
                    CalculatePawnMoves(piece);              
                }           
            }
        }
         private void CalculatePawnMoves(Square pawn)
         {
             Square pawn1square;
             Square pawn2square;
             Square pawncaptureright;
             Square pawncaptureleft;
             
             if(pawn.OccupingPiece[0] == 'w') //pawns go up
             {
                 pawn1square = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank+1, pawn.File);
                 LegalMoves.Add(new Move(pawn.Name, pawn1square.Name));
                 pawn2square = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank+2, pawn.File);
                 LegalMoves.Add(new Move(pawn.Name, pawn2square.Name));
                 if(pawn.File>0)
                 {
                    pawncaptureleft = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank+1, pawn.File-1);
                    if(pawncaptureleft.OccupingPiece != "")
                        LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name));
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank+1, pawn.File+1);
                    if(pawncaptureright.OccupingPiece != "")
                        LegalMoves.Add(new Move(pawn.Name, pawncaptureright.Name));
                 }
             }
             else // pawns go down
             {
                 pawn1square = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank-1, pawn.File);
                 LegalMoves.Add(new Move(pawn.Name, pawn1square.Name));
                 pawn2square = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank-2, pawn.File);
                 LegalMoves.Add(new Move(pawn.Name, pawn2square.Name));
                 if(pawn.File>0)
                 {
                    pawncaptureleft = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank-1, pawn.File-1);
                    if(pawncaptureleft.OccupingPiece != "")
                        LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name));
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = GameManager.board_context.GetSquareByRankAndFile(pawn.Rank-1, pawn.File+1);
                    if(pawncaptureright.OccupingPiece != "")
                        LegalMoves.Add(new Move(pawn.Name, pawncaptureright.Name));
                 }
             }
         }
        private void CalculateRookMoves(Square rook)
        {

        }
        private void CalculateQueenMoves(Square queen)
        {

        }
        private void CalculateBishopMoves(Square bishop)
        {

        }
        private void CalculateKnightMoves(Square knight)
        {
            
        }
        private void CalculateKingMoves(Square king)
        {

        }
        public static Move GetMoveBySquareNames(string currentsquare, string targetsquare)
        {
            return LegalMoves.SingleOrDefault(mv => mv.CurrentSquareName == currentsquare &&  mv.TargetSquareName == targetsquare);
        }
        
    }
}