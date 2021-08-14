namespace ChessWebsite.Services
{
    public class Player
    {
        public Player(string name, char color)
        {
            Name = name;
            CanCastleShort = true;
            CanCastleLong = true;
            Color = color;
        }
        public int CheckedByHowManyPiece {get;set;}
        public string Name {get;set;}
        public bool CanCastleShort {get;set;}
        public bool CanCastleLong {get; set;}
        public char Color {get; set;}
    }
}