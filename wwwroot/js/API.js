function GetMoveFromAPI(currentSquare)
{
  url = "https://localhost:5001/Arena/GetMove/?currentsquare="+currentSquare
  fetch(url)
  .then(res => res.json())
  .then(data => {
    LegalMoves.splice(0, LegalMoves.length)
    data.forEach(move => {
      LegalMoves.push(move)
      ColorSquare(move.targetSquare.name, "rgba(232, 199, 109,0.4)")
    });
    //ColorLegalSquares()
  })
}
function SendMoveToAPI(currentSquare, targetSquare, specialMove)
{
  let move = new FormData()
  move.append("currentsquare",currentSquare)
  move.append("targetsquare",targetSquare)
  move.append("specialmove", specialMove)
  fetch("https://localhost:5001/Arena/SendMove/",{
      method: 'POST',
      body: move
})
.then(response =>{
  console.log('Success:', JSON.stringify(response))
  //GetMoveFromAPI()
})
}
