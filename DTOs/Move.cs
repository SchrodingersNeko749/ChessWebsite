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
         public Move(Square currentsquare, Square targetsquare, bool check){
             CurrentSquare = currentsquare;
             TargetSquare = targetsquare;
         }
         public Square CurrentSquare { get; set; }
         public Square TargetSquare { get; set; }
         public string SpecialMove {get; set;} //promotion and castle
     }
 }