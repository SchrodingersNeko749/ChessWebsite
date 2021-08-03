using System.Linq;
using ChessWebsite.Services;
using System.Collections.Generic;
namespace ChessWebsite.DTOs
{
    public class ChessLogic
    {
        public static Player currentPlayer;
        public static Player WhitePlayer;
        private List<Square> LegalCheckSquares = new List<Square>(); // list of squares that player can block to escape check
        public static Player BlackPlayer;
        public static Move LastMove = new Move(Board.ChessBoard[0], Board.ChessBoard[0]);
        public static List<Move> LegalMoves = new List<Move>();
        public ChessLogic(Player white, Player black)
        {
            WhitePlayer = white;
            BlackPlayer = black;
        }
        public void CalculateLegalMoves()
        {
            currentPlayer = CurrentPlayer();
            currentPlayer.CheckedByHowManyPiece = 0;
            LegalMoves.Clear();
            Square whiteking = new Square(65);//just to assign a value to variable
            Square blackking = new Square(65);//just to assign a value to variable
            
            foreach (var sq in Board.ChessBoard)
            {
                sq.Targetedby[0] = 'n';
                sq.Targetedby[1] = 'n';
                sq.isPinned = false;
                if(sq.OccupingPiece == "wK")
                    whiteking = sq;
                if(sq.OccupingPiece == "bK")
                    blackking = sq;      
            }
            if(GameManager.isWhiteTurn)
                KingCondition(whiteking);
            else
                KingCondition(blackking);
            foreach (Square piece in Board.ChessBoard)
            {
                if(piece.OccupingPiece != "")
                switch (piece.OccupingPiece[1])
                {
                    case 'P':
                    if(currentPlayer.CheckedByHowManyPiece !=2)
                        CalculatePawnMoves(piece); 
                    break;    
                    case 'Q':
                    if(currentPlayer.CheckedByHowManyPiece !=2)
                        CalculateQueenMoves(piece);  
                    break;       
                    case 'N':
                    if(currentPlayer.CheckedByHowManyPiece !=2)
                        CalculateKnightMoves(piece);
                    break;
                    case 'B':
                    if(currentPlayer.CheckedByHowManyPiece !=2)
                        CalculateBishopMoves(piece);
                    break;
                    case 'R':
                    if(currentPlayer.CheckedByHowManyPiece !=2)
                        CalculateRookMoves(piece);
                    break;
                    case 'K':
                    CalculateKingTargetSquares(piece);
                    break;
                }       
            }
                CalculateKingMoves(whiteking);
                CalculateKingMoves(blackking);
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
                 {
                    AddMove(new Move(pawn, pawn1square, "promotion"));
                 }
                else
                    AddMove(new Move(pawn, pawn1square));

                if(pawn.Rank == 1)
                {
                    pawn2square = Board.GetSquareByRankAndFile(pawn.Rank+2, pawn.File);     
                     if(pawn2square.OccupingPiece == "" && pawn1square.OccupingPiece =="")
                        AddMove(new Move(pawn, pawn2square));
                }
                 //pawn captures
                 if(pawn.File>0)
                 {
                    pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank+1, pawn.File-1);
                    pawncaptureleft.AddToTargetedBy(pawn.OccupingPiece[0]);
                    if(pawncaptureleft.OccupingPiece != "" && pawncaptureleft.OccupingPiece[0] == 'b')
                    {
                        if(pawn.Rank == 6)//if its promotion
                             AddMove(new Move(pawn, pawncaptureleft, "promotion"));
                         else
                             AddMove(new Move(pawn, pawncaptureleft));
                    }
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank+1, pawn.File+1);
                    pawncaptureright.AddToTargetedBy(pawn.OccupingPiece[0]);
                    if(pawncaptureright.OccupingPiece != "" && pawncaptureright.OccupingPiece[0] == 'b')
                    {
                        if(pawn.Rank == 6)//if its promotion
                             AddMove(new Move(pawn, pawncaptureright, "promotion"));
                         else
                             AddMove(new Move(pawn, pawncaptureright));
                    }
                 }
                 //en passant
                 if(pawn.Rank == 4 && LastMove.TargetSquare.OccupingPiece[1] == 'P' && LastMove.CurrentSquare.Rank == 6 && LastMove.TargetSquare.Rank ==4)
                 {
                     if(LastMove.TargetSquare.File == pawn.File +1)
                     {
                         pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank +1 , pawn.File +1);
                        AddMove(new Move(pawn,pawncaptureright, "en passant"));
                     }
                     else
                     {
                         if(LastMove.TargetSquare.File == pawn.File -1)
                         {
                            pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank +1 , pawn.File -1);
                            AddMove(new Move(pawn,pawncaptureleft, "en passant"));
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
                 {
                    AddMove(new Move(pawn, pawn1square, "promotion"));
                 }
                else
                    AddMove(new Move(pawn, pawn1square));


                if(pawn.Rank == 6)
                 {
                    pawn2square = Board.GetSquareByRankAndFile(pawn.Rank-2, pawn.File);     
                    if(pawn2square.OccupingPiece == "" && pawn1square.OccupingPiece =="")
                        AddMove(new Move(pawn, pawn2square));
                 }
                 //pawn captures
                 if(pawn.File>0)
                 {
                    pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank-1, pawn.File-1);
                    pawncaptureleft.AddToTargetedBy(pawn.OccupingPiece[0]);
                    if(pawncaptureleft.OccupingPiece != "" && pawncaptureleft.OccupingPiece[0] == 'w')
                     {
                        if(pawn.Rank == 1)//if its promotion
                             AddMove(new Move(pawn, pawncaptureleft, "promotion"));
                         else
                             AddMove(new Move(pawn, pawncaptureleft));
                    }
                 }
                 if(pawn.File<7)
                 {
                    pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank-1, pawn.File+1);
                    pawncaptureright.AddToTargetedBy(pawn.OccupingPiece[0]);
                    if(pawncaptureright.OccupingPiece != "" && pawncaptureright.OccupingPiece[0] == 'w')
                      {
                        if(pawn.Rank == 1)//if its promotion
                             AddMove(new Move(pawn, pawncaptureright, "promotion"));
                         else
                             AddMove(new Move(pawn, pawncaptureright));
                    }
                 }
                //en passant 
                if(pawn.Rank == 3 && LastMove.TargetSquare.OccupingPiece[1] == 'P' && LastMove.CurrentSquare.Rank == 1 && LastMove.TargetSquare.Rank ==3)
                 {
                     if(LastMove.TargetSquare.File == pawn.File +1)
                     {
                        pawncaptureright = Board.GetSquareByRankAndFile(pawn.Rank -1 , pawn.File +1);
                        AddMove(new Move(pawn,pawncaptureright, "en passant"));
                     }
                     else
                     {
                         if(LastMove.TargetSquare.File == pawn.File -1)
                         {
                            pawncaptureleft = Board.GetSquareByRankAndFile(pawn.Rank -1 , pawn.File -1);
                            AddMove(new Move(pawn,pawncaptureleft, "en passant"));
                         }
                     }
                 }
             }
         }
        private void CalculateRookMoves(Square rook)
        {
            Square targetsquare;
            for(int f = -1; f <= 1; f++)
                for(int r = -1; r <= 1; r++)
                    for(int length = 1; length<9 ; length++)
                    if(r!=f && (r +f) != 0)
                    {
                        var targetrank = rook.Rank + r*length;
                        var targetfile = rook.File + f*length;
                        if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                        {
                            targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                            if (targetsquare.OccupingPiece!= "")
                             {
                                 if(targetsquare.OccupingPiece [0] != rook.OccupingPiece[0])
                                 {
                                     if(targetsquare.OccupingPiece[1] == 'K')
                                    {
                                        targetrank = rook.Rank + r*(length+1);
                                        targetfile = rook.File + f*(length+1);
                                        if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                                        {
                                            Board.GetSquareByRankAndFile(targetrank,targetfile).AddToTargetedBy(rook.OccupingPiece[0]);
                                        }
                                    }
                                    AddMove(new Move(rook, targetsquare));
                                 }
                                  else
                                 {
                                     targetsquare.AddToTargetedBy(rook.OccupingPiece[0]);
                                 }
                                break;
                             }
                             else
                                 AddMove(new Move(rook, targetsquare));
                        }

                    }
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
                                 {
                                    if(targetsquare.OccupingPiece[1] == 'K')
                                    {
                                        targetrank = queen.Rank + r*(length+1);
                                        targetfile = queen.File + f*(length+1);
                                        if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                                        {
                                            Board.GetSquareByRankAndFile(targetrank,targetfile).AddToTargetedBy(queen.OccupingPiece[0]);
                                        }
                                    }
                                     AddMove(new Move(queen, targetsquare));
                                 }
                                 else
                                 {
                                     targetsquare.AddToTargetedBy(queen.OccupingPiece[0]);
                                 }
                                break;
                             }
                             else
                                 AddMove(new Move(queen, targetsquare));
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
                                 {
                                    if(targetsquare.OccupingPiece[1] == 'K')
                                    {
                                        targetrank = bishop.Rank + r*(length+1);
                                        targetfile = bishop.File + f*(length+1);
                                        if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                                        {
                                            Board.GetSquareByRankAndFile(targetrank,targetfile).AddToTargetedBy(bishop.OccupingPiece[0]);
                                        }
                                    }
                                    AddMove(new Move(bishop, targetsquare));
                                 }
                                  else
                                 {
                                     targetsquare.AddToTargetedBy(bishop.OccupingPiece[0]);
                                 }
                                break;
                             }
                             else
                                 AddMove(new Move(bishop, targetsquare));
                        }
                    }
        }
        private void CalculateKnightMoves(Square knight)
        {
            Square targetsquare;
            for(int r = -2 ; r < 3; r ++)
                for(int f = -2; f < 3 ; f++)
                {
                    if(r != 0 && f !=0 && r/f!=1 && r/f != -1)
                    {
                        var targetrank = knight.Rank + r;
                        var targetfile = knight.File + f;
                        if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                        {
                            targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                            if(targetsquare.OccupingPiece == "")
                                AddMove(new Move(knight,targetsquare));
                            else
                                if(targetsquare.OccupingPiece[0] != knight.OccupingPiece[0])
                                    AddMove(new Move(knight,targetsquare));
                                 else
                                 {
                                     targetsquare.AddToTargetedBy(knight.OccupingPiece[0]);
                                 }
                                    
                        }
                            
                    }
                }
        }
        private void CalculateKingMoves(Square king)
        {
            currentPlayer.CheckedByHowManyPiece = 0;
            Square targetsquare;
            for(int f = -1; f <= 1; f++)
                for(int r = -1; r <= 1; r++)
                    if(r != 0 || f != 0)
                    {
                        var targetrank = king.Rank + r;
                        var targetfile = king.File + f;
                        if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                        {
                            targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                            if(!isIllegalSquareForKing(targetsquare, king.OccupingPiece[0]))
                            {
                                if (targetsquare.OccupingPiece!= "")
                                 {
                                     if(targetsquare.OccupingPiece [0] != king.OccupingPiece[0])
                                         AddMove(new Move(king, targetsquare));
                                 }
                                 else
                                     AddMove(new Move(king, targetsquare));
                            }
                            else
                                targetsquare.AddToTargetedBy(king.OccupingPiece[0]);
                        }
                    }
            
            CastleShort(king);
            CastleLong(king);
        }
        public void CalculateKingTargetSquares(Square king)
        {
            Square targetsquare;
                        for(int f = -1; f <= 1; f++)
                            for(int r = -1; r <= 1; r++)
                                if(r != 0 || f != 0)
                                {
                                    var targetrank = king.Rank + r;
                                    var targetfile = king.File + f;
                                    if(targetrank >= 0 && targetrank <8 &&  targetfile>=0 && targetfile<8)
                                     {
                                         targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                                         targetsquare.AddToTargetedBy(king.OccupingPiece[0]);
                                     }
                                }
                    
        }
        private bool isIllegalSquareForKing(Square targetsquare,char kingcolor)
        {
            if(kingcolor == 'w')
                return targetsquare.Targetedby.Contains('b');
            else
                return targetsquare.Targetedby.Contains('w');
        }
        private void AddMove(Move m)
        {   

            if(m.CurrentSquare.OccupingPiece[1] != 'P') 
                m.TargetSquare.AddToTargetedBy(m.CurrentSquare.OccupingPiece[0]);
            if(currentPlayer.CheckedByHowManyPiece == 1)
            {
                if(LegalCheckSquares.Contains(m.TargetSquare))
                {
                    m.SpecialMove = "blockcheck";
                    if(!m.CurrentSquare.isPinned)
                        LegalMoves.Add(m);

                }
            }
            else
            {
                if(!m.CurrentSquare.isPinned)
                    LegalMoves.Add(m);
            }
        }
        public static Move GetMoveBySquareNames(string currentsquare, string targetsquare)
        {
            return LegalMoves.SingleOrDefault(mv => mv.CurrentSquare.Name == currentsquare &&  mv.TargetSquare.Name == targetsquare);
        }
        public void KingCondition(Square king)
        {
            Square targetsquare;
            int targetfile;
            int targetrank;
            LegalCheckSquares.Clear();
            for(int f = -1; f <= 1; f++)
                for(int r = -1 ; r <= 1; r ++)
                {
                        if(r != 0 || f != 0) // queen
                        {
                            if(currentPlayer.CheckedByHowManyPiece == 0)
                                LegalCheckSquares.Clear();
                            for(int length = 1; length<9 ; length++)
                            {
                                targetrank = king.Rank + r*length;
                                targetfile = king.File + f*length;
                                if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                                {
                                    targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                                    if(currentPlayer.CheckedByHowManyPiece == 0)
                                        LegalCheckSquares.Add(targetsquare);
                                    if(targetsquare.OccupingPiece != "")
                                    {
                                        if(targetsquare.OccupingPiece[0] != king.OccupingPiece[0])
                                        {
                                            if(targetsquare.OccupingPiece[1] == 'Q')
                                                currentPlayer.CheckedByHowManyPiece += 1;
                                        }
                                        else
                                        {
                                            isPinned(targetsquare, r, f, length);
                                        }
                                        ClearCheckSquares();
                                        break;
                                    }
                                }
                            }
                        }
                        if((r != 0 & f != 0) && currentPlayer.CheckedByHowManyPiece == 0) // bishop
                        {
                            for(int length = 1; length<9 ; length++)
                            {
                                targetrank = king.Rank + r*length;
                                targetfile = king.File + f*length;
                                if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                                {
                                    targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                                    LegalCheckSquares.Add(targetsquare);
                                    if(targetsquare.OccupingPiece != "")
                                    {
                                        if(targetsquare.OccupingPiece[0] != king.OccupingPiece[0])
                                        {
                                            if(targetsquare.OccupingPiece[1] == 'B')
                                                currentPlayer.CheckedByHowManyPiece += 1;
                                        }
                                        ClearCheckSquares();
                                        break;
                                    }
                                }
                            }
                        }
                        if((r!=f && (r +f) != 0) && currentPlayer.CheckedByHowManyPiece == 0) //Rook
                        {
                            LegalCheckSquares.Clear();
                            for(int length = 1; length<9 ; length++)
                            {
                                targetrank = king.Rank + r*length;
                                targetfile = king.File + f*length;
                                if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                                {
                                    targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                                    LegalCheckSquares.Add(targetsquare);
                                    if(targetsquare.OccupingPiece != "")
                                    {
                                        if(targetsquare.OccupingPiece[0] != king.OccupingPiece[0])
                                        {
                                            if(targetsquare.OccupingPiece[1] == 'R')
                                                currentPlayer.CheckedByHowManyPiece += 1;
                                        }
                                        ClearCheckSquares();
                                        break;
                                    }
                                }
                            }
                        }
                }
                //knight
                if(currentPlayer.CheckedByHowManyPiece == 0)
                {
                    LegalCheckSquares.Clear();
                    for(int r = -2 ; r < 3; r ++)
                    for(int f = -2; f < 3 ; f++)
                    {
                        if((r != 0 && f !=0 && r/f!=1 && r/f != -1) && currentPlayer.CheckedByHowManyPiece == 0)
                        {
                            LegalCheckSquares.Clear();
                            targetrank = king.Rank + r;
                            targetfile = king.File + f;
                            if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                            {
                                targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                                LegalCheckSquares.Add(targetsquare);
                                if(targetsquare.OccupingPiece != "")
                                {
                                    if(targetsquare.OccupingPiece[0] != king.OccupingPiece[0])
                                    {
                                        if(targetsquare.OccupingPiece[1] == 'N')
                                        {
                                            currentPlayer.CheckedByHowManyPiece += 1;
                                            break;
                                        }
                                    }
                                    ClearCheckSquares();
                                }       
                            }
                                
                        }
                    }
                    //pawn
                    if(currentPlayer.CheckedByHowManyPiece == 0)
                    {
                        LegalCheckSquares.Clear();
                        for(int r = -1; r <= 1; r+=2)
                            for(int f = -1; f <= 1; f+=2)
                            {
                                LegalCheckSquares.Clear();
                                    targetrank = king.Rank + r;
                                    targetfile = king.File + f;
                                    if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                                    {
                                        targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                                        LegalCheckSquares.Add(targetsquare);
                                        if(GameManager.isWhiteTurn && r == 1  && currentPlayer.CheckedByHowManyPiece == 0)
                                        {
                                            if(targetsquare.OccupingPiece == "bP")
                                                currentPlayer.CheckedByHowManyPiece += 1;
                                        }
                                        else
                                        {
                                            if(!GameManager.isWhiteTurn && r == -1 && currentPlayer.CheckedByHowManyPiece == 0)
                                            {
                                                if(targetsquare.OccupingPiece == "wP")
                                                    currentPlayer.CheckedByHowManyPiece += 1;
                                            }
                                        }
                                }
                                ClearCheckSquares();
                            }
                    }
                }
                if(GameManager.isWhiteTurn)
                {
                    if(Board.GetSquareByName("h1").OccupingPiece != "wR")
                        currentPlayer.CanCastleShort = false;
                    if(Board.GetSquareByName("a1").OccupingPiece != "wR")
                        currentPlayer.CanCastleLong = false;
                }
                else
                {
                    if(Board.GetSquareByName("h8").OccupingPiece != "bR")
                        currentPlayer.CanCastleShort = false;
                    if(Board.GetSquareByName("a8").OccupingPiece != "bR")
                        currentPlayer.CanCastleLong = false;
                }

        }
        public void isPinned(Square pinnedsquare, int r, int f, int length)// r and f are directions
        {
            int targetrank;
            int targetfile;
            Square targetsquare;
            for(int l = 1; l<9-length; l++)
            {
                targetrank = pinnedsquare.Rank + r*l;
                targetfile = pinnedsquare.File + f*l;
                if(targetrank >= 0 && targetrank < 8 && targetfile >= 0 && targetfile < 8)
                {
                    targetsquare = Board.GetSquareByRankAndFile(targetrank, targetfile);
                    if(targetsquare.OccupingPiece != "")
                    {
                        if(targetsquare.OccupingPiece[0] != pinnedsquare.OccupingPiece[0])
                            {
                                if(r*f == 0) //queen or rook
                                {
                                    if(targetsquare.OccupingPiece[1] == 'Q' || targetsquare.OccupingPiece[1] == 'R')
                                        pinnedsquare.isPinned = true;
                                }
                                else//queen or bishop
                                {
                                    if(targetsquare.OccupingPiece[1] == 'Q' || targetsquare.OccupingPiece[1] == 'B')
                                        pinnedsquare.isPinned = true;
                                }

                            }
                            break;
                    }
                }
            }
        }
        void CastleShort(Square king)
        {
            if(currentPlayer.CanCastleShort && currentPlayer.CheckedByHowManyPiece == 0)
            {
                if(king.OccupingPiece[0] == 'w')
                {
                    var fsquare = Board.GetSquareByName("f1");
                    var gsquare = Board.GetSquareByName("g1");
                    if(fsquare.OccupingPiece == "" && gsquare.OccupingPiece =="" && !fsquare.Targetedby.Contains('b') && !gsquare.Targetedby.Contains('b'))
                    {
                        AddMove(new Move(king, gsquare, "f1"));
                    }
                }
                else
                {
                    var fsquare = Board.GetSquareByName("f8");
                    var gsquare = Board.GetSquareByName("g8");
                    if(fsquare.OccupingPiece == "" && gsquare.OccupingPiece =="" && !fsquare.Targetedby.Contains('w') && !gsquare.Targetedby.Contains('w'))
                    {
                        AddMove(new Move(king, gsquare, "f8"));
                    }
                }
            }
        }
        void CastleLong(Square king)
        {
            if(currentPlayer.CanCastleLong && currentPlayer.CheckedByHowManyPiece == 0)
            {
                if(king.OccupingPiece[0] == 'w')
                {
                    var dsquare = Board.GetSquareByName("d1");
                    var csquare = Board.GetSquareByName("c1");
                    if(dsquare.OccupingPiece == "" && csquare.OccupingPiece =="" && !dsquare.Targetedby.Contains('b') && !csquare.Targetedby.Contains('b'))
                    {
                        AddMove(new Move(king, csquare, "d1"));
                    }
                }
                else
                {
                    var dsquare = Board.GetSquareByName("d8");
                    var csquare = Board.GetSquareByName("c8");
                    if(dsquare.OccupingPiece == "" && csquare.OccupingPiece =="" && !dsquare.Targetedby.Contains('w') && !csquare.Targetedby.Contains('w'))
                    {
                        AddMove(new Move(king, csquare, "d8"));
                    }
                }
            }
        }
        public void ClearCheckSquares()
        {
            if(currentPlayer.CheckedByHowManyPiece != 1)
                LegalCheckSquares.Clear();
        }
        public Player CurrentPlayer()
        {
            if(GameManager.isWhiteTurn)
                return WhitePlayer;
            else
                return BlackPlayer;
        }

    }
}