// import {add} from './math.js'

import sum from './math.js'
import {diff as myDiff} from './math.js'



console.log(sum(5, 5))
console.log(myDiff(5, 5))




class Shape{

    toString(){
        console.log("hello")
    }
}

class Circle extends Shape{

    toString(){
        console.log('area , parameter')
    }
}

class Rectangle extends Shape{
    toString(){
        console.log('area , parameter')
    }
}

class Square extends Shape{
    toString(){
        console.log('area , parameter')
    }
}