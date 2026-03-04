"use strict";
// console.log("===================== interface =======================")
// interface Person {
//     id: number
//     name: string
// }
// let myvar: Person = {
//     id: 20,
//     name: "fathi"
// }
// console.log(myvar)
// console.log("===================== type =======================")
// type MyType = string | number;
// let x: MyType = 20
// console.log(x);
// x = "fathi";
// console.log(x);
// type MyTypetwo = {
//     id: number;
//     name: string
// }
// let y: MyTypetwo = {
//     id: 25,
//     name: "Ahmed Fathi"
// }
// console.log(y);
// console.log("===================== Class =======================")
// //1- default access modifier is public
// //2- you cant use any var before assign it 
// // let x2:number;
// // console.log(x2)----> Error
// // classes , interface use concise method
// interface User {
//     id: number;
//     name: string;
//     getInfo(): string;
// }
// class Student implements User {
//     private age: number;
//     id: number;
//     name: string;
//     constructor(age: number, id: number, name: string) {
//         this.age = age;
//         this.id = id;
//         this.name = name;
//     }
//     getAge(): number {
//         return this.age
//     }
//     setAge(age: number) {
//         this.age = age;
//     }
//     checkAge(testAge: number): boolean {
//         return testAge == this.age
//     }
//     getInfo(): string {
//         return `${this.id} ---- ${this.age}---${this.name}`
//     }
// }
// class FreshStudent extends Student {
//     role: string;
//     constructor(age: number, id: number, name: string, role: string) {
//         super(age, id, name);
//         this.role = role;
//     }
//     printInfo(): string {
//         return `${this.getInfo()}-----${this.role}`;
//     }
// }
// let stdtwo: FreshStudent = new FreshStudent(20, 23, "fathii", "Admin");
// console.log("***********************")
// stdtwo.name = "mohamed";
// // stdtwo.age=25; private member
// console.log(stdtwo);
// // let stdone = new Student(10, 25, "Fathi");
// // stdone.name = "mohamed";
// // console.log("***********************")
// // console.log(stdone.getInfo())
// // console.log(stdone.checkAge(5))
// // console.log("*************generic class - interface **********")
console.log("ahmed");
class User {
    constructor() {
        this.data = [];
    }
    add(item) {
        this.data.push(item);
    }
}
let userone = new User();
userone.add({ name: "book1", author: "Fathi" });
userone.add({ name: "car2010", price: 150 });
console.log(userone.data);
function test(name, age = 50) {
    return `${name}----- ${age}`;
}
console.log(test("gvbn"));
//# sourceMappingURL=Calss.js.map