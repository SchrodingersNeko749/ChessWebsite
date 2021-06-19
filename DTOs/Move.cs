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
         public string CurrentSquareName { get; set; }
         public string TargetSquareName { get; set; }
     }
 }