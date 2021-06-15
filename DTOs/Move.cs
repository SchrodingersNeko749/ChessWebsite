using System;
 namespace ChessWebsite.DTOs
 {
     public class Move
     {
         public Move(Square currentsquare, Square targetsquare)
         {
             CurrentSquare = currentsquare.Name;
             TargetSquare = targetsquare.Name;
         }
         public string CurrentSquare { get; set; }
         public string TargetSquare { get; set; }
     }
 }