using System;
using System.Linq;
using System.Collections.Generic;
using ChessWebsite.DTOs;
namespace ChessWebsite.Services
{
    public class GameManager
    {
        public bool isWhiteTurn = true;
        public List<string> LegalMoves = new List<string>();
        public Square[] Board = new Square[64];
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
                Board[i] = new Square(i);
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

            GetSquareByName("a1").OccupingPiece = WhitePlayer.Pieces[8];
            GetSquareByName("b1").OccupingPiece = WhitePlayer.Pieces[10];
            GetSquareByName("c1").OccupingPiece = WhitePlayer.Pieces[12];
            GetSquareByName("d1").OccupingPiece = WhitePlayer.Pieces[14];
            GetSquareByName("e1").OccupingPiece = WhitePlayer.Pieces[15];
            GetSquareByName("f1").OccupingPiece = WhitePlayer.Pieces[13];
            GetSquareByName("g1").OccupingPiece = WhitePlayer.Pieces[11];
            GetSquareByName("h1").OccupingPiece = WhitePlayer.Pieces[9];

            GetSquareByName("a2").OccupingPiece = WhitePlayer.Pieces[0];
            GetSquareByName("b2").OccupingPiece = WhitePlayer.Pieces[1];
            GetSquareByName("c2").OccupingPiece = WhitePlayer.Pieces[2];
            GetSquareByName("d2").OccupingPiece = WhitePlayer.Pieces[3];
            GetSquareByName("e2").OccupingPiece = WhitePlayer.Pieces[4];
            GetSquareByName("f2").OccupingPiece = WhitePlayer.Pieces[5];
            GetSquareByName("g2").OccupingPiece = WhitePlayer.Pieces[6];
            GetSquareByName("h2").OccupingPiece = WhitePlayer.Pieces[7];

            // // black pieces 

            GetSquareByName("a8").OccupingPiece = BlackPlayer.Pieces[8];
            GetSquareByName("b8").OccupingPiece = BlackPlayer.Pieces[10];
            GetSquareByName("c8").OccupingPiece = BlackPlayer.Pieces[12];
            GetSquareByName("d8").OccupingPiece = BlackPlayer.Pieces[14];
            GetSquareByName("e8").OccupingPiece = BlackPlayer.Pieces[15];
            GetSquareByName("f8").OccupingPiece = BlackPlayer.Pieces[13];
            GetSquareByName("g8").OccupingPiece = BlackPlayer.Pieces[11];
            GetSquareByName("h8").OccupingPiece = BlackPlayer.Pieces[9];

            GetSquareByName("a7").OccupingPiece = BlackPlayer.Pieces[0];
            GetSquareByName("b7").OccupingPiece = BlackPlayer.Pieces[1];
            GetSquareByName("c7").OccupingPiece = BlackPlayer.Pieces[2];
            GetSquareByName("d7").OccupingPiece = BlackPlayer.Pieces[3];
            GetSquareByName("e7").OccupingPiece = BlackPlayer.Pieces[4];
            GetSquareByName("f7").OccupingPiece = BlackPlayer.Pieces[5];
            GetSquareByName("g7").OccupingPiece = BlackPlayer.Pieces[6];
            GetSquareByName("h7").OccupingPiece = BlackPlayer.Pieces[7];
            
        }
        public Square GetSquareByName(string name)
        {
            return Board.SingleOrDefault(square => square.Name == name);
        }
        public List<string> GetLegalMoves(Square p)
        {
            

            return LegalMoves;
        }
        public string RandomSquareName()
        {
            return Board[Random.RandomNumber(64)].Name;
        }
        public void RandomMove()
        {
            
        }
    }
}