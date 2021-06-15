using ChessWebsite.Services;
using System.Linq;
namespace ChessWebsite.DTOs
{
    public class Board
    {
        public static Square[] ChessBoard = new Square[64];
        public Player WhitePlayer {get;set;}
        public Player BlackPlayer {get;set;}
        public Board (string whitename, string blackname)
        {
            WhitePlayer = new Player(whitename, true);
            BlackPlayer = new Player(blackname, false);
            SetupBoard();
            SetupPieces();
        
        }
        private void SetupPieces()
        {
            // white pieces
            WhitePlayer.Pieces[8] = GetSquareByName("a1");
            WhitePlayer.Pieces[8].OccupingPiece = "wR";

            WhitePlayer.Pieces[10] = GetSquareByName("b1");
            WhitePlayer.Pieces[10].OccupingPiece = "wN";
            
            WhitePlayer.Pieces[12] = GetSquareByName("c1");
            WhitePlayer.Pieces[12].OccupingPiece = "wB";

            WhitePlayer.Pieces[14] = GetSquareByName("d1");
            WhitePlayer.Pieces[14].OccupingPiece = "wQ";

            WhitePlayer.Pieces[15] = GetSquareByName("e1");
            WhitePlayer.Pieces[15].OccupingPiece = "wK";

            WhitePlayer.Pieces[13] = GetSquareByName("f1");
            WhitePlayer.Pieces[13].OccupingPiece = "wB";

            WhitePlayer.Pieces[11] = GetSquareByName("g1");
            WhitePlayer.Pieces[11].OccupingPiece = "wN";

            WhitePlayer.Pieces[9] = GetSquareByName("h1");
            WhitePlayer.Pieces[9].OccupingPiece = "wR";

            WhitePlayer.Pieces[0] = GetSquareByName("a2");
            WhitePlayer.Pieces[0].OccupingPiece = "wP";
            WhitePlayer.Pieces[1] = GetSquareByName("b2");
            WhitePlayer.Pieces[1].OccupingPiece = "wP";
            WhitePlayer.Pieces[2] = GetSquareByName("c2");
            WhitePlayer.Pieces[2].OccupingPiece = "wP";
            WhitePlayer.Pieces[3] = GetSquareByName("d2");
            WhitePlayer.Pieces[3].OccupingPiece = "wP";
            WhitePlayer.Pieces[4] = GetSquareByName("e2");
            WhitePlayer.Pieces[4].OccupingPiece = "wP";
            WhitePlayer.Pieces[5] = GetSquareByName("f2");
            WhitePlayer.Pieces[5].OccupingPiece = "wP";
            WhitePlayer.Pieces[6] = GetSquareByName("g2");
            WhitePlayer.Pieces[6].OccupingPiece = "wP";
            WhitePlayer.Pieces[7] = GetSquareByName("h2");
            WhitePlayer.Pieces[7].OccupingPiece = "wP";
            
            // // black pieces 
            BlackPlayer.Pieces[8] = GetSquareByName("a8");
            BlackPlayer.Pieces[8].OccupingPiece = "bR";

            BlackPlayer.Pieces[10] = GetSquareByName("b8");
            BlackPlayer.Pieces[10].OccupingPiece = "bN";
            
            BlackPlayer.Pieces[12] = GetSquareByName("c8");
            BlackPlayer.Pieces[12].OccupingPiece = "bB";

            BlackPlayer.Pieces[14] = GetSquareByName("d8");
            BlackPlayer.Pieces[14].OccupingPiece = "bQ";

            BlackPlayer.Pieces[15] = GetSquareByName("e8");
            BlackPlayer.Pieces[15].OccupingPiece = "bK";

            BlackPlayer.Pieces[13] = GetSquareByName("f8");
            BlackPlayer.Pieces[13].OccupingPiece = "bB";

            BlackPlayer.Pieces[11] = GetSquareByName("g8");
            BlackPlayer.Pieces[11].OccupingPiece = "bN";

            BlackPlayer.Pieces[9] = GetSquareByName("h8");
            BlackPlayer.Pieces[9].OccupingPiece = "bR";

            BlackPlayer.Pieces[0] = GetSquareByName("a7");
            BlackPlayer.Pieces[0].OccupingPiece = "bP";
            BlackPlayer.Pieces[1] = GetSquareByName("b7");
            BlackPlayer.Pieces[1].OccupingPiece = "bP";
            BlackPlayer.Pieces[2] = GetSquareByName("c7");
            BlackPlayer.Pieces[2].OccupingPiece = "bP";
            BlackPlayer.Pieces[3] = GetSquareByName("d7");
            BlackPlayer.Pieces[3].OccupingPiece = "bP";
            BlackPlayer.Pieces[4] = GetSquareByName("e7");
            BlackPlayer.Pieces[4].OccupingPiece = "bP";
            BlackPlayer.Pieces[5] = GetSquareByName("f7");
            BlackPlayer.Pieces[5].OccupingPiece = "bP";
            BlackPlayer.Pieces[6] = GetSquareByName("g7");
            BlackPlayer.Pieces[6].OccupingPiece = "bP";
            BlackPlayer.Pieces[7] = GetSquareByName("h7");
            BlackPlayer.Pieces[7].OccupingPiece = "bP";
        }
        private void SetupBoard()
        {
            for (int i = 0; i < 64; i++)
            {
                ChessBoard[i] = new Square(i);
            }
        }
        public static Square GetSquareByName(string name)
        {
            return ChessBoard.SingleOrDefault(square => square.Name == name);
        }

    }
}