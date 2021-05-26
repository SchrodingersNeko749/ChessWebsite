let Board = []
function SetupBoard()
{
    for (let i = 0; i < 64; i++) 
    {   
        file = i & 8
        rank = (i/8) + 1
        s = new Square("newsquare", "R")
        Board.push(s)
    }
    SetupPieces()
}
function SetupPieces() {
    //two black rooks
    Board[0].Piece = "bR"
    Board[0].PieceElement = document.getElementsByClassName("grid-item")[0]
    Board[0].PieceElement.style.backgroundImage = "url(/Pieces/BlackRook.png)";
    Board[7].Piece = "bR"
    Board[7].PieceElement = document.getElementsByClassName("grid-item")[7]
    Board[7].PieceElement.style.backgroundImage = "url(/Pieces/BlackRook.png)";
    //two black knights
    Board[1].Piece = "bN"
    Board[1].PieceElement = document.getElementsByClassName("grid-item")[1]
    Board[1].PieceElement.style.backgroundImage = "url(/Pieces/BlackKnight.png)";
    Board[6].Piece = "bN"
    Board[6].PieceElement = document.getElementsByClassName("grid-item")[6]
    Board[6].PieceElement.style.backgroundImage = "url(/Pieces/BlackKnight.png)";
    //two black bishops
    Board[2].Piece = "bB"
    Board[2].PieceElement = document.getElementsByClassName("grid-item")[2]
    Board[2].PieceElement.style.backgroundImage = "url(/Pieces/BlackBishop.png)";
    Board[5].Piece = "bB"
    Board[5].PieceElement = document.getElementsByClassName("grid-item")[5]
    Board[5].PieceElement.style.backgroundImage = "url(/Pieces/BlackBishop.png)";
    //black queen and king
    Board[3].Piece = "bQ"
    Board[3].PieceElement = document.getElementsByClassName("grid-item")[3]
    Board[3].PieceElement.style.backgroundImage = "url(/Pieces/BlackQueen.png)";
    Board[4].Piece = "bK"
    Board[4].PieceElement = document.getElementsByClassName("grid-item")[4]
    Board[4].PieceElement.style.backgroundImage = "url(/Pieces/BlackKing.png)";
    //black pawns
    Board[8].Piece = "bP"
    Board[8].PieceElement = document.getElementsByClassName("grid-item")[8]
    Board[8].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";

    Board[9].Piece = "bP"
    Board[9].PieceElement = document.getElementsByClassName("grid-item")[9]
    Board[9].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";

    Board[10].Piece = "bP"
    Board[10].PieceElement = document.getElementsByClassName("grid-item")[10]
    Board[10].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";

    Board[11].Piece = "bP"
    Board[11].PieceElement = document.getElementsByClassName("grid-item")[11]
    Board[11].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";

    Board[12].Piece = "bP"
    Board[12].PieceElement = document.getElementsByClassName("grid-item")[12]
    Board[12].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";

    Board[13].Piece = "bP"
    Board[13].PieceElement = document.getElementsByClassName("grid-item")[13]
    Board[13].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";

    Board[14].Piece = "bP"
    Board[14].PieceElement = document.getElementsByClassName("grid-item")[14]
    Board[14].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";

    Board[15].Piece = "bP"
    Board[15].PieceElement = document.getElementsByClassName("grid-item")[15]
    Board[15].PieceElement.style.backgroundImage = "url(/Pieces/BlackPawn.png)";
    
    //two white rooks
    Board[63].Piece = "wR"
    Board[63].PieceElement = document.getElementsByClassName("grid-item")[63]
    Board[63].PieceElement.style.backgroundImage = "url(/Pieces/WhiteRook.png)";
    Board[63-7].Piece = "wR"
    Board[63-7].PieceElement = document.getElementsByClassName("grid-item")[63-7]
    Board[63-7].PieceElement.style.backgroundImage = "url(/Pieces/WhiteRook.png)";
    //two white knights
    Board[63-1].Piece = "wN"
    Board[63-1].PieceElement = document.getElementsByClassName("grid-item")[63-1]
    Board[63-1].PieceElement.style.backgroundImage = "url(/Pieces/WhiteKnight.png)";
    Board[63-6].Piece = "wN"
    Board[63-6].PieceElement = document.getElementsByClassName("grid-item")[63-6]
    Board[63-6].PieceElement.style.backgroundImage = "url(/Pieces/WhiteKnight.png)";
    //two white bishops
    Board[63-2].Piece = "wB"
    Board[63-2].PieceElement = document.getElementsByClassName("grid-item")[63-2]
    Board[63-2].PieceElement.style.backgroundImage = "url(/Pieces/WhiteBishop.png)";
    Board[63-5].Piece = "wB"
    Board[63-5].PieceElement = document.getElementsByClassName("grid-item")[63-5]
    Board[63-5].PieceElement.style.backgroundImage = "url(/Pieces/WhiteBishop.png)";
    //white queen and king
    Board[63-3].Piece = "wQ"
    Board[63-3].PieceElement = document.getElementsByClassName("grid-item")[63-4]
    Board[63-3].PieceElement.style.backgroundImage = "url(/Pieces/WhiteQueen.png)";
    Board[63-4].Piece = "wK"
    Board[63-4].PieceElement = document.getElementsByClassName("grid-item")[63-3]
    Board[63-4].PieceElement.style.backgroundImage = "url(/Pieces/WhiteKing.png)";
    //white pawns
    Board[63-8].Piece = "wP"
    Board[63-8].PieceElement = document.getElementsByClassName("grid-item")[63-8]
    Board[63-8].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-9].Piece = "wP"
    Board[63-9].PieceElement = document.getElementsByClassName("grid-item")[63-9]
    Board[63-9].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-10].Piece = "wP"
    Board[63-10].PieceElement = document.getElementsByClassName("grid-item")[63-10]
    Board[63-10].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-11].Piece = "wP"
    Board[63-11].PieceElement = document.getElementsByClassName("grid-item")[63-11]
    Board[63-11].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-12].Piece = "wP"
    Board[63-12].PieceElement = document.getElementsByClassName("grid-item")[63-12]
    Board[63-12].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-13].Piece = "wP"
    Board[63-13].PieceElement = document.getElementsByClassName("grid-item")[63-13]
    Board[63-13].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-14].Piece = "wP"
    Board[63-14].PieceElement = document.getElementsByClassName("grid-item")[63-14]
    Board[63-14].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
    Board[63-15].Piece = "wP"
    Board[63-15].PieceElement = document.getElementsByClassName("grid-item")[63-15]
    Board[63-15].PieceElement.style.backgroundImage = "url(/Pieces/WhitePawn.png)";
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
    PieceElement
}