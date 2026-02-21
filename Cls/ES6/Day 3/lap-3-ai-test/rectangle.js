import { Shape } from './shape.js'

export class Rectangle extends Shape {

    constructor(width, height) {
        super();
        this.width = width;
        this.height = height;
    }

    getArea() {

        return this.width * this.height;
    }
    getPerimeter() {

        return (this.width + this.height) * 2
    }
    toString() {

        return `Rectangle Area: ${this.getArea()}, Perimeter: ${this.getPerimeter()}`;
    }


}

