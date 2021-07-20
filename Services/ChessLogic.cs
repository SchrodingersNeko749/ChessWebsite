using System.Linq;
using ChessWebsite.DTOs;
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
            foreach (Square piece in Board.ChessBoard)
            {
                if(piece.OccupingPiece != "")
                switch (piece.OccupingPiece[1])
                {
                    case 'P':
                        CalculatePawnMoves(piece); 
                    break;    
                    case 'Q':
                        CalculateQueenMoves(piece);  
                    break;              
                    default:
                    break;
                }        
            }
        }
         private void CalculatePawnMoves(Square pawn)
         {
             Square pawn2square;
             Square pawn1square;
             Square pawncaptureright;
             Square pawncaptureleft;
             
             if(pawn.OccupingPiece[0] == 'w') //pawns go up
             {
                 //pawn forward move
                 pawn1square = Board.GetSquareByRankAndFile(pawn.Rank, pawn.File);
                 if(pawn1square.OccupingPiece == "")
                 if(pawn.Rank == 7)//if its promotion
                    LegalMoves.Add(new Move(pawn.Name, pawn1square.Name, "promotion"));
                else
                    LegalMoves.Add(new Move(pawn.Name, pawn1square.Name));

                if(pawn.Rank == 2)
                 {
                    pawn2square = Board.GetSquareByRankAndFile(pawn.Rank+1, pawn.File);     
                    LegalMoves.Add(new Move(pawn.Name, pawn2square.Name));
                 }
                 //pawn captures
                 if(pawn.File>0)
                 {
                    pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank, pawn.File-1);
                    if(pawncaptureleft.OccupingPiece != "" && pawncaptureleft.OccupingPiece[0] == 'b')
                    {
                        if(pawn.Rank == 7)//if its promotion
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name));
                    }
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank, pawn.File+1);
                    if(pawncaptureright.OccupingPiece != "" && pawncaptureright.OccupingPiece[0] == 'b')
                    {
                        if(pawn.Rank == 7)//if its promotion
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureright.Name, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureright.Name));
                    }
                 }
                 //en passant
             }
             else // pawns go down
             {
                 //pawn forward move
                 pawn1square = Board.GetSquareByRankAndFile(pawn.Rank-2, pawn.File);
                 if(pawn.Rank == 2)//if its promotion
                    LegalMoves.Add(new Move(pawn.Name, pawn1square.Name, "promotion"));
                else
                    LegalMoves.Add(new Move(pawn.Name, pawn1square.Name));
                 if(pawn.Rank == 7)
                 {
                    pawn2square = Board.GetSquareByRankAndFile(pawn.Rank-3, pawn.File);     
                    LegalMoves.Add(new Move(pawn.Name, pawn2square.Name));
                 }
                 //pawn captures
                 if(pawn.File>0)
                 {
                    pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank-2, pawn.File-1);
                    if(pawncaptureleft.OccupingPiece != "" && pawncaptureleft.OccupingPiece[0] == 'w')
                     {
                        if(pawn.Rank == 2)//if its promotion
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name));
                    }
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank-2, pawn.File+1);
                    if(pawncaptureright.OccupingPiece != "" && pawncaptureright.OccupingPiece[0] == 'w')
                      {
                        if(pawn.Rank == 2)//if its promotion
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureright.Name, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn.Name, pawncaptureright.Name));
                    }
                 }
                //en passant 
             }
         }
        private void CalculateRookMoves(Square rook)
        {

        }
        private void CalculateQueenMoves(Square queen)
        {
            Square targetsquare;
            for(int i = queen.Rank; i < 8 ; i++)
            {
                var i2 = 9-i;
                targetsquare = Board.GetSquareByRankAndFile(i,queen.File);
                targetsquare = Board.GetSquareByRankAndFile(i2,queen.File);
                if (targetsquare.OccupingPiece!= "")
                {
                    if(targetsquare.OccupingPiece [0] != queen.OccupingPiece[0])
                        LegalMoves.Add(new Move(queen.Name, targetsquare.Name));
                    
                    break;
                }
                else
                    LegalMoves.Add(new Move(queen.Name, targetsquare.Name));
            }
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