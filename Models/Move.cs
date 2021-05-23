using System;

 namespace ChessWebsite.Models
 {
     public class Move
     {
         public Move(string movename)//doesnt recognize pawns 
         {
             Piece = movename[0];
             if(movename[1] == 'x')
             {
                 Capture = true;
                 Notation = movename.Substring(2);
             }
             else{
                 Capture = false;
                 Notation = movename.Substring(1);
             }
         }
         public char Piece;
         public string Notation;
         public bool Capture;
     }
 }