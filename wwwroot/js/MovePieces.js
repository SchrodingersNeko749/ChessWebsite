isWhiteMove = true
let SelectedSquare = ""
let TargetedSquare = ""
let LegalSquares = []
let LegalMoves = []
let promotingpiece = ""
//------------------------------------------------------------------------
function Drag(ev)//on drag over
{
  PickedPiece.style.top = ev.clientY - 50
  PickedPiece.style.left = ev.clientX - 50
}
//------------------------------------------------------------------------
function DragStart(ev) {
  //find the Selected square
  x = Math.floor((ev.clientX - Board[0].PieceElement.offsetLeft) / 100)
  y = Math.floor((ev.clientY - Board[0].PieceElement.offsetTop) / 100)

  index = y*8 + x
  //only get moves from api if the selected square is currenntly empty (no square has been touched) or if the selected square has changed (touching different pieces)
  if(SelectedSquare == "" || SelectedSquare != Board[index])
  {
    LegalSquares.splice(0, LegalSquares.length)
    SelectedSquare = Board[index]
    GetMoveFromAPI(SelectedSquare.Name)
  }
  //ColorLegalSquares()
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64

  //if its white's move
  if (isWhiteMove && ev.target.style.backgroundImage[13] == 'w') {
      PickedPiece.style.backgroundImage = ev.target.style.backgroundImage
      ev.target.style.backgroundImage = "none"

      document.onmousemove = Drag
      document.onmouseup = DragEnd
  }
  else{
    //if its blacks move
    if(!isWhiteMove && ev.target.style.backgroundImage[13] == 'b'){
      PickedPiece.style.backgroundImage = ev.target.style.backgroundImage
      ev.target.style.backgroundImage = "none"

      document.onmousemove = Drag
      document.onmouseup = DragEnd
    }
    else
      console.log("its not your move")
  }
 }
 //------------------------------------------------------------------------
 function DragEnd(ev) {
  deColorBoard()
  document.onmouseup = null
  document.onmousemove = null
  
  x = Math.floor((ev.clientX - Board[0].PieceElement.offsetLeft) / 100)
  y = Math.floor((ev.clientY - Board[0].PieceElement.offsetTop) / 100)

  index = y*8 + x
  TargetedSquare = Board[index]
  LastMove = GetLegalMovebySquare(TargetedSquare.Name)
  
  if(TargetedSquare != SelectedSquare && LastMove != undefined) //if destination square of the move exists in LegalSquares
  {
    switch (LastMove.specialMove) {
      case "promotion":
        TargetedSquare.PieceElement.style.backgroundImage = "none"
        PromotionModal.style.display = "block"
        break;
      case "en passant":
        TargetedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
        if(isWhiteMove)
          Board[index+8].PieceElement.style.backgroundImage = "none"
        else
          Board[index-8].PieceElement.style.backgroundImage = "none"
        break;
      case "f1":
        TargetedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
        PickedPiece.style.backgroundImage = "none"
        GetSquare("f1").PieceElement.style.backgroundImage = GetSquare("h1").PieceElement.style.backgroundImage 
        GetSquare("h1").PieceElement.style.backgroundImage = "none"
        SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name, LastMove.specialMove)
        break;
      case "f8":
          TargetedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
          PickedPiece.style.backgroundImage = "none"
          GetSquare("f8").PieceElement.style.backgroundImage = GetSquare("h8").PieceElement.style.backgroundImage 
          GetSquare("h8").PieceElement.style.backgroundImage = "none"
          SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name, LastMove.specialMove)
          break;
      case "d1":
        TargetedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
        PickedPiece.style.backgroundImage = "none"
        GetSquare("d1").PieceElement.style.backgroundImage = GetSquare("a1").PieceElement.style.backgroundImage 
        GetSquare("a1").PieceElement.style.backgroundImage = "none"
        SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name, LastMove.specialMove)
        break;
      case "d8":
        TargetedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
        PickedPiece.style.backgroundImage = "none"
        GetSquare("d8").PieceElement.style.backgroundImage = GetSquare("a8").PieceElement.style.backgroundImage 
        GetSquare("a8").PieceElement.style.backgroundImage = "none"
        SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name, LastMove.specialMove)
        break;
      default:
        TargetedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
        SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name)
        break;
    }
    PickedPiece.style.backgroundImage = "none"
    PickedPiece.style.top = Board[63].PieceElement.offsetTop + 128
  }
  else{ // is not a legal move
    SelectedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
    PickedPiece.style.backgroundImage = "none"
    PickedPiece.style.top = Board[63].PieceElement.offsetTop + 128
  }
 }
 //------------------------------------------------------------------------
// a function that computer uses to make a move
function PlayMove()
{
  move = LegalMoves[0]
  console.log(move.currentSquare.name, move.targetSquare.name)
  CurrentSquare = GetSquare(move.currentSquare.name)
  TargetSquare = GetSquare(move.targetSquare.name)

  switch (move.specialMove) {
    case "promotion":
      pieces = "RBNQ" // ROOK, BISHOP, KNIGHT(N), QUEEN
      piece = move.currentSquare.name[0] + pieces[Math.random()]
      CurrentSquare.PieceElement.style.backgroundImage = "none"
      TargetSquare.PieceElement.style.backgroundImage = "url(/Pieces/"+piece+".png)"
    break;
  
    default:
      TargetSquare.PieceElement.style.backgroundImage = CurrentSquare.PieceElement.style.backgroundImage
      CurrentSquare.PieceElement.style.backgroundImage = "none"
      break;
  }

  SendMoveToAPI(move.currentSquare.name, move.targetSquare.name, move.specialMove)
}
 //------------------------------------------------------------------------
