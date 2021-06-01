using System;
 namespace ChessWebsite.DTOs
 {
     public class Move
     {
         public Move(string currentsquare, char targetsquare)
         {
             //CurrentSquare = GetSquareByName(currentsquare);
         }
         public Square CurrentSquare;
         public Square TargetSquare;
     }
 }