isWhiteMove = true
let SelectedSquare = ""
let TargetedSquare = ""
let LegalSquares = []
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
  if(SelectedSquare == "" || SelectedSquare != Board[index])
  {
    LegalSquares.splice(0, LegalSquares.length)
    SelectedSquare = Board[index]
    GetMoveFromAPI(SelectedSquare.Name)
  }
  ColorLegalSquares()
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64

  //if its white's move
  if (isWhiteMove && ev.target.style.backgroundImage[13] == 'W') {
      PickedPiece.style.backgroundImage = ev.target.style.backgroundImage
      ev.target.style.backgroundImage = "none"

      document.onmousemove = Drag
      document.onmouseup = DragEnd
  }
  else{
    //if its blacks move
    if(!isWhiteMove && ev.target.style.backgroundImage[13] == 'B'){
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
  console.log(LegalSquares.indexOf(TargetedSquare.Name))
  if(TargetedSquare != SelectedSquare && LegalSquares.indexOf(TargetedSquare.Name) != -1) //if destination square of the move exists in LegalSquares
  {
    console.log(SelectedSquare.Name,TargetedSquare.Name)
    TargetedSquare.PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
    PickedPiece.style.backgroundImage = "none"
    PickedPiece.style.top = Board[63].PieceElement.offsetTop + 128
    SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name)
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
  if (isWhiteMove && currentSquare.PieceElement.style.backgroundImage[13] == 'W') {
    targetSquare.PieceElement.style.backgroundImage = currentSquare.PieceElement.style.backgroundImage
    currentSquare.PieceElement.style.backgroundImage = "none"
    SendMoveToAPI(current_squarename, target_squarename)
  }
  else{
    //if its black's move
    if(!isWhiteMove && currentSquare.PieceElement.style.backgroundImage[13] == 'B'){
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
 function Promotion(targetsquare, promotingpiece)
 {
   if(promotingpiece == "wQ")
      targetsquare.PieceElement.backgroundImage = "url(/Pieces/WhiteQueen.png)"
   if(promotingpiece == "bQ")
      targetsquare.PieceElement.backgroundImage = "url(/Pieces/BlackQueen.png)"
 } 