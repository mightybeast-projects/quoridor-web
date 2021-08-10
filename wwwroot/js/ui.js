function blink(element) {
    setInterval(() => $(element).fadeOut(200).fadeIn(200), 10);
}