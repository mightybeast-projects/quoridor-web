function sendMoveRequest(moveId) {
    sendAjaxRequest("/Game/PostMove", moveId);
}

function sendPlaceWallRequest(start, end) {
    var wallModel = {
        wallStartPosition: start, 
        wallEndPosition: end
    }

    sendAjaxRequest("/Game/PostPlaceWall", wallModel);
}

function sendAjaxRequest(url, model)
{
    $.ajax({
        type: "POST",
        url: url,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json' 
        },
        data: JSON.stringify(model),
        success: function (data) {
            $("#content-div").empty().html(data);
            handleResponceAndReloadUi();
        }
    });
}