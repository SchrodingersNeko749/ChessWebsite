let Board = []
function SetupBoard()
{
    for (let i = 0; i < 64; i++) 
    {   
        file = i & 8
        s = new Square(name, "R")
        Board.push(s)
    }
    SetupPieces()
}
function SetupPieces() {
    //two black rooks
    Board[0].Piece = "bR"
    document.getElementsByClassName("grid-item")[0].style.backgroundImage = "url(/Pieces/BlackRook.png)";
    Board[7].Piece = "bR"
    document.getElementsByClassName("grid-item")[7].style.backgroundImage = "url(/Pieces/BlackRook.png)";
    //two black knights
    Board[1].Piece = "bN"
    document.getElementsByClassName("grid-item")[1].style.backgroundImage = "url(/Pieces/BlackKnight.png)";
    Board[6].Piece = "bN"
    document.getElementsByClassName("grid-item")[6].style.backgroundImage = "url(/Pieces/BlackKnight.png)";
    //two black bishops
    Board[2].Piece = "bB"
    document.getElementsByClassName("grid-item")[2].style.backgroundImage = "url(/Pieces/BlackBishop.png)";
    Board[5].Piece = "bB"
    document.getElementsByClassName("grid-item")[5].style.backgroundImage = "url(/Pieces/BlackBishop.png)";
    //black queen and king
    Board[3].Piece = "bQ"
    document.getElementsByClassName("grid-item")[3].style.backgroundImage = "url(/Pieces/BlackQueen.png)";
    Board[4].Piece = "bK"
    document.getElementsByClassName("grid-item")[4].style.backgroundImage = "url(/Pieces/BlackKing.png)";
    //black pawns
    Board[8].Piece = "bP"
    document.getElementsByClassName("grid-item")[8].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    Board[9].Piece = "bP"
    document.getElementsByClassName("grid-item")[9].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    Board[10].Piece = "bP"
    document.getElementsByClassName("grid-item")[10].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    Board[11].Piece = "bP"
    document.getElementsByClassName("grid-item")[11].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    Board[12].Piece = "bP"
    document.getElementsByClassName("grid-item")[12].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    Board[13].Piece = "bP"
    document.getElementsByClassName("grid-item")[13].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    Board[14].Piece = "bP"
    document.getElementsByClassName("grid-item")[14].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    Board[15].Piece = "bP"
    document.getElementsByClassName("grid-item")[15].style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    
    //two white rooks
    Board[63-0].Piece = "wR"
    document.getElementsByClassName("grid-item")[63].style.backgroundImage = "url(/Pieces/WhiteRook.png)";
    Board[63-7].Piece = "wR"
    document.getElementsByClassName("grid-item")[63-7].style.backgroundImage = "url(/Pieces/WhiteRook.png)";
    //two white knights
    Board[63-1].Piece = "wN"
    document.getElementsByClassName("grid-item")[63-1].style.backgroundImage = "url(/Pieces/WhiteKnight.png)";
    Board[63-6].Piece = "wN"
    document.getElementsByClassName("grid-item")[63-6].style.backgroundImage = "url(/Pieces/WhiteKnight.png)";
    //two white bishops
    Board[63-2].Piece = "wB"
    document.getElementsByClassName("grid-item")[63-2].style.backgroundImage = "url(/Pieces/WhiteBishop.png)";
    Board[63-5].Piece = "wB"
    document.getElementsByClassName("grid-item")[63-5].style.backgroundImage = "url(/Pieces/WhiteBishop.png)";
    //white queen and king
    Board[63-3].Piece = "wQ"
    document.getElementsByClassName("grid-item")[63-4].style.backgroundImage = "url(/Pieces/WhiteQueen.png)";
    Board[63-4].Piece = "wK"
    document.getElementsByClassName("grid-item")[63-3].style.backgroundImage = "url(/Pieces/WhiteKing.png)";
    //white pawns
    Board[63-8].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-8].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-9].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-9].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-10].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-10].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-11].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-11].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-12].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-12].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-13].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-13].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-14].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-14].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-15].Piece = "wP"
    document.getElementsByClassName("grid-item")[63-15].style.backgroundImage = "url(/Pieces/WhitePawn.png)";
}
function hover(square)
{   
    square.style.backgroundColor = "rgba(0,114,255,0.3)";
}
function reset(square)
{
    square.style.backgroundColor = "rgba(255, 255, 255, 0)";
}
class Square
{
    constructor(name, piece = "none")
    {
        this.Name = name
        this.Piece = piece
    }
    Piece = ""
    Name = ""
}