var images = [
    "images/1.jpg",
    "images/2.jpg",
    "images/3.jpg",
    "images/4.jpg",
    "images/5.jpg",
    "images/6.jpg"
];

var img = document.getElementById("photo");
var nextBtn = document.getElementById("next");
var prevBtn = document.getElementById("prev");
var slideBtn = document.getElementById("slideshow");
var stopBtn = document.getElementById("stop");

var index = 0;
var intervalId = null;

img.src = images[index];
updateButtons();


nextBtn.onclick = function () {
    if (index < images.length - 1) {
        index++;
        img.src = images[index];
    }
    updateButtons();
};


prevBtn.onclick = function () {
    if (index > 0) {
        index--;
        img.src = images[index];
    }
    updateButtons();
};



slideBtn.onclick = function () {
    if (intervalId != null) return;

    intervalId = setInterval(function () {
        index++;
        if (index === images.length) {
            index = 0;
        }
        img.src = images[index];
        updateButtons();
    }, 1000);
};


stopBtn.onclick = function () {
    clearInterval(intervalId);
    intervalId = null;
};


function updateButtons() {
    prevBtn.disabled = (index === 0);
    nextBtn.disabled = (index === images.length - 1);
}
