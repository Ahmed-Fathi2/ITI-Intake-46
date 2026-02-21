
var textInput = document.querySelector('#input')

document.querySelector("#btn0").addEventListener('click', function () { textInput.value += this.value })
document.querySelector("#btn1").addEventListener('click', function () { textInput.value += this.value })
document.querySelector("#btn2").onclick = function () { textInput.value += this.value };
document.querySelector("#btn3").onclick = function () { textInput.value += this.value };
document.querySelector("#btn4").onclick = function () { textInput.value += this.value };
document.querySelector("#btn5").onclick = function () { textInput.value += this.value };
document.querySelector("#btn6").onclick = function () { textInput.value += this.value };
document.querySelector("#btn7").onclick = function () { textInput.value += this.value };
document.querySelector("#btn8").onclick = function () { textInput.value += this.value };
document.querySelector("#btn9").onclick = function () { textInput.value += this.value };


document.querySelector("#btnPlus").onclick = function () { textInput.value += this.value };
document.querySelector("#btnMinus").onclick = function () { textInput.value += this.value };
document.querySelector("#btnMul").onclick = function () { textInput.value += this.value };
document.querySelector("#btnDiv").onclick = function () { textInput.value += this.value };
document.querySelector("#btnDot").onclick = function () { textInput.value += this.value };


document.querySelector("#btnClear").onclick = function () { textInput.value = "" };


document.querySelector("#equal").onclick = function () {

    try {
        var result = eval(textInput.value);
        if (result === Infinity || result === -Infinity || isNaN(result)) {
            textInput.value = "Math Error";
        }

        else {
            textInput.value = result;
        }
    }
    catch (e) {

        textInput.value = "Math Error";

    }
};
