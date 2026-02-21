function Rectangle(width, height) {

    this.width = width;
    this.height = height;
    Rectangle.count++;
}

Rectangle.count = 0;

Rectangle.prototype.getArea = function () {

    return this.width * this.height;
}

Rectangle.prototype.getPerimeter = function () {

    return ((this.width + this.height) * 2);
}

Rectangle.prototype.toString = function () {

    return `Width of Rect = ${this.width}\n height = ${this.height}\n Area = ${this.getArea()}\n Preimeter = ${this.getPerimeter()}`;
}

var myRect = new Rectangle(10, 5);

console.log("Area = " + myRect.getArea());
console.log("===========================================");
console.log("Preimeter = " + myRect.getPerimeter());
console.log("===========================================");
console.log(" Rect Info\n-------------\n " + myRect.toString());

var myRect2 = new Rectangle(11, 4);
var myRect3 = new Rectangle(5, 2);
var myRect4 = new Rectangle(5, 12);

console.log("num of object created form Rectangle calss = "+Rectangle.count);


