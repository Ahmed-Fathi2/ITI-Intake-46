// Types

//String
let userName: string = "ali";
let greeting: string = `Hello ${userName}`;

console.log(greeting);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Number
let age: number = 30;
let temp: number = 23.5;
let binary: number = 0b1010;

console.log(age, temp, binary);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Boolean
let isActive: boolean = true;
console.log(isActive);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Array
let numbers: number[] = [1, 2, 3, 4, 5];
let numbers2: Array<number> = [1, 2, 3, 4, 5];

let fruits: string[] = ["apple", "banana"];
console.log(numbers, numbers2, fruits);

let dynamicArray: any[] = [true, "hello", 10];
console.log(dynamicArray);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Any
let dynamicValue: any = 5;
dynamicValue = "hello";
dynamicValue = true;

console.log(dynamicValue);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Object
let person: object = { name: "ali", age: 25 };

let car: { make: string; model: string; year: number } = {
  make: "Toyota",
  model: "camry",
  year: 2005,
};

console.log(person, car);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Functions

function add(x: number, y: number): number {
  return x + y;
}

const multiply = (x: number, y: number): number => x * y;

console.log(add(5, 5), multiply(4, 2));

function greet(name: string, greeting?: string): string {
  return `${greeting || "hi"} - ${name}`;
}

console.log(greet("ali", "hello"));
console.log(greet("ali"));

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Union

let id: string | number = 1;
console.log(id);
id = "abc";
console.log(id);

let userStatus: "active" | "inactive" | "pending" = "inactive";
console.log(userStatus);
userStatus = "active";
console.log(userStatus);
