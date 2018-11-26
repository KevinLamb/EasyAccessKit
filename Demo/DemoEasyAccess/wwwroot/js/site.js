// Write your JavaScript code.
function ezSwitchCarousel(ezPlayButton, ezCarousel) {
    console.log('triggered');

    if (ezPlayButton.getAttribute('class').indexOf('ez-play') > -1) {
        ezPlayButton.setAttribute('class', ezPlayButton.getAttribute('class').replace('ez-play', 'ez-pause'));
        ezPlayButton.innerHtml ='Pause <span style="opacity: 0;"> - carousel will stop moving slides</span> <i class="fas fa-pause">';

        ezCarousel.removeAttribute('data-interval');

        ezCarousel.carousel('cycle');

        console.log('play');
    }
    else if (ezPlayButton.getAttribute('class').indexOf('ez-pause') > -1) {
        ezPlayButton.setAttribute('class', ezPlayButton.getAttribute('class').replace('ez-pause', 'ez-play'));
        ezPlayButton.innerHtml = 'Play <span style="opacity: 0;"> - allows carousel to move slides automatically</span> <i class="fas fa-play">';

        ezCarousel.removeAttribute('data-interval');

        ezCarousel.carousel('pause');

        console.log('pause');
    }
}