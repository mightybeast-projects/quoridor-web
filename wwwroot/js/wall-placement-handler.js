var wallStartPosition;

function assignPosition(positionStr)
{
    if(wallStartPosition == undefined)
        wallStartPosition = positionStr;
    else if(wallStartPosition != undefined) {
        sendPlaceWallRequest(wallStartPosition, positionStr);
        wallStartPosition = undefined;
    }
}