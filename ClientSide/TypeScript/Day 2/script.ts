// public --> accessible from anywhere
//private --> accessible only inside the class
//protected --> accessible within class and child classes

class BankAccount {
  public readonly id: number;
  public owner: string;

  private _balance: number;
  protected taxRate: number = 0.05;

  constructor(id: number, owner: string, balance: number) {
    this.id = id;
    this.owner = owner;
    this._balance = balance;
  }

  // public method
  // public to add on private balance
  deposit(amount: number): void {
    if (amount <= 0) {
      throw new Error("invalid deposit amount");
    }
    this._balance += amount;
  }

  // getter -> behave like [property]
  // return private balance
  get balance(): number {
    return this._balance;
  }

  // private method
  private calculateTax(amount: number): number {
    return amount * this.taxRate;
  }
}

class SavingsAccount extends BankAccount {
  constructor(id: number, owner: string, balance: number) {
    super(id, owner, balance);
  }

  calculateInterest(rate: number): number {
    const interest = this.balance * rate;
    const tax = interest * this.taxRate;
    return interest - tax;
  }
}

const account = new BankAccount(1, "ali", 1000);
account.deposit(500); //add private balance(1000) + 500 (parameter --> amount)
console.log(account.balance);
console.log(account.owner)

const savings = new SavingsAccount(2,"ahmed" , 2000);
console.log(savings.calculateInterest(0.5))