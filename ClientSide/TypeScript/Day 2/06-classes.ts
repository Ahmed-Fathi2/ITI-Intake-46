class Animal {
  // protected -> accessible in child classes
  protected name: string;
  constructor(name: string) {
    this.name = name;
  }

  // public
  move(distance: number = 0): void {
    console.log(`${this.name} moved ${distance}`);
  }
}

const animal1 = new Animal("Generic animal");
animal1.move();
animal1.move(10);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// super -> call by default once inheritance (child class call super by default)
// must call super --> child class has its own constructor

class Dog extends Animal {
  public breed: string;

  constructor(name: string, breed: string) {
    super(name);
    this.breed = breed;
  }

  bark(): void {
    console.log("haw haw");
  }
  move(distance: number = 5): void {
    console.log(`${this.name} - ${this.breed} moved ${distance}`);
    // super.move(distance); //call parent method
  }
}

const dog1 = new Dog("fox", "golden");
dog1.move();
dog1.move(15);
dog1.bark();

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
// INTERFACE --- CONTRACT

// interface define what a class must do
interface Flyable {
  fly(): void;
  // run(): void;
  run?(): void; // [?] --> to be optional
}

interface Football {
  play(): void;
}

class Bird extends Animal implements Flyable, Football {
  constructor(name: string) {
    super(name);
  }

  fly(): void {
    console.log(`${this.name} is flying`);
  }
  play(): void {
    console.log(`${this.name} is flying`);
  }
  // run(): void {
  //   console.log(`${this.name} is running`);
  // }
}

const bird1 = new Bird("Eagle");
bird1.fly();
// bird1.run();
bird1.move(20);

// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
// zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

// Abstract --> cannot create object from it (instance)

abstract class Department {
  constructor(public name: string) {}

  abstract printMeeting(): void;

  printName(): void {
    console.log(`Department : ${this.name}`);
  }
}

class Accounting extends Department{
  constructor(){
    // call name from parent
    // Accounting Department assign to this.name
    super('Accounting Department')
  }

  printMeeting():void{
    console.log("meeting at 9:am")
  }
}

const account1 = new Accounting()
// account1.printName();
account1.printMeeting()