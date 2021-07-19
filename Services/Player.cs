using ChessWebsite.DTOs;
using System.Linq;
using System.Collections.Generic;
namespace ChessWebsite.Services
{
    //--------------------
    public class Player
    {
        public Player(string name, bool is_white)
        {
            Name = name;
        }
        public bool inCheck = false;
        public string Name;

    }
}