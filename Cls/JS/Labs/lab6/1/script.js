var first_div = document.querySelector(".first-div");

console.log(first_div)
first_div.onclick = function () {


    var r = Math.floor(Math.random() * 256);
    var g = Math.floor(Math.random() * 256);
    var b = Math.floor(Math.random() * 256);

    var _body = document.body;

    var clonedDiv = first_div.cloneNode(true)

    _body.appendChild(clonedDiv)

    clonedDiv.style.backgroundColor = `rgb(${r}, ${g}, ${b})`;


}