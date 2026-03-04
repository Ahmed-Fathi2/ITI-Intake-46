
var form = document.getElementById('booksFormDetails');
var bookName = document.getElementById('bookName');
var price = document.getElementById('price');
var authorName = document.getElementById('authorName');
var authorEmail = document.getElementById('authorEmail');

var bookNameError = document.getElementById('bookNameError');
var priceError = document.getElementById('priceError');
var authorNameError = document.getElementById('authorNameError');
var authorEmailError = document.getElementById('authorEmailError');

var BookNum = JSON.parse(localStorage.getItem("BooksNum"));
// console.log(BookNum);




function Book(id, bookName, price, author) {
    this.id = id;
    this.bookName = bookName;
    this.price = price;
    this.author = author;
}

function Author(authorName, authorEmail) {

    this.authorName = authorName;
    this.authorEmail = authorEmail;
}


var count = 0;
var bookCounter = 1;


var books = [];
if (localStorage.getItem("Books")) {
    books = JSON.parse(localStorage.getItem("Books"))
}

console.log(books);
// localStorage.setItem("counter", JSON.stringify(count));
form.addEventListener("submit", function (e) {
    e.preventDefault();
    if (!Validate()) {
        return;
    }
    // var books= JSON.parse( localStorage.getItem("Books"))

    var generatedID = books[books.length - 1].id + 1

    console.log(generatedID)
    console.log("===================================")


    var author = new Author(authorName.value.trim(), authorEmail.value.trim());
    var book = new Book(generatedID, bookName.value.trim(), price.value, author);

    books.push(book);
    
    bookCounter++;

    localStorage.setItem("Books", JSON.stringify(books));

    console.log(JSON.parse(localStorage.getItem("Books")));

    if (bookCounter > BookNum) {
        window.location.replace("/BookCrud/BookCrud.html")
    }

    refreshForm();
})


function refreshForm() {


    bookName.value = "";
    price.value = "";
    authorName.value = "";
    authorEmail.value = "";

}

var nameRegex = /^[a-zA-Zء-ي\s]+$/;
var emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;



function Validate() {

    var isValid = true;
    // =======================================================================
    if (bookName.value.trim() === "") {
        bookNameError.textContent = "bookName is Required"
        isValid = false
    }
    else {

        bookNameError.textContent = ""
    }
    // =======================================================================
    if (price.value.trim() === "") {
        priceError.textContent = "price is Required"
        isValid = false
    }
    else if (price.value.trim() < 0) {
        priceError.textContent = "price must be greater than or equal zero"
        isValid = false
    }
    else {

        priceError.textContent = ""
    }
    // =======================================================================

    if (authorName.value.trim() === "") {
        authorNameError.textContent = "authorName is Required"
        isValid = false
    }
    else if (!nameRegex.test(authorName.value.trim())) {
        authorNameError.textContent = "authorName must be only chars"
        isValid = false
    }
    else {

        authorNameError.textContent = ""
    }
    // =======================================================================

    if (authorEmail.value.trim() === "") {
        authorEmailError.textContent = "authorEmail is Required"
        isValid = false

    }
    else if (!emailRegex.test(authorEmail.value.trim())) {

        authorEmailError.textContent = "Invalid Email Format"
        isValid = false
    }
    else {

        authorEmailError.textContent = ""

    }
    // =======================================================================

    return isValid;
}



