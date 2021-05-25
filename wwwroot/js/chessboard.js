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
function SetupPieces(params) {
    //two black rooks
    Board[0].Piece = "bR"
    document.getElementsByClassName("grid-item")[0].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[7].Piece = "bR"
    document.getElementsByClassName("grid-item")[7].style.backgroundColor = "rgba(0,114,255,0.3)";
    //two black knights
    Board[1].Piece = "bN"
    document.getElementsByClassName("grid-item")[1].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[6].Piece = "bN"
    document.getElementsByClassName("grid-item")[6].style.backgroundColor = "rgba(0,114,255,0.3)";
    //two black bishops
    Board[2].Piece = "bB"
    document.getElementsByClassName("grid-item")[2].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[5].Piece = "bB"
    document.getElementsByClassName("grid-item")[5].style.backgroundColor = "rgba(0,114,255,0.3)";
    //black queen and king
    Board[3].Piece = "bQ"
    document.getElementsByClassName("grid-item")[3].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[4].Piece = "bK"
    document.getElementsByClassName("grid-item")[4].style.backgroundColor = "rgba(0,114,255,0.3)";
    //black pawns
    Board[8].Piece = "bP"
    document.getElementsByClassName("grid-item")[8].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[9].Piece = "bP"
    document.getElementsByClassName("grid-item")[9].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[10].Piece = "bP"
    document.getElementsByClassName("grid-item")[10].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[11].Piece = "bP"
    document.getElementsByClassName("grid-item")[11].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[12].Piece = "bP"
    document.getElementsByClassName("grid-item")[12].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[13].Piece = "bP"
    document.getElementsByClassName("grid-item")[13].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[14].Piece = "bP"
    document.getElementsByClassName("grid-item")[14].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[15].Piece = "bP"
    document.getElementsByClassName("grid-item")[15].style.backgroundColor = "rgba(0,114,255,0.3)";
    
    //two white rooks
    Board[63-0].Piece = "bR"
    document.getElementsByClassName("grid-item")[63].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-7].Piece = "bR"
    document.getElementsByClassName("grid-item")[63-7].style.backgroundColor = "rgba(0,114,255,0.3)";
    //two white knights
    Board[63-1].Piece = "bN"
    document.getElementsByClassName("grid-item")[63-1].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-6].Piece = "bN"
    document.getElementsByClassName("grid-item")[63-6].style.backgroundColor = "rgba(0,114,255,0.3)";
    //two white bishops
    Board[63-2].Piece = "bB"
    document.getElementsByClassName("grid-item")[63-2].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-5].Piece = "bB"
    document.getElementsByClassName("grid-item")[63-5].style.backgroundColor = "rgba(0,114,255,0.3)";
    //white queen and king
    Board[63-3].Piece = "bQ"
    document.getElementsByClassName("grid-item")[63-3].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-4].Piece = "bK"
    document.getElementsByClassName("grid-item")[63-4].style.backgroundColor = "rgba(0,114,255,0.3)";
    //white pawns
    Board[63-8].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-8].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-9].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-9].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-10].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-10].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-11].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-11].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-12].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-12].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-13].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-13].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-14].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-14].style.backgroundColor = "rgba(0,114,255,0.3)";
    Board[63-15].Piece = "bP"
    document.getElementsByClassName("grid-item")[63-15].style.backgroundColor = "rgba(0,114,255,0.3)";
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