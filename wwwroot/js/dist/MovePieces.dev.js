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
function SelectPiece(ev) {}

function Drag(ev) //on drag over
{
  PickedPiece.style.top = ev.clientY - 64;
  PickedPiece.style.left = ev.clientX - 64;
}

function DragStart(ev) {
  PickedPiece.style.backgroundImage = ev.target.style.backgroundImage;
  ev.target.style.backgroundImage = "none";
}

function DragOver(ev) {}

function Drop(ev) {
  PickedPiece.style.backgroundImage = "none";
}