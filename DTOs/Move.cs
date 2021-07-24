using System;
 namespace ChessWebsite.DTOs
 {
     public class Move
     {
         public Move(Square currentsquare, Square targetsquare)
         {
             CurrentSquare = currentsquare;
             TargetSquare = targetsquare;
         }
         public Move(Square currentsquare, Square targetsquare, string specialmove)
         {
             CurrentSquare = currentsquare;
             TargetSquare = targetsquare;
             SpecialMove = specialmove;
         }
         public Square CurrentSquare { get; set; }// this needs to become type Move
         public Square TargetSquare { get; set; }// this needs to become type Move
         public string SpecialMove {get; set;}
     }
 }