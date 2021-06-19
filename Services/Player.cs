using ChessWebsite.DTOs;
using System.Linq;
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
        public void CalculateLegalMoves()
        {
            LegalMoves.Clear();
            foreach (Square piece in Pieces)
            {
                if(piece == null || piece.OccupingPiece == "")
                {
                    continue;
                }
                if(piece.OccupingPiece[1] == 'P')
                {
                    CalculatePawnMoves(piece);              
                }
                
            }
        }
        private void CalculatePawnMoves(Square pawn)
        {
            if(isWhite) //pawns go up
            {
                var pawn1square = Board.ChessBoard[((pawn.Rank-1)+1)*8 + pawn.File];
                var pawn2square = Board.ChessBoard[((pawn.Rank-1)+2)*8 + pawn.File];
                var pawncaptureright = Board.ChessBoard[((pawn.Rank-1)+1)*8 + pawn.File+1];
                var pawncaptureleft = Board.ChessBoard[((pawn.Rank-1)+1)*8 + pawn.File-1];
                if(pawn1square.OccupingPiece == "")
                    LegalMoves.Add(new Move(pawn.Name, pawn1square.Name));
                if(pawn1square.OccupingPiece == "" && pawn2square.OccupingPiece == "" && pawn.Rank == 2)
                    LegalMoves.Add(new Move(pawn.Name, pawn2square.Name));
                if(pawncaptureleft.OccupingPiece != "")     
                {
                    if(pawncaptureleft.OccupingPiece[0] == 'b')
                        LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name));    
                } 
                if(pawncaptureright.OccupingPiece != "")     
                {
                    if(pawncaptureright.OccupingPiece[0] == 'b')
                        LegalMoves.Add(new Move(pawn.Name, pawncaptureright.Name));    
                }         
                 
            }
            else // pawns go down
            {
                var pawn1square = Board.ChessBoard[((pawn.Rank-1)-1)*8 + pawn.File];
                var pawn2square = Board.ChessBoard[((pawn.Rank-1)-2)*8 + pawn.File];
                var pawncaptureright = Board.ChessBoard[((pawn.Rank-1)-1)*8 + pawn.File+1];
                var pawncaptureleft = Board.ChessBoard[((pawn.Rank-1)-1)*8 + pawn.File-1];

                if(pawn1square.OccupingPiece == "")
                    LegalMoves.Add(new Move(pawn.Name, pawn1square.Name));
                if(pawn1square.OccupingPiece == "" && pawn2square.OccupingPiece == "" && pawn.Rank == 7)
                    LegalMoves.Add(new Move(pawn.Name, pawn2square.Name));
                if(pawn1square.OccupingPiece == "")
                    LegalMoves.Add(new Move(pawn.Name, pawn1square.Name));
                if(pawn1square.OccupingPiece == "" && pawn2square.OccupingPiece == "" && pawn.Rank == 2)
                    LegalMoves.Add(new Move(pawn.Name, pawn2square.Name));
                if(pawncaptureleft.OccupingPiece != "")     
                {
                    if(pawncaptureleft.OccupingPiece[0] == 'w')
                        LegalMoves.Add(new Move(pawn.Name, pawncaptureleft.Name));    
                } 
                if(pawncaptureright.OccupingPiece != "")     
                {
                    if(pawncaptureright.OccupingPiece[0] == 'w')
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
        public bool isChecked = false;
        public string Name;
        public Square [] Pieces;// squares for pieces 
        public List<Move> LegalMoves = new List<Move>();
        private bool isWhite;
    }
}