// const counterValue = document.getElementById("counterValue") as HTMLElement;
class Counter {
    value: number;

    constructor() {
        this.value = 0;
    }

    increase() {
        this.value++;
    }

    decrease() {
        this.value--;
    }

    reset() {
        this.value = 0;
    }
}


const counter = new Counter();


const counterValue = document.getElementById("counterValue") as HTMLElement;
const increaseBtn = document.getElementById("increase") as HTMLElement;
const decreaseBtn = document.getElementById("decrease") as HTMLElement;
const resetBtn = document.getElementById("reset") as HTMLElement;



function updateUI() {
    counterValue.textContent = counter.value.toString();
}


increaseBtn.onclick = () => {
    counter.increase();
    updateUI();
};

decreaseBtn.onclick = () => {
    counter.decrease();
    updateUI();
};

resetBtn.onclick = () => {
    counter.reset();
    updateUI();
};
