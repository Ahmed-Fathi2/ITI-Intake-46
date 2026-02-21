// // //1- default access modifier is public

// // //2- you cant use any var before assign it 
// // // let x2:number;
// // // console.log(x2)----> Error

// // // classes , interface use concise method

// // 1. Types
// console.log("===============================================================");

// let nameone: string = "أحمد";
// let city: string = 'القاهرة';

// // Number - أرقام
// let age: number = 25;
// let price: number = 99.99;

// // Boolean - صح أو غلط
// let isActive: boolean = true;
// let hasAccount: boolean = false;

// // Array - مصفوفات
// let numbers: number[] = [1, 2, 3, 4];
// let names: string[] = ["محمد", "علي", "سارة"];
// // أو بطريقة تانية
// let scores: Array<number> = [90, 85, 95];

// // Any - أي نوع (حاول تتجنبه)
// let anything: any = "نص";
// anything = 123; // مفيش مشكلة
// anything = true; // برضو مفيش مشكلة

// console.log("===============================================================");

// // 2. Interfaces --> Interfaces زي العقد اللي بيحدد شكل الـ object بتاعك:

// interface User {
//     id: number;
//     name: string;
//     email: string;
//     age?: number; // علامة ? معناها optional (اختياري)
//     readonly createdAt: Date; // readonly معناها ميتغيرش بعد الإنشاء
// }

// // استخدام الـ Interface
// let user: User = {
//     id: 1,
//     name: "أحمد محمد",
//     email: "ahmed@example.com",
//     createdAt: new Date()
// };
// // user.createdAt = new Date(); // ❌ خطأ لأنها readonly

// // مثال: بيانات منتج
// interface Productversionone {
//     id: number;
//     title: string;
//     price: number;
//     category: string;
//     inStock: boolean;
//     images?: string[];
// }

// let productone: Productversionone = {
//     id: 101,
//     title: "لابتوب HP",
//     price: 15000,
//     category: "إلكترونيات",
//     inStock: true
// };

// console.log("===============================================================");

// // 3. Classes -(مهمة جداً في Angular)
// class Student {
//     // Properties
//     private id: number;
//     public name: string;
//     protected grade: number;

//     // Constructor
//     constructor(id: number, name: string, grade: number) {
//         this.id = id;
//         this.name = name;
//         this.grade = grade;
//     }

//     // Methods
//     getInfo(): string {
//         return `${this.name} - Grade: ${this.grade}`;
//     }

//     updateGrade(newGrade: number): void {
//         if (newGrade >= 0 && newGrade <= 100) {
//             this.grade = newGrade;
//         }
//     }
// }

// // استخدام الكلاس
// let student = new Student(1, "محمد", 85);
// console.log(student.getInfo()); // محمد - Grade: 85
// student.updateGrade(90);

// // طريقة مختصرة للـ Constructor (بتستخدم كتير في Angular) ----> important
// class Product {
//     constructor(
//         public id: number,
//         public name: string,
//         public price: number
//     ) { }
// }

// let product = new Product(1, "قلم", 5);
// console.log(product.name); // قلم


// // 4. Access Modifiers (مهمين جداً)
// class BankAccount {
//     public accountNumber: string;    // متاح في أي مكان
//     private balance: number;          // متاح داخل الكلاس بس
//     protected owner: string;          // متاح داخل الكلاس والكلاسات الوارثة منه

//     constructor(accountNumber: string, owner: string) {
//         this.accountNumber = accountNumber;
//         this.balance = 0;
//         this.owner = owner;
//     }

//     deposit(amount: number): void {
//         this.balance += amount;
//     }

//     getBalance(): number {
//         return this.balance;
//     }
// }

// let account = new BankAccount("123456", "أحمد");
// account.deposit(1000);
// console.log(account.getBalance()); // 1000
// // console.log(account.balance); // ❌ خطأ لأنها private

// console.log("===============================================================");


