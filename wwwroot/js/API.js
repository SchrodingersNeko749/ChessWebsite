function GetMoveFromAPI(currentSquare)
{
  url = "https://localhost:5001/Arena/GetMove/?currentsquare="+currentSquare
  fetch(url)
  .then(res => res.json())
  .then(data => {
    LegalSquares.splice(0, LegalSquares.length)
    LegalMoves.splice(0, LegalMoves.length)
    data.forEach(move => {
      LegalSquares.push(move.targetSquareName)
      LegalMoves.push(move)
    });
    ColorLegalSquares()
  })
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
.then(response =>{
  console.log('Success:', JSON.stringify(response))
  //GetMoveFromAPI()
})
}
