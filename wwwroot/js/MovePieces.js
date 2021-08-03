isWhiteMove = true
let SelectedSquare = ""
let TargetedSquare = ""
let LegalSquares = []
let LegalMoves = []
let promotingpiece = ""
//------------------------------------------------------------------------
function Drag(ev)//on drag over
{
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64
}
//------------------------------------------------------------------------
function DragStart(ev) {
  //find the Selected square
  x = Math.floor((ev.clientX - Board[0].PieceElement.offsetLeft) / 128)
  y = Math.floor((ev.clientY - Board[0].PieceElement.offsetTop) / 128)

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
  
  x = Math.floor((ev.clientX - Board[0].PieceElement.offsetLeft) / 128)
  y = Math.floor((ev.clientY - Board[0].PieceElement.offsetTop) / 128)

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
    isWhiteMove = !isWhiteMove
  }
  else{ // is not a legal move
    SelectedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
    PickedPiece.style.backgroundImage = "none"
    PickedPiece.style.top = Board[63].PieceElement.offsetTop + 128
  }
 }
 //------------------------------------------------------------------------
// a function that computer uses to make a move
function PlayMove(current_squarename, target_squarename)
{
  console.log(current_squarename, target_squarename)
  currentSquare = GetSquare(current_squarename)
  targetSquare = GetSquare(target_squarename)
  //if its white's move
  //"url()"
  if (isWhiteMove && currentSquare.PieceElement.style.backgroundImage[13] == 'w') {
    targetSquare.PieceElement.style.backgroundImage = currentSquare.PieceElement.style.backgroundImage
    currentSquare.PieceElement.style.backgroundImage = "none"
    SendMoveToAPI(current_squarename, target_squarename)
  }
  else{
    //if its black's move
    if(!isWhiteMove && currentSquare.PieceElement.style.backgroundImage[13] == 'b'){
    targetSquare.PieceElement.style.backgroundImage = currentSquare.PieceElement.style.backgroundImage
    currentSquare.PieceElement.style.backgroundImage = "none"
    SendMoveToAPI(current_squarename, target_squarename)
    }
    else
      console.log("its not your move")
  }
  isWhiteMove = !isWhiteMove
}
 //------------------------------------------------------------------------