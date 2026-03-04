
import { Shape } from "./shape.js";

export class Circle extends Shape {
    
    constructor(radius) {
        super();
        this.radius = radius;
    }

    getArea() {
        return Math.PI * (this.radius ** 2)

    }

    getPerimeter() {

        return 2 * Math.PI * this.radius;
    }
    toString() {

        return `Circle Area: ${this.getArea()}, Perimeter: ${this.getPerimeter()}`;
    }
}