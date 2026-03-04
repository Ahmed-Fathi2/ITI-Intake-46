function Shape(width, height) {

    if (this.constructor === Shape)
        throw new Error("Cannot create object from abstract class Shape");


    this.width = width;
    this.height = height;

}
Shape.prototype.getArea = function () {

    return this.width * this.height;

}
Shape.prototype.toString = function () {

    return `Width = ${this.width}\nheight = ${this.height}\nArea = ${this.getArea()}`;
}

function Rectangle(width, height) {

    Shape.call(this, width, height); // inheret Prop

}

Rectangle.prototype = Object.create(Shape.prototype);
Rectangle.prototype.constructor = Rectangle;


Rectangle.prototype.getPerimeter = function () {

    return ((this.width + this.height) * 2);
}

function Square(side) {

    Shape.call(this, side, side); // inheret Prop

}

Square.prototype = Object.create(Shape.prototype);
Square.prototype.constructor = Square;

Square.prototype.getPerimeter = function () {

    return (this.width * 4);
}




var myRect = new Rectangle(10, 5);
console.log("======= Rect Info =======\n-------------\n" + myRect.toString());
console.log("Rect Area = " + myRect.getArea());
console.log("Rect Prei = " + myRect.getPerimeter());

console.log("===============================================================================");
var mysquare = new Square(5);
console.log("======= square Info =======\n-------------\n" + mysquare.toString());
console.log("square Area = " + mysquare.getArea());
console.log("square Prei = " + mysquare.getPerimeter());


var s = new Shape(2, 3); // thorw Exception ---> Error


