"use strict";

// function DragStart(ev) //on drag start
// {
//   console.log("DragStart")
// }
// function DragEnd(ev) //on drag end
// {
//   console.log("DragEnd")
// }
// function Drop(ev)//on drop
// {
//   console.log("Drop")
// }
function AllowDrop(ev) //on drag over
{
  PickedPiece.style.top = ev.clientY - 64;
  PickedPiece.style.left = ev.clientX - 64;
}

function DragStart(ev) {
  console.log(PickedPiece);
  PickedPiece.style.backgroundImage = ev.target.style.backgroundImage; //ev.dataTransfer.setDragImage("/Pieces/BlackRook.png");
  //document.getElementById("picked-piece") = ev.target.style.backgroundImage
}

function DragOver(ev) {}

function Drop(ev) {
  console.log("Drop");
}