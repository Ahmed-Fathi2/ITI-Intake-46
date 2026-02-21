import { Rectangle } from "./rectangle.js";
import { Square } from "./square.js";
import { Circle } from "./circle.js";


let myrect = new Rectangle(10, 20);
console.log(myrect.getArea());
console.log(myrect.getPerimeter());
console.log(myrect.toString());

console.log("==============================================")

let mysquare = new Square(3);
console.log(mysquare.getArea());
console.log(mysquare.getPerimeter());
console.log(mysquare.toString());

console.log("==============================================")

let mycircle = new Circle(3);
console.log(mycircle.getArea());
console.log(mycircle.getPerimeter());
console.log(mycircle.toString());




