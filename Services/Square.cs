namespace ChessWebsite.Services
{
    //------------------------
    public class Square 
    {
         public Square(int num)
         {
             Name = SquareName(num);
             if (num%2 != 0)
                IsLightSquare = true;
         }
        public string Name;
        public Piece OccupingPiece;
        public bool IsLightSquare = false;
        public static string SquareName(int number)
         {
            var file = number % 8;
            var rank = number / 8 + 1;
            char[] filenamemap = new char[8]; // bad name
            filenamemap[0] = 'a';
            filenamemap[1] = 'b';
            filenamemap[2] = 'c';
            filenamemap[3] = 'd';
            filenamemap[4] = 'e';
            filenamemap[5] = 'f';
            filenamemap[6] = 'g';
            filenamemap[7] = 'h';

            var name = new string($"{filenamemap[file]}{rank}");
            return name;
         }
    }
}