// const counterValue = document.getElementById("counterValue") as HTMLElement;
var Counter = /** @class */ (function () {
    function Counter() {
        this.value = 0;
    }
    Counter.prototype.increase = function () {
        this.value++;
    };
    Counter.prototype.decrease = function () {
        this.value--;
    };
    Counter.prototype.reset = function () {
        this.value = 0;
    };
    return Counter;
}());
var counter = new Counter();
var counterValue = document.getElementById("counterValue");
var increaseBtn = document.getElementById("increase");
var decreaseBtn = document.getElementById("decrease");
var resetBtn = document.getElementById("reset");
function updateUI() {
    counterValue.textContent = counter.value.toString();
}
increaseBtn.onclick = function () {
    counter.increase();
    updateUI();
};
decreaseBtn.onclick = function () {
    counter.decrease();
    updateUI();
};
resetBtn.onclick = function () {
    counter.reset();
    updateUI();
};
