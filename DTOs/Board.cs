using ChessWebsite.Services;
using System.Linq;
namespace ChessWebsite.DTOs
{
    public static class Board
    {
        public static Square[] ChessBoard = new Square[64];
        public static Player WhitePlayer {get;set;}
        public static Player BlackPlayer {get;set;}
        static Board ()
        {
            SetupBoard();
            SetupPieces();
        }
        public static void SetupPieces()
        {
            // white pieces
            GetSquareByName("a1").OccupingPiece = "wR";
            GetSquareByName("b1").OccupingPiece = "wN";
            GetSquareByName("c1").OccupingPiece = "wB";
            GetSquareByName("d1").OccupingPiece = "wQ";
            GetSquareByName("e1").OccupingPiece = "wK";
            GetSquareByName("f1").OccupingPiece = "wB";
            GetSquareByName("g1").OccupingPiece = "wN";
            GetSquareByName("h1").OccupingPiece = "wR";

            GetSquareByName("a2").OccupingPiece = "wP";
            GetSquareByName("b2").OccupingPiece = "wP";
            GetSquareByName("c2").OccupingPiece = "wP";
            GetSquareByName("d2").OccupingPiece = "wP";
            GetSquareByName("e2").OccupingPiece = "wP";
            GetSquareByName("f2").OccupingPiece = "wP";
            GetSquareByName("g2").OccupingPiece = "wP";
            GetSquareByName("h2").OccupingPiece = "wP";

            //black pieces 
            GetSquareByName("a8").OccupingPiece = "bR";
            GetSquareByName("b8").OccupingPiece = "bN";
            GetSquareByName("c8").OccupingPiece = "bB";
            GetSquareByName("d8").OccupingPiece = "bQ";
            GetSquareByName("e8").OccupingPiece = "bK";
            GetSquareByName("f8").OccupingPiece = "bB";
            GetSquareByName("g8").OccupingPiece = "bN";
            GetSquareByName("h8").OccupingPiece = "bR";

            GetSquareByName("a7").OccupingPiece = "bP";
            GetSquareByName("b7").OccupingPiece = "bP";
            GetSquareByName("c7").OccupingPiece = "bP";
            GetSquareByName("d7").OccupingPiece = "bP";
            GetSquareByName("e7").OccupingPiece = "bP";
            GetSquareByName("f7").OccupingPiece = "bP";
            GetSquareByName("g7").OccupingPiece = "bP";
            GetSquareByName("h7").OccupingPiece = "bP";
        }
        public static void SetupBoard()
        {
            GameManager.isWhiteTurn = true;
            for (int i = 0; i < 64; i++)
            {
                ChessBoard[i] = new Square(i);
            }
        }
        public static Square GetSquareByName(string name)
        {
            return ChessBoard.SingleOrDefault(square => square.Name == name);
        }
        public static Square GetSquareByRankAndFile(int rank, int file)
        {
            return ChessBoard[rank*8 + file];
        }
    }
}