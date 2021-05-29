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
  PickedPiece.style.border = "dashed"
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
  PickedPiece.style.backgroundImage = "none"
  PickedPiece.style.border = "none"
 }