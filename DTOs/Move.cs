using System;
 namespace ChessWebsite.DTOs
 {
     public class Move
     {
         public Move(string currentsquare, string targetsquare)
         {
             CurrentSquareName = currentsquare;
             TargetSquareName = targetsquare;
         }
         public Move(string currentsquare, string targetsquare, string specialmove)
         {
             CurrentSquareName = currentsquare;
             TargetSquareName = targetsquare;
             SpecialMove = specialmove;
         }
         public string CurrentSquareName { get; set; }// this needs to become type Move
         public string TargetSquareName { get; set; }// this needs to become type Move
         public string SpecialMove {get; set;}
     }
 }