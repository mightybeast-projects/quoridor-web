function blink(element) {
    setInterval(() => $(element).fadeOut(300).fadeIn(300), 300);
}

function select(element) {
    $(element).css("border", "2px solid green");
}