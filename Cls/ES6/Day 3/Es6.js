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