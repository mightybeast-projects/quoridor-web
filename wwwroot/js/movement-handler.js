var playerSelected;
var playerPositionStr;
var moveVector = new Array();

function selectPlayer(playerPosition)
{
    playerSelected = true;
    playerPositionStr = playerPosition;
}

function movePlayer(tilePosition)
{
    if(playerSelected) {
        positionToMoveStr = tilePosition;
        //alert(playerSelected + " " + playerPositionStr);
        //alert(positionToMove + " " + moveVectorX + " " + moveVectorY);
        
        calculateMoveVector();
        sendAppropriateMoveRequest();
        
        playerSelected = false;
    }
}

function calculateMoveVector() {
    var playerPosition = playerPositionStr.split(" ");
    var positionToMove = positionToMoveStr.split(" ");
    moveVector[0] = (positionToMove[0] - playerPosition[0]) / 2;
    moveVector[1] = (positionToMove[1] - playerPosition[1]) / 2;
}

function sendAppropriateMoveRequest() {
    if(topRightMove())
        sendMoveRequest(4);
    else if(topLeftMove())
        sendMoveRequest(5);
    else if(bottomRightMove())
        sendMoveRequest(6);
    else if(bottomLeftMove())
        sendMoveRequest(7);
    else if(rightMove()) 
        sendMoveRequest(2); 
    else if(leftMove()) 
        sendMoveRequest(3);
    else if(upMove())
        sendMoveRequest(0);
    else if(bottomMove()) 
        sendMoveRequest(1);
}

function topRightMove() {
    return moveVector[0] > 0 && moveVector[1] > 0;
}

function topLeftMove() {
    return moveVector[0] < 0 && moveVector[1] > 0;
}

function bottomRightMove() {
    return moveVector[0] > 0 && moveVector[1] < 0;
}

function bottomLeftMove() {
    return moveVector[0] < 0 && moveVector[1] < 0;
}

function rightMove()
{
    return moveVector[0] > 0;
}

function leftMove()
{
    return moveVector[0] < 0;
}

function upMove()
{
    return moveVector[1] > 0;
}

function bottomMove()
{
    return moveVector[1] < 0;
}