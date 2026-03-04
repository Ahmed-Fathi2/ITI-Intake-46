// // // var only stored on global scope

// // var globalVar = "global var";
// // console.log(globalVar);
// // console.log(window.globalVar);


// // let globalLet = "global let";
// // console.log(globalLet);
// // console.log(window.globalLet);



// // // x = 10;
// // // var y = 10;

// // if (true) {
// //     var x = 10;
// //     console.log(x)

// //     let y = 15;
// //     console.log(y)

// //     const z = 20;
// //     console.log(z);
// // }
// // console.log(x)
// // // console.log(y)    Uncaught ReferenceError: y is not defined
// // // console.log(z);   Uncaught ReferenceError: z is not defined



// // var x = 10;
// // var x = "hello";;
// // console.log(x)


// // let y = 10;
// // y = 20;  //reassign

// // console.log(y)

// // const z = 15;
// // z =20;
// // console.log(z)




// // console.log(x)
// // var x = 10;


// console.log(x)
// // let x = 10;

// // TDZ Temporal Dead Zone

// let name = "ahmed";
// let age = 10;

// let string1 = `hello ${name} - your age is ${age}`

// console.log(string1)

// let string2 = `      hello      ali
//                     hello 

//                     ahmed`
// console.log(string2)



// function sum(x = 0, y = 0) {
//     console.log(x + y);
// }

// sum()


// function sayHello(name = "guest"){
//     console.log(`hello ${name}`)
// }

// sayHello()




// spread operator (...)

// let arr1 = [1, 2, 3, 4, 5, 6];
// console.log(arr1);

// let arr2 = [...arr1, 7, 8, 9, 10]
// console.log(arr1)
// console.log(arr2)



// let obj1 = { a: 1, b: 2 };
// console.log(obj1);


// let obj2 = { ...obj1, c: 3, d: 4 };
// console.log(obj2)

// let str1 = "hello";
// let arr4 = [...str1];

// console.log(arr4)


// // rest operator (...)
// function sum(...args) {
//     return args.reduce((cur, acc) => acc + cur, 0)
// }

// console.log(sum(1,2,5))





// function add(x, y) {
//     return x + y
// }


// const sum = (a, y) => a + y;
// console.log(sum(5,5))


// const mathFunc = (x, y) => {
//     const sum = x + y;
//     const diff = x - y;

//     return { sum, diff }
// }


// let obj1 = {
//     name: "ali",
//     print: function () {
//         console.log(this.name);
//     }
// }


// obj1.print()


// let obj2 = {
//     name: "ahmed",
//     print: () => { this.name }
// }

// console.log(obj2.print())



// map
// filter
// reduce


// map

// same length of original array
// assign function on each index of this array
// return new array


const names = ["ali", "ahmed", "mohamed"];

// const newNames = names.map((name, i) => `${i} - hello ${name}`)
// console.log(newNames)


// var map = function (arr, fun) {
//     var newArray = [];
//     for (var i = 0; i < arr.length; i++) {
//         newArray.push(fun(arr[i], i))
//     }
//     return newArray
// }

// const filterNames = names.filter((name, i) => name.startsWith("i"))
// console.log(filterNames);

// var filter = function (arr, fun) {
//     var newArray = [];

//     for (var i = 0; i < arr.length; i++) {
//         if (fun(arr[i], i)) {
//             newArray.push(arr[i])
//         }
//     }
//     return newArray
// }

const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
const evenNumbers = numbers.filter((num) => num % 2 == 0);
console.log(evenNumbers);



// reduce
// return single value

const sumNumbers = numbers.reduce((cur , acc) => cur + acc , 0);
console.log(sumNumbers);



// [1, 2, 3, 4, 5]   -- initial = 0

// cur = ini = next = 0


//     cur     acc
//      0        0   =>  0
//      1        0   =>  1
//      2        1   =>  3
//      3        3   =>  6
//      4        6   =>  10
//      5        10  =>  15