// // 5. Inheritance - الوراثة
// // الكلاس الأب
// class Person {
//     constructor(
//         public name: string,
//         public age: number
//     ) { }

//     introduce(): string {
//         return `أنا ${this.name} وعندي ${this.age} سنة`;
//     }
// }

// // الكلاس الابن
// class Employee extends Person {
//     constructor(
//         name: string,
//         age: number,
//         public jobTitle: string,
//         public salary: number
//     ) {
//         super(name, age); // استدعاء الـ constructor بتاع الأب
//     }

//     // Override - تعديل الميثود
//     introduce(): string {
//         return `${super.introduce()} وبشتغل ${this.jobTitle}`;
//     }

//     getAnnualSalary(): number {
//         return this.salary * 12;
//     }
// }

// let employee = new Employee("علي", 30, "مطور", 8000);
// console.log(employee.introduce());
// console.log(employee.getAnnualSalary()); // 96000


// console.log("===============================================================");

// // 6. Generics 

// function getFirstElement<T>(arr: T[]): T {
//     return arr[0];
// }

// let firstNumber = getFirstElement<number>([1, 2, 3]); // 1
// let firstName = getFirstElement<string>(["أحمد", "محمد"]); // أحمد

// // مثال عملي: ApiResponse
// interface ApiResponse<T> {
//     status: number;
//     message: string;
//     data: T;
// }

// interface UserData {
//     id: number;
//     username: string;
// }

// let response: ApiResponse<UserData> = {
//     status: 200,
//     message: "Success",
//     data: {
//         id: 1,
//         username: "ahmed123"
//     }
// };

// // Generic Class - بتستخدم كتير في Angular Services
// class DataService<T> {
//     private items: T[] = [];

//     add(item: T): void {
//         this.items.push(item);
//     }

//     getAll(): T[] {
//         return this.items;
//     }

//     getById(id: number): T | undefined {
//         return this.items.find((item: any) => item.id === id);
//     }
// }

// let userService = new DataService<User>();
// userService.add({ id: 1, name: "أحمد", email: "a@a.com", createdAt: new Date() });

// console.log("===============================================================");


// // 7. Union Types & Type Aliases
// // Union Types - أكتر من نوع
// let statusone: string | number;
// statusone = "نشط";
// statusone = 1; // كلاهما صحيح

// type ID = string | number;
// let userId: ID = 123;
// let productId: ID = "PROD-456";

// // Type Alias
// type UserRole = 'admin' | 'user' | 'guest';
// let role: UserRole = 'admin';
// // let role2: UserRole = 'superadmin'; // ❌ خطأ

// type Point = {
//     x: number;
//     y: number;
// };
// let coordinate: Point = { x: 10, y: 20 };

// console.log("===============================================================");

// // 15. Intersection Types

// interface me {
//     name: string;
//     age: number;
// }

// interface you {
//     employeeId: number;
//     department: string;
// }

// type Staff = me & you;

// let staff: Staff = {
//     name: "أحمد",
//     age: 30,
//     employeeId: 123,
//     department: "IT"
//     // لازم يكون فيه كل الخصائص
// };



// // مثال عملي
// interface Timestamped {
//     createdAt: Date;
//     updatedAt: Date;
// }

// interface Post {
//     title: string;
//     content: string;
//     author: string;
// }

// type BlogPost = Post & Timestamped;

// let post: BlogPost = {
//     title: "مقال جديد",
//     content: "محتوى المقال",
//     author: "أحمد",
//     createdAt: new Date(),
//     updatedAt: new Date()
// };
// console.log("===============================================================");

// // 8. Enums 
// enum OrderStatus {
//     Pending = 'PENDING',
//     Processing = 'PROCESSING',
//     Shipped = 'SHIPPED',
//     Delivered = 'DELIVERED',
//     Cancelled = 'CANCELLED'
// }

// interface Order {
//     id: number;
//     status: OrderStatus;
//     total: number;
// }

// let order: Order = {
//     id: 1,
//     status: OrderStatus.Pending,
//     total: 500
// };

