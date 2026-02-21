var img = document.querySelector("#header");
img.style.textAlign = "right";


var list = document.querySelector("#navigation");
list.style.textAlign = "center";

var clonedImg = img.cloneNode(true);
clonedImg.style.textAlign = "left";
clonedImg.style.listStylePosition= "inside"

var body = document.body;
body.appendChild(clonedImg)


