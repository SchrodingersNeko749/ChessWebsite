using System;
using System.Collections.Generic;

namespace ChessWebsite.Services
{
    public class GameManager
    {
        public bool isWhiteTurn = true;
        public Dictionary<string,Square> Board = new Dictionary<string, Square>();
        public Player WhitePlayer;
        public Player BlackPlayer;
        public GameManager()
        {
            var whitename = "neko";
            var blackname = "alu";
            SetupPlayers(whitename, blackname);
            SetupBoard();
            SetupPieces();
        }
        private void SetupBoard()
        {
            for (int i = 0; i < 64; i++)
            {
                Board.Add(Square.SquareName(i), new Square(i));
            }
        }
        private void SetupPlayers(string whitename, string blackname)
        {
            WhitePlayer = new Player(whitename, true);
            BlackPlayer = new Player(blackname, false);
        }
        private void SetupPieces()
        {
            WhitePlayer.GivePieces();
            BlackPlayer.GivePieces();

            // white pieces

            Board["a1"].OccupingPiece = WhitePlayer.Pieces[8];
            Board["b1"].OccupingPiece = WhitePlayer.Pieces[10];
            Board["c1"].OccupingPiece = WhitePlayer.Pieces[12];
            Board["d1"].OccupingPiece = WhitePlayer.Pieces[14];
            Board["e1"].OccupingPiece = WhitePlayer.Pieces[15];
            Board["f1"].OccupingPiece = WhitePlayer.Pieces[13];
            Board["g1"].OccupingPiece = WhitePlayer.Pieces[11];
            Board["h1"].OccupingPiece = WhitePlayer.Pieces[9];

            Board["a2"].OccupingPiece = WhitePlayer.Pieces[0];
            Board["b2"].OccupingPiece = WhitePlayer.Pieces[1];
            Board["c2"].OccupingPiece = WhitePlayer.Pieces[2];
            Board["d2"].OccupingPiece = WhitePlayer.Pieces[3];
            Board["e2"].OccupingPiece = WhitePlayer.Pieces[4];
            Board["f2"].OccupingPiece = WhitePlayer.Pieces[5];
            Board["g2"].OccupingPiece = WhitePlayer.Pieces[6];
            Board["h2"].OccupingPiece = WhitePlayer.Pieces[7];

            // black pieces 

            Board["a8"].OccupingPiece = BlackPlayer.Pieces[8];
            Board["b8"].OccupingPiece = BlackPlayer.Pieces[10];
            Board["c8"].OccupingPiece = BlackPlayer.Pieces[12];
            Board["d8"].OccupingPiece = BlackPlayer.Pieces[14];
            Board["e8"].OccupingPiece = BlackPlayer.Pieces[15];
            Board["f8"].OccupingPiece = BlackPlayer.Pieces[13];
            Board["g8"].OccupingPiece = BlackPlayer.Pieces[11];
            Board["h8"].OccupingPiece = BlackPlayer.Pieces[9];

            Board["a7"].OccupingPiece = BlackPlayer.Pieces[0];
            Board["b7"].OccupingPiece = BlackPlayer.Pieces[1];
            Board["c7"].OccupingPiece = BlackPlayer.Pieces[2];
            Board["d7"].OccupingPiece = BlackPlayer.Pieces[3];
            Board["e7"].OccupingPiece = BlackPlayer.Pieces[4];
            Board["f7"].OccupingPiece = BlackPlayer.Pieces[5];
            Board["g7"].OccupingPiece = BlackPlayer.Pieces[6];
            Board["h7"].OccupingPiece = BlackPlayer.Pieces[7];
            
        }
    }
}