function ModaiSelectPiece(modaiselectedpiece)
{
    pieceurl = 'url("'+ modaiselectedpiece.currentSrc.slice(22) + '")'
    if(!isWhiteMove)
        pieceurl = pieceurl.replace(/w/, 'b')
    PromotionModal.style.display = "none"
    TargetedSquare.PieceElement.style.backgroundImage = pieceurl
    SendMoveToAPI(SelectedSquare.Name, TargetedSquare.Name, ""+pieceurl[13]+pieceurl[14])
}