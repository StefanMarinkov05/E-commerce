document.addEventListener('keydown', function (event) {
    if (event.key === 'ArrowRight') {
        var nextPageLink = document.getElementById('nextPageLink');
        nextPageLink.click();
    }
    if (event.key === 'ArrowLeft') {
        var nextPageLink = document.getElementById('previousPageLink');
        nextPageLink.click();
    }
});
