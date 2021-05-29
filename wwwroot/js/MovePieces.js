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
  console.log("drag")
  document.onmousemove = Drag
  document.onmouseup = DragEnd
 }
 
 function DragOver(ev) {
  console.log("dragover")
 }
 
 function DragEnd(ev) {
  console.log("dragend")
  document.onmouseup = null
  document.onmousemove = null

  x = Math.floor((ev.clientX - Board[0].PieceElement.offsetLeft) / 128)
  y = Math.floor((ev.clientY - Board[0].PieceElement.offsetTop) / 128)

  index = y*8 + x
  console.log(x,y)
  Board[index].PieceElement.style.backgroundImage = PickedPiece.style.backgroundImage
  PickedPiece.style.backgroundImage = "none"
 }