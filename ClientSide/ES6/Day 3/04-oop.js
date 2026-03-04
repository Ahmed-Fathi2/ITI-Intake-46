class Human {
    static gender = "human";    //static property
}


const person1 = new Human();
console.log(person1.species);   //undefined --> cant access static property from instance

console.log(Human.gender)



class MathUtils {
    static square(x) {
        return x * x;
    }
}

console.log(MathUtils.square(5));

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// inheritance

class Animal {
    constructor(name) {
        this.name = name;
    }

    speak() {
        return `${this.name} makes a noise`
    }
}



class Dog extends Animal {

    // override method
    speak() {
        return `${this.name} hawahaw`
    }
}

const dog1 = new Dog("fox");
console.log(dog1.name);
console.log(dog1.speak());


// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

class Parent {
    constructor(name) {
        this.name = name;
    }
}

class Child extends Parent {
    constructor(name) {
        super(name); // 👈 call Parent constructor
    }
}

const c1 = new Child("Ali");
console.log(c1.name);


// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz


class People {
    constructor() {
        // prevent direct instantiation of abstract class
        if (new.target.name === "People") {
            throw new Error("cannot instantiate abstract class")
        }
    }

}

// const student = new People()


// abstract --> method --> cannot make instance directly
// solution --> inheritance 
// can make instances from the new class inheritance from the parent


class Men extends People {
    greet(){
        return "hello"
    }
};
const man1 = new Men(); //create instance
console.log(man1.greet())