function move(moveId) {
    window.location.href = '/Game/Move?moveId=' + moveId;
}

function placeWall(start, end) {
    var model = {
        wallStartPosition: start, 
        wallEndPosition: end
    }
    var modelJson = JSON.stringify(model);
    window.location.href = '/Game/PlaceWall?modelJson=' + modelJson;
}