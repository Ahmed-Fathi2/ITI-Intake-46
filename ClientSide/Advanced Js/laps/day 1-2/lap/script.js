// var rect = {

//     width: 5,
//     hieght: 10,
//     getArea: function () {
//         return (this.width * this.hieght);

//     },
//     getPerimeter: function () {

//         return ((this.width + this.hieght) * 2)
//     },
//     getRectInfo: function () {

//         console.log(`width = ${this.width}`);
//         console.log(`hieght = ${this.hieght}`);
//         console.log(`Area = ${this.getArea()}`);
//         console.log(`Perimeter = ${this.getPerimeter()}`);

//     }

// }


// console.log(rect.width);
// console.log(rect.hieght);

// console.log(rect.getArea());
// console.log(rect.getPerimeter());

// rect.getRectInfo();


// =================================================================================================

// var generator = {
//     getSetGen() {
//         for (let key in this) {


//             if (typeof this[key] === "function") continue;

//             var value = this[key];

//             Object.defineProperty(this, key, {
//                 get() {
//                     console.log("get")
//                     return value;
//                 },
//                 set(newValue) {
//                     // console.log("set")
//                     // value = newValue;

//                     if (newValue < 0) return;
//                     value = newValue;
//                 }
//             });
//         }
//     }
// };


// var user = {
//     name: "Ahmed",
//     age: 25,
//     print() {
//         console.log(this.name);
//     }

// };



// // user.getSetGen = generator.getSetGen;


// // user.getSetGen();

// // user.age = -5;
// // console.log(user.age);



// // generator.getSetGen.call(user);

// // generator.getSetGen.apply(user);

// var getSetGenerator = generator.getSetGen.bind(user);
// getSetGenerator()



// user.age = -5;
// console.log(user.age);

// user.age = 35;
// console.log(user.age);

// ========================================================================================================================

// function Book(title, numOfChapters, author, numOfPages, publisher, numOfCopies) {
//     this.title = title;
//     this.numOfChapters = numOfChapters;
//     this.author = author;
//     this.numOfPages = numOfPages;
//     this.publisher = publisher;
//     this.numOfCopies = numOfCopies;
// }


// function Box(height, width, length, material, numOfBooks) {
//     this.height = height;
//     this.width = width;
//     this.length = length;
//     this.material = material;
//     this.content = [];
//     this.numOfBooks = numOfBooks;
// }



// Box.prototype.volume = function () {
//     return this.height * this.width * this.length;
// };

// Box.prototype.addBook = function (book) {

//     if (this.countBooks() === this.numOfBooks)
//         console.log("box is Full")
//     else
//         this.content.push(book);
// };


// Box.prototype.countBooks = function () {
//     return this.content.length;
// };


// Box.prototype.deleteBookByTitle = function (title) {
//     var flag = 0
//     for (var i = 0; i < this.content.length; i++) {
//         if (this.content[i].title === title) {
//             this.content.splice(i, 1);
//             flag = 1;
//             break;
//         }

//     }
//     if (flag === 0)
//         console.log(`book with Title ${title}  not found`);
// };

// Box.prototype.toString = function () {

//     var boxDetails = `height of Box = ${this.height}\nwidth = ${this.width}\nnumOfBooks=${this.countBooks()}`
//     return boxDetails
// }

// Box.prototype.valueOf= function () {

//     return this.countBooks();

// }



// var myBox1 = new Box(50, 40, 60, "Wood", 2);




// var book1 = new Book("JS", 10, "ahmed", 200, "xyz", 5);
// var book2 = new Book("HTML", 8, "mohamed", 150, "abc", 3);
// var book3 = new Book("CSS", 12, "fathi", 300, "klm", 2);


// myBox1.addBook(book1);
// myBox1.addBook(book2);
// myBox1.addBook(book3);
// console.log(myBox1.countBooks());



// console.log(myBox1.volume());


// // myBox.deleteBookByTitle("HTML");
// myBox1.deleteBookByTitle("React");
// console.log(myBox1.countBooks());

// console.log(myBox1.toString());


// var myBox2 = new Box(50, 40, 60, "Wood", 2);
// myBox2.addBook(book2);
// myBox2.addBook(book3);




// // num of books in box1 && box2

// console.log(`num of books in box1 && box2 = ${myBox1+myBox2}`)





