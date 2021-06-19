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
         public Move(string currentsquare, string targetsquare, string promote)
         {
             CurrentSquareName = currentsquare;
             TargetSquareName = targetsquare;
             PromoteToPiece = promote;
         }
         public string CurrentSquareName { get; set; }
         public string TargetSquareName { get; set; }
         public string PromoteToPiece {get; set;}
     }
 }