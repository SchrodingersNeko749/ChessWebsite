let Board = []
var PromotionModal;
var PickedPiece

function SetupBoard()
{
    //initiating the picked piece and modal
    PickedPiece = document.getElementById("picked-piece");
    PromotionModal = document.getElementById("PromotionModal");
    //if square elements exists setup pieces 
    if (document.getElementsByClassName("grid-item").length == 64) {
        SetupPieces()
    } else {
        //setup board array
        Board.splice(0,Board.length)
        //this is to name square names. i need to map a number to alphabet
        filenamemap = []
        filenamemap[0] = 'a';
        filenamemap[1] = 'b';
        filenamemap[2] = 'c';
        filenamemap[3] = 'd';
        filenamemap[4] = 'e';
        filenamemap[5] = 'f';
        filenamemap[6] = 'g';
        filenamemap[7] = 'h';
        //adding the first square object to the board array. this firstSquare element will be used to clone other 63 squares
        firstSquare = document.getElementsByClassName("grid-item")[0]

        Board.push(new Square("a8", "", firstSquare))
        for (let i = 1; i < 64; i++) 
        {   
            file = i % 8
            rank = Math.floor(((63 - i)/8) + 1) 
            file = filenamemap[file]
            rank = "" + rank.toString()
            name = file + rank
    
            squareElement = firstSquare.cloneNode(true)
            document.getElementsByClassName("grid-container")[0].appendChild(squareElement);
    
            s = new Square(name, "", squareElement)
            Board.push(s)    
        }
        SetupPieces()
        //GetMoveFromAPI()
    }
}
function SetupPieces() {
    //making every square between 3rd rank and 5th rank empty
    for (let i = 16; i < 48; i++) {
        Board[i].Piece = ""
        Board[i].PieceElement.style.backgroundImage = "none"
    }
    //two black rooks
    //bR
    Board[0].Piece = "bR"
    Board[0].PieceElement.style.backgroundImage = "url(/Pieces/bR.png)";
    Board[7].Piece = "bR"
    Board[7].PieceElement.style.backgroundImage = "url(/Pieces/bR.png)";
    //two black knights
    Board[1].Piece = "bN"
    Board[1].PieceElement.style.backgroundImage = "url(/Pieces/bN.png)";
    Board[6].Piece = "bN"
    Board[6].PieceElement.style.backgroundImage = "url(/Pieces/bN.png)";
    //two black bishops
    Board[2].Piece = "bB"
    Board[2].PieceElement.style.backgroundImage = "url(/Pieces/bB.png)";
    Board[5].Piece = "bB"
    Board[5].PieceElement.style.backgroundImage = "url(/Pieces/bB.png)";
    //black queen and king
    Board[3].Piece = "bQ"
    Board[3].PieceElement.style.backgroundImage = "url(/Pieces/bQ.png)";
    Board[4].Piece = "bK"
    Board[4].PieceElement.style.backgroundImage = "url(/Pieces/bK.png)";
    //black pawns
    Board[8].Piece = "bP"
    Board[8].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";

    Board[9].Piece = "bP"
    Board[9].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";

    Board[10].Piece = "bP"
    Board[10].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";

    Board[11].Piece = "bP"
    Board[11].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";

    Board[12].Piece = "bP"
    Board[12].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";

    Board[13].Piece = "bP"
    Board[13].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";

    Board[14].Piece = "bP"
    Board[14].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";

    Board[15].Piece = "bP"
    Board[15].PieceElement.style.backgroundImage = "url(/Pieces/bP.png)";
    
    //two white rooks
    Board[63].Piece = "wR"
    Board[63].PieceElement.style.backgroundImage = "url(/Pieces/wR.png)";
    Board[63-7].Piece = "wR"
    Board[63-7].PieceElement.style.backgroundImage = "url(/Pieces/wR.png)";
    //two white knights
    Board[63-1].Piece = "wN"
    Board[63-1].PieceElement.style.backgroundImage = "url(/Pieces/wN.png)";
    Board[63-6].Piece = "wN"
    Board[63-6].PieceElement.style.backgroundImage = "url(/Pieces/wN.png)";
    //two white bishops
    Board[63-2].Piece = "wB"
    Board[63-2].PieceElement.style.backgroundImage = "url(/Pieces/wB.png)";
    Board[63-5].Piece = "wB"
    Board[63-5].PieceElement.style.backgroundImage = "url(/Pieces/wB.png)";
    //white queen and king
    Board[63-4].Piece = "wQ"
    Board[63-4].PieceElement.style.backgroundImage = "url(/Pieces/wQ.png)";

    Board[63-3].Piece = "wK"
    Board[63-3].PieceElement.style.backgroundImage = "url(/Pieces/wK.png)";
    //white pawns
    Board[63-8].Piece = "wP"
    Board[63-8].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";

    Board[63-9].Piece = "wP"
    Board[63-9].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";

    Board[63-10].Piece = "wP"
    Board[63-10].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";

    Board[63-11].Piece = "wP"
    Board[63-11].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";

    Board[63-12].Piece = "wP"
    Board[63-12].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";

    Board[63-13].Piece = "wP"
    Board[63-13].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";

    Board[63-14].Piece = "wP"
    Board[63-14].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";

    Board[63-15].Piece = "wP"
    Board[63-15].PieceElement.style.backgroundImage = "url(/Pieces/wP.png)";
}
function GetSquare(squarename)
{
    for (let i = 0; i < Board.length; i++) {
        if(squarename == Board[i].Name)     
            return Board[i]
    }
}
function ColorSquare(squarename, color)
{
    sq = GetSquare(squarename)
    sq.PieceElement.style.backgroundColor = color
}
function deColorBoard()
{
    for (let i = 0; i < Board.length; i++) {
        Board[i].PieceElement.style.backgroundColor = "transparent"
        Board[i].PieceElement.style.border = "none"
        Board[i].PieceElement.style.borderColor = "transparent"
    }
}
function GetLegalMovebySquare(tragetsquarename)
{
    let foundmove;
    LegalMoves.forEach(move => {
    if(move.targetSquare.name == tragetsquarename)
        foundmove = move
    })
    if(foundmove != undefined)
        return foundmove;
    else
        console.log("ChessBoard.js.GetLegalMovebySquare : targetsquare not found")
    }
function ModaiSelectPiece(modaiselectedpiece)
{
    pieceurl = 'url("'+ modaiselectedpiece.currentSrc.slice(22) + '")'
    if(isWhiteMove)
        pieceurl = pieceurl.replace(/w/, 'b')
    PromotionModal.style.display = "none"
    TargetedSquare.PieceElement.style.backgroundImage = pieceurl
    SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name, ""+pieceurl[13]+pieceurl[14])
}
class Square
{
    constructor(name, piece = "none", element)
    {
        this.Name = name
        this.Piece = piece
        this.PieceElement = element
    }
    Piece = ""
    Name
    PieceElement
}