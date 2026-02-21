var canvas = document.getElementById("c");
var circule_color = document.getElementById("clr");
var butt = document.getElementById("btn");
var ctx = canvas.getContext("2d");

butt.onclick = function () {

    ctx.clearRect(0, 0, canvas.width, canvas.height);


    var circlesCount = Math.floor(Math.random() * 50) + 35;

    for (let i = 0; i < circlesCount; i++) {


        var x = Math.random() * canvas.width;
        var y = Math.random() * canvas.height;


        var radius = Math.random() * 40 + 10;


        // ctx. = circule_color.value;
        // ctx.beginPath();
        // ctx.arc(x, y, radius, 0, Math.PI * 2);
        // ctx.fill();

        ctx.beginPath();
        ctx.arc(x, y, radius, 0, Math.PI * 2);

        ctx.strokeStyle = circule_color.value;   
        ctx.lineWidth = 3;        
        ctx.stroke();     

    }

}