// if (order.status === OrderStatus.Pending) {
//     console.log("الطلب في انتظار المعالجة");
// }

// // Numeric Enum
// enum Priority {
//     Low = 1,
//     Medium = 2,
//     High = 3
// }

// let taskPriority: Priority = Priority.High;

// console.log("===============================================================");


// // 9. Functions ف

// function add(a: number, b: number): number {
//     return a + b;
// }

// // Arrow Function
// const multiply = (a: number, b: number): number => {
//     return a * b;
// };

// // معاملات اختيارية
// function greet(name: string, age?: number): string {
//     if (age) {
//         return `مرحباً ${name}، عمرك ${age} سنة`;
//     }
//     return `مرحباً ${name}`;
// }

// // قيم افتراضية
// function createUser(name: string, role: string = 'user'): void {
//     console.log(`${name} - ${role}`);
// }

// createUser("أحمد"); // أحمد - user
// createUser("محمد", "admin"); // محمد - admin

// // Rest Parameters
// function sum(...numbers: number[]): number {
//     return numbers.reduce((total, num) => total + num, 0);
// }
// console.log(sum(1, 2, 3, 4, 5)); // 15

// console.log("===============================================================");


// // 10. Promises & Async/Await (مهم للـ HTTP Requests)

// function fetchUser(id: number): Promise<User> {
//     return new Promise((resolve, reject) => {
//         setTimeout(() => {
//             resolve({
//                 id: id,
//                 name: "أحمد",
//                 email: "ahmed@test.com",
//                 createdAt: new Date()
//             });
//         }, 1000);
//     });
// }

// // استخدام Promise
// fetchUser(1).then(user => {
//     console.log(user.name);
// });

// // Async/Await (الطريقة الأحدث)
// async function getUserData(id: number): Promise<void> {
//     try {
//         const user = await fetchUser(id);
//         console.log(user.name);
//     } catch (error) {
//         console.error("خطأ في جلب البيانات", error);
//     }
// }

// console.log("===============================================================");

// // 1. Array Destructuring (تفكيك المصفوفات)

// let numbers1 = [1, 2, 3, 4, 5];
// let firstone = numbers1[0];
// let secondtwo = numbers1[1];

// // بالـ Destructuring (أسهل وأوضح)
// let [firsto, secondtw, thirdth] = [1, 2, 3, 4, 5];
// console.log(firsto);  // 1
// console.log(secondtw); // 2
// console.log(thirdth);  // 3

// // مثال عملي
// let colors = ["أحمر", "أخضر", "أزرق", "أصفر"];
// let [primary, secondary, tertiary] = colors;
// console.log(primary);   // أحمر
// console.log(secondary); // أخضر
// console.log(tertiary);  // أزرق

// // تخطي عناصر
// numbers = [1, 2, 3, 4, 5];

// // لو عايز أول وتالت عنصر بس
// let [first1, , third3] = numbers;
// console.log(first1); // 1
// console.log(third3); // 3

// // لو عايز أول وآخر عنصر
// let [firstNum, , , , lastNum] = numbers;
// console.log(firstNum); // 1
// console.log(lastNum);  // 5


// // Rest Operator(...) مع Arrays:
// numbers = [1, 2, 3, 4, 5, 6, 7];

// // ياخد أول عنصرين والباقي في مصفوفة
// let [first, second, ...rest] = numbers;
// console.log(first);  // 1
// console.log(second); // 2
// console.log(rest);   // [3, 4, 5, 6, 7]

// // مثال عملي: فصل أول طالب عن الباقي
// let students = ["أحمد", "محمد", "علي", "سارة", "فاطمة"];
// let [topStudent, ...otherStudents] = students;
// console.log(topStudent);      // أحمد
// console.log(otherStudents);   // ["محمد", "علي", "سارة", "فاطمة"]

