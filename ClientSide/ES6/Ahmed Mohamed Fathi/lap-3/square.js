import { Shape } from './shape.js'


export class Square extends Shape {

    constructor(side) {
        super();
        this.side = side;
    }

    getArea() {

        return this.side ** 2;
    }
    getPerimeter() {

        return this.side *4
    }
    toString() {

          return `Square Area: ${this.getArea()}, Perimeter: ${this.getPerimeter()}`;
    }


}