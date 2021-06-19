function GetMoveFromAPI()
{
  fetch("https://localhost:5001/Arena/GetMove/")
  .then(res => res.json())
  .then(data => {
    deColorBoard()
    console.log(data)
    data.forEach(move => {
      //console.log(move.currentSquareName)
      ColorSquare(move.currentSquareName, "rgba(0, 146, 255, 0.23)")
      ColorSquare(move.targetSquareName, "rgba(255, 0, 77, 0.23)")
    });
    randomnum = Math.floor(Math.random() * data.length);
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
  GetMoveFromAPI()
})
}
