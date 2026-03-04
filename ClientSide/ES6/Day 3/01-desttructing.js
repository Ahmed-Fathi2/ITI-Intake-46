// destructing

// with objects


const myObj = { ID: 1, Name: 'ali', Intake: 2025 };

const { ID, Name, Intake } = myObj;
console.log(ID);
console.log(Name);
console.log(Intake);


// different variable names
const { ID: myID, Name: myName, Intake: myIntake } = myObj;
console.log(myID);
console.log(myName);
console.log(myIntake);



const myObj2 = { Name: "ahmed", Address: { city: "cairo", country: "Egypt" } }
const { Address: { city, country } } = myObj2;

console.log(city, country)


const { ...restOperator } = myObj;
console.log(restOperator)

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz


// with arrays


const myArray = [1, 2, 3];
// const [a,b,c] = myArray;

// console.log(a, b, c);

const [a, b, c = 0, d = 0] = myArray;

console.log(a, b, c, d);


let x = 10;
let y = 20;
console.log(x, y);

[x, y] = [y, x];
console.log(x, y);

const [...rest] = [1, 2, 3, 4, 5, 6, 7, 8, 9];
console.log(rest);



// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz



// with functions

function printUser({ name, age }) {
    console.log(name, age);
}

const user1 = { name: "ahmed", age: 20 };
printUser(user1);





function printUserArray([name, age]) {
    console.log(name, age)
}

const userArray = ["ali", 30];

printUserArray(userArray)