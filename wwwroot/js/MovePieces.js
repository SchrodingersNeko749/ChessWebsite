function Drag(ev)//on drag over
{
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64
}
function DragStart(ev) {
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64
  PickedPiece.style.backgroundImage = ev.target.style.backgroundImage
  ev.target.style.backgroundImage = "none"

  document.onmousemove = Drag
  document.onmouseup = DragEnd
 }
 
 function DragOver(ev) {
  ev.target.style.backgroundImage = "yellow"
 }
 function DragOut(ev)
 {
  ev.target.style.backgroundImage = "none"

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
function SendMoveToAPI()
{
  let request = new XMLHttpRequest()
  request.open
}