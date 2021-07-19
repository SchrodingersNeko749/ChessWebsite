namespace ChessWebsite.DTOs
{
    //------------------------
    public class Square 
    {
         public Square(int num)
         {
            Rank = num / 8 +1;
            File = num % 8;
            SquareIndex = (Rank-1)*8 + File;
            Name = SquareName(num);
         }
        public string Name {get; set;}
        public string OccupingPiece = "";
        public int Rank {get; set;}
        public int File {get; set;}
        public int SquareIndex {get; set;}
        private string SquareName(int number)
         {
            char[] filenamemap = new char[8]; // bad name
            filenamemap[0] = 'a';
            filenamemap[1] = 'b';
            filenamemap[2] = 'c';
            filenamemap[3] = 'd';
            filenamemap[4] = 'e';
            filenamemap[5] = 'f';
            filenamemap[6] = 'g';
            filenamemap[7] = 'h';

            var name = new string($"{filenamemap[File]}{Rank}");
            return name;
         }

         
    }
}