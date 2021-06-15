using ChessWebsite.DTOs;
using System.Collections.Generic;
namespace ChessWebsite.Services
{
    //--------------------
    public class Player
    {
        public Player(string name, bool is_white)
        {
            Name = name;
            isWhite = is_white;
            Pieces = new Square[16];
        }
        public void GetLegalMoves()
        {
            foreach (Square piece in Pieces)
            {
                if(piece.OccupingPiece[1] == 'P')
                {
                    var pawn1square = Board.ChessBoard[(piece.Rank-2)*8 + piece.File];
                    var pawn2square = Board.ChessBoard[(piece.Rank-3)*8 + piece.File];
                    var pawncaptureright = Board.ChessBoard[(piece.Rank-2)*8 + piece.File+1];
                    var pawncaptureleft = Board.ChessBoard[(piece.Rank-2)*8 + piece.File-1];
                    if(pawn1square.OccupingPiece == "")
                        LegalMoves.Add(new Move(piece, pawn1square));
                    if(pawn2square.OccupingPiece == "" && piece.Rank == 7)
                        LegalMoves.Add(new Move(piece, pawn2square));
                    if(pawncaptureleft.OccupingPiece != "")
                        LegalMoves.Add(new Move(piece, pawncaptureleft));
                    if(pawncaptureright.OccupingPiece != "")
                        LegalMoves.Add(new Move(piece, pawncaptureright));                    
                }
                
            }
        }
        public bool isChecked = false;
        public string Name;
        public Square [] Pieces;// squares for pieces 
        public List<Move> LegalMoves = new List<Move>();
        private bool isWhite;
    }
}