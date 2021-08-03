namespace ChessWebsite.Services
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            CanCastleShort = true;
            CanCastleLong = true;
        }
        public int CheckedByHowManyPiece {get;set;}
        public string Name {get;set;}
        public bool CanCastleShort {get;set;}
        public bool CanCastleLong {get; set;}

    }
}