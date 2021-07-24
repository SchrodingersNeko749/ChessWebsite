using System.Linq;
using ChessWebsite.DTOs;
using ChessWebsite.Services;
using System.Collections.Generic;
namespace ChessWebsite.DTOs
{
    public class ChessLogic
    {
        public static Move LastMove = new Move(Board.ChessBoard[0], Board.ChessBoard[0]);
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
                    case 'N':
                        CalculateKnightMoves(piece);
                    break;
                    case 'B':
                        CalculateBishopMoves(piece);
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
                 pawn1square = Board.GetSquareByRankAndFile(pawn.Rank+1, pawn.File);
                 if(pawn1square.OccupingPiece == "")
                 if(pawn.Rank == 6)//if its promotion
                    LegalMoves.Add(new Move(pawn, pawn1square, "promotion"));
                else
                    LegalMoves.Add(new Move(pawn, pawn1square));

                if(pawn.Rank == 1)
                {
                    pawn2square = Board.GetSquareByRankAndFile(pawn.Rank+2, pawn.File);     
                     if(pawn2square.OccupingPiece == "")
                        LegalMoves.Add(new Move(pawn, pawn2square));
                }
                 //pawn captures
                 if(pawn.File>0)
                 {
                    pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank+1, pawn.File-1);
                    if(pawncaptureleft.OccupingPiece != "" && pawncaptureleft.OccupingPiece[0] == 'b')
                    {
                        if(pawn.Rank == 6)//if its promotion
                             LegalMoves.Add(new Move(pawn, pawncaptureleft, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn, pawncaptureleft));
                    }
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank+1, pawn.File+1);
                    if(pawncaptureright.OccupingPiece != "" && pawncaptureright.OccupingPiece[0] == 'b')
                    {
                        if(pawn.Rank == 6)//if its promotion
                             LegalMoves.Add(new Move(pawn, pawncaptureright, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn, pawncaptureright));
                    }
                 }
                 //en passant
                 if(pawn.Rank == 4 && LastMove.TargetSquare.OccupingPiece[1] == 'P' && LastMove.CurrentSquare.Rank == 6 && LastMove.TargetSquare.Rank ==4)
                 {
                     if(LastMove.TargetSquare.File == pawn.File +1)
                     {
                         pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank +1 , pawn.File +1);
                        LegalMoves.Add(new Move(pawn,pawncaptureright, "en passant"));
                     }
                     else
                     {
                         if(LastMove.TargetSquare.File == pawn.File -1)
                         {
                            pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank +1 , pawn.File -1);
                            LegalMoves.Add(new Move(pawn,pawncaptureleft, "en passant"));
                         }
                     }
                 }
             }
             else // pawns go down
             {
                 //pawn forward move
                 pawn1square = Board.GetSquareByRankAndFile(pawn.Rank-1, pawn.File);
                 if(pawn1square.OccupingPiece == "")
                 if(pawn.Rank == 1)//if its promotion
                    LegalMoves.Add(new Move(pawn, pawn1square, "promotion"));
                else
                    LegalMoves.Add(new Move(pawn, pawn1square));

                if(pawn.Rank == 6)
                 {
                    pawn2square = Board.GetSquareByRankAndFile(pawn.Rank-2, pawn.File);     
                    if(pawn2square.OccupingPiece == "")
                        LegalMoves.Add(new Move(pawn, pawn2square));
                 }
                 //pawn captures
                 if(pawn.File>0)
                 {
                    pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank-1, pawn.File-1);
                    if(pawncaptureleft.OccupingPiece != "" && pawncaptureleft.OccupingPiece[0] == 'w')
                     {
                        if(pawn.Rank == 1)//if its promotion
                             LegalMoves.Add(new Move(pawn, pawncaptureleft, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn, pawncaptureleft));
                    }
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank-1, pawn.File+1);
                    if(pawncaptureright.OccupingPiece != "" && pawncaptureright.OccupingPiece[0] == 'w')
                      {
                        if(pawn.Rank == 1)//if its promotion
                             LegalMoves.Add(new Move(pawn, pawncaptureright, "promotion"));
                         else
                             LegalMoves.Add(new Move(pawn, pawncaptureright));
                    }
                 }
                //en passant 
                 if(pawn.Rank == 4 )
                 {
                     
                 }
             }
         }
        private void CalculateRookMoves(Square rook)
        {

        }
        private void CalculateQueenMoves(Square queen)
        {
            Square targetsquare;
            for(int f = -1; f <= 1; f++)
                for(int r = -1; r <= 1; r++)
                    for(int length = 1; length<9 ; length++)
                    if(r != 0 || f != 0)
                    {
                        var targetrank = queen.Rank + r*length;
                        var targetfile = queen.File + f*length;
                        if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                        {
                            targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                            if (targetsquare.OccupingPiece!= "")
                             {
                                 if(targetsquare.OccupingPiece [0] != queen.OccupingPiece[0])
                                     LegalMoves.Add(new Move(queen, targetsquare));
                                break;
                             }
                             else
                                 LegalMoves.Add(new Move(queen, targetsquare));
                        }

                    }
        }
        private void CalculateBishopMoves(Square bishop)
        {
            Square targetsquare;
            for(int f = -1; f <= 1; f++)
                for(int r = -1; r <= 1; r++)
                    for(int length = 1; length<9 ; length++)
                    if(r != 0 & f != 0)
                    {
                        var targetrank = bishop.Rank + r*length;
                        var targetfile = bishop.File + f*length;
                        if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                        {
                            targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                            if (targetsquare.OccupingPiece!= "")
                             {
                                 if(targetsquare.OccupingPiece [0] != bishop.OccupingPiece[0])
                                     LegalMoves.Add(new Move(bishop, targetsquare));
                                break;
                             }
                             else
                                 LegalMoves.Add(new Move(bishop, targetsquare));
                        }

                    }
        }
        private void CalculateKnightMoves(Square knight)
        {
            Square targetsquare;
            for(int i = -2 ; i < 3; i ++)
                for(int j = -2; j < 3 ; j++)
                {
                    if(i != 0 && j !=0 && i/j!=1 && i/j != -1)
                    {
                        var targetrank = knight.Rank + i;
                        var targetfile = knight.File + j;
                        if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                        {
                            targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                            if(targetsquare.OccupingPiece == "")
                                LegalMoves.Add(new Move(knight,targetsquare));
                            else
                                if(targetsquare.OccupingPiece[0] != knight.OccupingPiece[0])
                                    LegalMoves.Add(new Move(knight,targetsquare));
                        }
                            
                    }
                }
        }
        private void CalculateKingMoves(Square king)
        {

        }
        public static Move GetMoveBySquareNames(string currentsquare, string targetsquare)
        {
            return LegalMoves.SingleOrDefault(mv => mv.CurrentSquare.Name == currentsquare &&  mv.TargetSquare.Name == targetsquare);
        }
        
    }
}