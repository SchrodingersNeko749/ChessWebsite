function GetMoveFromAPI(currentSquare)
{
  url = "https://localhost:5001/GameManager/GetMove/?currentsquare="+currentSquare
  fetch(url)
  .then(res => res.json())
  .then(data => {
    LegalMoves.splice(0, LegalMoves.length)
    data.forEach(move => {
      LegalMoves.push(move)
      if(move.specialMove == "blockcheck")
        ColorSquare(move.targetSquare.name, "red")
      else
        ColorSquare(move.targetSquare.name, "rgba(232, 199, 109,0.4)")
    });
  })
}
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
}
function RestartGame(){
  fetch("https://localhost:5001/Arena/RestartGame/")
  .then(res =>{
      console.log(res.status)
      if(res.status == 200)
      {
        console.log("Success: "+ res.statusText)
      }
  })
  .then(function(){
    LoadGame()
  })
}
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
