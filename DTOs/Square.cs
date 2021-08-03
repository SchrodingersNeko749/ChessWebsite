namespace ChessWebsite.DTOs
{
    //------------------------
    public class Square 
    {
         public Square(int num)
         {
            Rank = num / 8;
            File = num % 8;
            SquareIndex = Rank*8 + File;
            Name = SquareName(num);
            Targetedby = new char[2];
         }
        public string Name {get; set;}
        public string OccupingPiece = "";
        public int Rank {get; set;}
        public int File {get; set;}
        public int SquareIndex {get; set;}
        public char[] Targetedby {get; set;}
        public bool isPinned{get;set;}
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

            var name = new string($"{filenamemap[File]}{Rank+1}");
            return name;
         }
      public void AddToTargetedBy(char color)
      {
         if(color == 'w')
                Targetedby[0] = 'w';
            else
                Targetedby[1] = 'b';
      }
    }
}