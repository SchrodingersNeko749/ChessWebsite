function GetMoveFromAPI()
{
  fetch("https://localhost:5001/Arena/GetMove/")
  .then(res => res.json())
  .then(data => PlayMove(data.currentSquare, data.targetSquare))
}
function SendMoveToAPI(currentSquare, targetSquare)
{
  let move = new FormData()
  move.append("currentsquare",currentSquare)
  move.append("targetsquare",targetSquare)
  fetch("https://localhost:5001/Arena/SendMove/",{
      method: 'POST',
      body: move
})
.then(response => console.log('Success:', JSON.stringify(response)))
}
