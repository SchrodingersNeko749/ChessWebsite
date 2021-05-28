function Drag(ev)//on drag over
{
  PickedPiece.style.top = ev.clientY - 64
  PickedPiece.style.left = ev.clientX - 64
}
function DragStart(ev) {
  PickedPiece.style.backgroundImage = ev.target.style.backgroundImage
  PickedPiece.style.border = "dashed"
  ev.target.style.backgroundImage = "none"
 }
 
 function DragOver(ev) {
  console.log("dragover")
 }
 
 function DragEnd(ev) {
  console.log("dragend")
  PickedPiece.style.backgroundImage = "none"
  PickedPiece.style.border = "none"
 }