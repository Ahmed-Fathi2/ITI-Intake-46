var newUser = {
    id: 1,
    name: "ali",
    email: "ali@gmial.com",
    age: 25,
};
console.log(newUser);
var newEmp = {
    id: 2,
    name: "ahmed",
    email: "ahmed@gmail.com",
    department: "programming",
    position: "front-end developer",
};
console.log(newEmp);
var sum = function (a, b) { return a + b; };
var diff = function (a, b) { return b - a; };
var multi = function (a, b) { return a * b; };
var specificOperation = function (a, b, c) { return a * b * c; };
console.log(sum(5, 5));
console.log(diff(5, 5));
console.log(multi(5, 5));
console.log(specificOperation(5, 5, 5));
function printUser(user) {
    console.log("user: ".concat(user.name, " - ").concat(user.email));
}
printUser(newUser);
var point = { x: 10, y: 20 };
console.log(point);
var myArr = ["bob", "ali"];
console.log(myArr[0]); //number : string
console.log(myArr[1]);
