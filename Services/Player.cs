namespace ChessWebsite.Services
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }
        public int CheckedByHowManyPiece;
        public string Name;

    }
}