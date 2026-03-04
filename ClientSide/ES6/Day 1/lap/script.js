function Swap(a, b) {
    return [b, a];
}

let x = 5;
let y = 7;

[x, y] = Swap(x, y);

console.log(x);
console.log(y);


// =============================================================================

function getMinMax(...numbers) {

    console.log(Math.max(...numbers));
    console.log(Math.min(...numbers));

}


getMinMax(2, 10, -20, 30);

// ==================================================================================

let fruits = ["apple", "strawberry", "banana", "orange", "mango"]

// ==================================================================================
let fruitsCheckDataType = fruits.every(f => typeof f === "string");
console.log(fruitsCheckDataType);

// ==================================================================================
let StartWith = fruits.some(f => f.startsWith("a"));
console.log(StartWith);

// ==================================================================================
let filteredFruits = fruits.filter(f => f.startsWith("b") || f.startsWith("s"));
console.log(filteredFruits);

// ==================================================================================

let mappedFruits = fruits.map(f => `I Love ${f}`);
console.log(mappedFruits);

// ==================================================================================
mappedFruits.forEach(item => console.log(item));