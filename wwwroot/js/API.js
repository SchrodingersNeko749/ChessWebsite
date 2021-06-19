function GetMoveFromAPI(currentSquare)
{
  url = "https://localhost:5001/Arena/GetMove/?currentsquare="+currentSquare
  fetch(url)
  .then(res => res.json())
  .then(data => {
    deColorBoard()
    console.log(data)
    data.forEach(move => {
      LegalSquares.push(move.targetSquareName)
      if(move.promoteToPiece == null)
        ColorSquare(move.targetSquareName, "rgba(255, 0, 77, 0.23)")
      else
        ColorSquare(move.targetSquareName, "rgba(100, 59, 0, 0.5)")
    });
    //randomnum = Math.floor(Math.random() * data.length);
    //PlayMove(data[randomnum].currentSquareName, data[randomnum].targetSquareName)
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