// // Default Values(القيم الافتراضية):
// // لو المصفوفة أصغر من المتوقع
// let [aone, btwo, cth = 3] = [1, 2];
// console.log(aone); // 1
// console.log(btwo); // 2
// console.log(cth); // 3 (القيمة الافتراضية)

// let [xone, ytwo, z = 10] = [5, 15, 20];
// console.log(z); // 20 (لأن في قيمة موجودة)

// // مثال عملي
// let [nameonoe, ageonoe = 18] = ["أحمد"];
// console.log(nameonoe); // أحمد
// console.log(ageonoe);  // 18


// // تبديل القيم(Swapping):
// // بالـ Destructuring (سطر واحد!)
// let x = 10;
// let y = 20;
// [x, y] = [y, x];
// console.log(x); // 20
// console.log(y); // 10

// // مثال عملي
// let player1Score = 100;
// let player2Score = 200;
// [player1Score, player2Score] = [player2Score, player1Score];
// console.log(player1Score); // 200
// console.log(player2Score); // 100


// // Nested Arrays(مصفوفات متداخلة):

// // مثال معقد أكتر
// let matrix = [
//     [1, 2, 3],
//     [4, 5, 6],
//     [7, 8, 9]
// ];

// let [[a1, a2], [b1, b2], [c1, c2]] = matrix;
// console.log(a1, a2); // 1 2
// console.log(b1, b2); // 4 5
// console.log(c1, c2); // 7 8


// console.log("===============================================================");


// // 2. Object Destructuring(تفكيك الكائنات)

// let usertest = {
//     idy: 1,
//     nameyy: "أحمد",
//     emaily: "ahmed@example.com",
//     agey: 25
// };

// let idx = user.id;
// let namex = user.name;
// let emailx = user.email;

// // بالـ Destructuring (أسهل بكتير!)
// let { idy, nameyy, emaily, agey } = usertest;
// console.log(idy);    // 1
// console.log(nameyy);  // أحمد
// console.log(emaily); // ahmed@example.com
// console.log(agey);   // 25


// // تغيير الأسماء:
// let usert = {
//     id: 1,
//     name: "أحمد",
//     email: "ahmed@example.com"
// };

// //aliasing
// let { name: userName1, email: userEmail, id: userId1 } = usert;
// console.log(userName1);  // أحمد
// console.log(userEmail); // ahmed@example.com
// console.log(userId1);    // 1


// // Default Values:
//  let user22 = {
//     name22: "أحمد",
//     age11: 25
// };

// // لو الخاصية مش موجودة
// let { name22, age11, city = "القاهرة", country = "مصر" } = user22;
// console.log(name);    // أحمد
// console.log(age);     // 25
// console.log(city);    // القاهرة (قيمة افتراضية)
// console.log(country); // مصر (قيمة افتراضية)

// // الجمع بين التسمية والقيم الافتراضية
// let { name: userName = "ضيف", age: userAge = 18 } = {};
// console.log(userName); // ضيف
// console.log(userAge);  // 18


// // Rest Operator مع Objects:
// let user77 = {
//     id: 1,
//     name44: "أحمد",
//     email: "ahmed@example.com",
//     age: 25,
//     city: "القاهرة",
//     country: "مصر"
// };

// // ياخد id و name والباقي في object جديد
// let { id, name44, ...otherInfo } = user77;
// console.log(id);   // 1
// console.log(name); // أحمد
// console.log(otherInfo);
// // { email: "ahmed@example.com", age: 25, city: "القاهرة", country: "مصر" }

// // مثال عملي: فصل بيانات المصادقة عن بيانات الملف الشخصي
// let userData = {
//     username: "ahmed123",
//     password: "secret",
//     firstName: "أحمد",
//     lastName: "محمد",
//     phone: "0123456789"
// };

// let { username, password, ...profile } = userData;
// console.log(username, password); // ahmed123 secret
// console.log(profile);
// // { firstName: "أحمد", lastName: "محمد", phone: "0123456789" }


let a ;
a=10;
a="dc,";

let b =200;