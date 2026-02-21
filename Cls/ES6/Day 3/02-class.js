class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age
    }

    greet() {
        return this.name + ' ' + this.age;
    }
}

const person1 = new Person("alaa", 13);
console.log(person1.name);
console.log(person1.age);
console.log(person1.greet());

console.log(person1);
console.log(typeof person1);


const person2 = new Person("ahmed", 25);
console.log(person2.greet());






class User2 {

    constructor(name) {
        this._name = name;
    }

    get name() {
        return this._name
    }

    set name(newName) {
        this._name = newName;
    }

}

const user3 = new User2("alice");
user3.name = "ali";
console.log(user3.name);





class User3 {
    constructor(name) {
        this.name = name;
    }

    getName() {
        return this.name;
    }

    setName(newName) {
        this.name = newName;
    }
}

const user = new User3("ali");

console.log(user.getName()); // ali
user.setName("Ahmed");
console.log(user.getName()); // Ahmed







class User4 {
    publicField = "public";
    #privateField = "private";

    getPrivateField() {
        return this.#privateField;
    }

    setPrivateField(newPrivateValue) {
        this.#privateField = newPrivateValue;
    }
}
const user1 = new User4();

// ✔ Public field is accessible
console.log(user1.publicField); // "public"


// ✔ Private field accessed via method
console.log(user1.getPrivateField());  //"private"


// ✔ Update private field via method
user1.setPrivateField("updated private");
console.log(user1.getPrivateField()); // "updated private"


// You are creating a NEW public property on the object
user1.myPrivateField = "new private";
console.log(user1.myPrivateField);    // "new private"


console.log(user1);