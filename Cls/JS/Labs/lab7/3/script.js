const marbles = document.querySelectorAll('#container .marble');
const moving = document.getElementById('moving');


let currentIndex = 0;
let intervalId;

function startAnimation() {
    if (intervalId) return;

    intervalId = setInterval(() => {
        marbles.forEach(img => img.src = 'marble1.jpg')
        marbles[currentIndex].src = moving.src;
        if (currentIndex >= marbles.length-1) {

            currentIndex = 0;

        }
        else {
            currentIndex++;
        }
    }, 1000);
}


startAnimation();

marbles.forEach(m => {
    m.addEventListener('mouseenter', () => {
        clearInterval(intervalId);
        intervalId = null;
    });

    m.addEventListener('mouseleave', () => {
        startAnimation();
    });
});
