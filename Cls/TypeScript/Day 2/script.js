// public --> accessible from anywhere
//private --> accessible only inside the class
//protected --> accessible within class and child classes
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var BankAccount = /** @class */ (function () {
    function BankAccount(id, owner, balance) {
        this.taxRate = 0.05;
        this.id = id;
        this.owner = owner;
        this._balance = balance;
    }
    // public method
    // public to add on private balance
    BankAccount.prototype.deposit = function (amount) {
        if (amount <= 0) {
            throw new Error("invalid deposit amount");
        }
        this._balance += amount;
    };
    Object.defineProperty(BankAccount.prototype, "balance", {
        // getter -> behave like [property]
        // return private balance
        get: function () {
            return this._balance;
        },
        enumerable: false,
        configurable: true
    });
    // private method
    BankAccount.prototype.calculateTax = function (amount) {
        return amount * this.taxRate;
    };
    return BankAccount;
}());
var SavingsAccount = /** @class */ (function (_super) {
    __extends(SavingsAccount, _super);
    function SavingsAccount(id, owner, balance) {
        return _super.call(this, id, owner, balance) || this;
    }
    SavingsAccount.prototype.calculateInterest = function (rate) {
        var interest = this.balance * rate;
        var tax = interest * this.taxRate;
        return interest - tax;
    };
    return SavingsAccount;
}(BankAccount));
var account = new BankAccount(1, "ali", 1000);
account.deposit(500); //add private balance(1000) + 500 (parameter --> amount)
console.log(account.balance);
console.log(account.owner);
var savings = new SavingsAccount(2, "ahmed", 2000);
console.log(savings.calculateInterest(0.5));
