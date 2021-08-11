function GetMoveFromAPI(currentSquare)
{
  url = "https://localhost:5001/GameManager/GetMove/?currentsquare="+currentSquare
  fetch(url)
  .then(res => res.json())
  .then(data => {
    if(data.length == 0)
      alert("Game Over")
    LegalMoves.splice(0, LegalMoves.length)
    data.forEach(move => {
      LegalMoves.push(move)
      
      if(isWhiteMove)
      {
        if(move.specialMove == "blockcheck")
          ColorSquare(move.targetSquare.name, "red")
        else
          ColorSquare(move.targetSquare.name, "rgba(232, 199, 109,0.4)")
        
      }
    });
  })
  .then(function(){
    if(!isWhiteMove)
    {
      PlayMove()
    }
  })
}
//---------------------------------------------------------------
function SendMoveToAPI(currentSquare, targetSquare, specialMove)
{
  let move = new FormData()
  move.append("currentsquare",currentSquare)
  move.append("targetsquare",targetSquare)
  move.append("specialmove", specialMove)
  fetch("https://localhost:5001/GameManager/SendMove/",{
      method: 'POST',
      body: move
})
.then(function(){
  
  isWhiteMove = !isWhiteMove
  if(!isWhiteMove)
  {
    GetMoveFromAPI()
    console.log("after i change isWhiteMove:" + isWhiteMove)
  }
})
}
//---------------------------------------------------------------
function RestartGame(){
  fetch("https://localhost:5001/Arena/RestartGame/")
  .then(res =>{
      if(res.status == 200)
      {
        console.log("succesful"+res.status)
      }
  })
  .then(function(){
    LoadGame()
  })
}
//---------------------------------------------------------------
function LoadGame(){
  fetch("https://localhost:5001/Arena/LoadGame/")
  .then(res => res.json())
  .then(data => {
    ServerBoard = data.slice()
  })
  .then(function() {
    SetupBoard()
});
}
