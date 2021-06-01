isWhiteMove = true
function Drag(ev)//on drag over
{
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64
}
function DragStart(ev) {
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64
  //if its white's move
  if (isWhiteMove && ev.target.style.backgroundImage[13] == 'W') {
      PickedPiece.style.backgroundImage = ev.target.style.backgroundImage
      ev.target.style.backgroundImage = "none"
      document.onmousemove = Drag
      document.onmouseup = DragEnd
      isWhiteMove = false
  }
  else{
    //if its blacks move
    if(!isWhiteMove && ev.target.style.backgroundImage[13] == 'B'){
      PickedPiece.style.backgroundImage = ev.target.style.backgroundImage
      ev.target.style.backgroundImage = "none"
      document.onmousemove = Drag
      document.onmouseup = DragEnd
      isWhiteMove = true
    }
    else
      console.log("its not your move")
  }
 }
 
 function DragEnd(ev) {

  document.onmouseup = null
  document.onmousemove = null
  
  x = Math.floor((ev.clientX - Board[0].PieceElement.offsetLeft) / 128)
  y = Math.floor((ev.clientY - Board[0].PieceElement.offsetTop) / 128)

  index = y*8 + x
  Board[index].PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
  PickedPiece.style.backgroundImage = "none"
  PickedPiece.style.top = Board[63].PieceElement.offsetTop + 128
  GetMoveFromAPI()
 }
 function GetMoveFromAPI()
{
    let request = new XMLHttpRequest()
    request.open("GET", "https://localhost:5001/Arena/GetMove/")
    request.send();
    request.onload = () => {
      
      if(request.status == 200)
      {
        GetSquare(request.responseText).PieceElement.style.backgroundColor = "rgba(46, 134, 193, 0.5)"
      }
    }
}
function SendMoveToAPI(currentsquare, targetsquare)
{
  console.log(currentsquare, targetsquare)
  let request = new XMLHttpRequest()
  request.open
}