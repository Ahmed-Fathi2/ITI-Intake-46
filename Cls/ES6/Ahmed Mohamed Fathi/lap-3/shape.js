export class Shape{

    constructor(){

        if(this.constructor.name=="Shape")
            throw new Error("Abstract Class");
    }

    getArea(){}
    getPerimeter(){}

    toString(){

        return`Area = ${this.getArea()} && Perimeter = ${this.getPerimeter()}`
    }
}