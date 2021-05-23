namespace ChessWebsite.Services
{
    //--------------------
    public class Player
    {
        public Player(string name, bool is_white)
        {
            Name = name;
            Turn = is_white;
        }
        public void GivePieces()
        {   
            Pieces = new Piece[64];
            Pieces[0] = new Piece('P');//eight pawns
            Pieces[1] = new Piece('P');
            Pieces[2] = new Piece('P'); 
            Pieces[3] = new Piece('P');
            Pieces[4] = new Piece('P');
            Pieces[5] = new Piece('P');
            Pieces[6] = new Piece('P');
            Pieces[7] = new Piece('P');
            Pieces[8] = new Piece('R');//two rooks
            Pieces[9] = new Piece('R');
            Pieces[10] = new Piece('N');//two knights
            Pieces[11] = new Piece('N');
            Pieces[12] = new Piece('B');//two bishops
            Pieces[13] = new Piece('B');
            Pieces[14] = new Piece('Q');//queen
            Pieces[15] = new Piece('K');//king
        }
        public string Name;
        public bool Turn;
        public Piece [] Pieces;
    }
}