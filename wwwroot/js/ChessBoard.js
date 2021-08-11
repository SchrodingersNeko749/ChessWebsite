var ServerBoard = []
let Board = []
var PromotionModal
var PickedPiece
var bar = []

function SetupBoard()
{
    isWhiteMove = true
    document.body.style.backgroundColor="#a39483"
    //initiating the picked piece and modal
    PickedPiece = document.getElementById("picked-piece");
    PromotionModal = document.getElementById("PromotionModal");

    //adding the first square object to the board array. this firstSquare element will be used to clone other 63 squares
    firstSquare = document.getElementsByClassName("square")[0]
    firstSquare.style.backgroundImage = "url(/Pieces/bR.png)"

    for(let i = 0; i < 64 ;i++)
    {
        //cloning the first square
        squareElement = firstSquare.cloneNode(true)
        // we make the right index
        index = 63 -i
        r = Math.floor(index/8)
        f = 7 - index % 8
        index = r*8 + f
        // making the square from server data
        squarename = ServerBoard[index].name
        piece = ServerBoard[index].occupingPiece
        if(piece != "")
            squareElement.style.backgroundImage = "url(/Pieces/"+piece+".png)"
        else
            squareElement.style.backgroundImage = "none"
        s = new Square(squarename, piece, squareElement)
        if(Board.length<64)  // means its the first time this array is being filled 
        {
            if(i == 0) // when filling the array the first i is the firstSquare, an element hard coded in html
            {
                s.PieceElement = firstSquare
                Board.push(s)
            }
            else // fill array based on server array
            {
                document.getElementsByClassName("board")[0].appendChild(squareElement);
                Board.push(s)
            }
        }
         else //replace elements 
         {
            Board[i].Piece = piece
            Board[i].PieceElement.style.backgroundImage = squareElement.style.backgroundImage
         }
    }
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
    }
class Square
{
    constructor(name, piece = "none", element)
    {
        this.Name = name
        this.Piece = piece
        this.PieceElement = element
    }
    Piece = "none"
    Name
    PieceElement
}