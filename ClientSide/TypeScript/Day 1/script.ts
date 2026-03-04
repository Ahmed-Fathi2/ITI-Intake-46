interface User {
  id: number;
  name: string;
  email: string;
  age?: number;
}

const newUser: User = {
  id: 1,
  name: "ali",
  email: "ali@gmial.com",
  age: 25,
};

console.log(newUser);

interface Employee extends User {
  department: string;
  position: string;
}

const newEmp: Employee = {
  id: 2,
  name: "ahmed",
  email: "ahmed@gmail.com",
  department: "programming",
  position: "front-end developer",
};

console.log(newEmp);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// interface for function
interface MathUtils {
  (x: number, y: number, z?: number): number;
}

const sum: MathUtils = (a, b) => a + b;
const diff: MathUtils = (a, b) => b - a;
const multi: MathUtils = (a, b) => a * b;
const specificOperation: MathUtils = (a, b, c) => a * b * c;

console.log(sum(5, 5));
console.log(diff(5, 5));
console.log(multi(5, 5));
console.log(specificOperation(5, 5, 5));

function printUser(user: User): void {
  console.log(`user: ${user.name} - ${user.email}`);
}

printUser(newUser);

interface Point {
  readonly x: number;
  readonly y: number;
}

const point: Point = { x: 10, y: 20 };
console.log(point);
// point.x = 15;
// console.log(point)

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// indexable types
interface StringArray {
  [index: number]: string;
}

const myArr: StringArray = ["bob", "ali"];
console.log(myArr[0]) //number : string
console.log(myArr[1])