namespace ChessWebsite.DTOs
{
    //--------------------------
    public class Piece
    {
        public Piece(char name)
        {
            Name = name ;
        }
        public char Name;
        public bool isWhite; 
        public byte file;
        public byte rank;
    }
}