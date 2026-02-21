using ConsoleApp1.Lab.Lab3;

struct Employee:IComparable<Employee>
{
    int id;
    decimal salary;
    HiringDate hireDate;
    Gender gender;
    SecurityLevel securityLevel;

    // Constructor
    public Employee(int id, decimal salary, HiringDate hireDate,
                    Gender gender, SecurityLevel securityLevel)
    {
        this.id = id;
        this.salary = salary;
        this.hireDate = hireDate;
        this.gender = gender;
        this.securityLevel = securityLevel;
    }

   
    public int GetId() => id;
    public void SetId(int id) => this.id = id;

    public decimal GetSalary() => salary;
    public void SetSalary(decimal salary) => this.salary = salary;

    public HiringDate GetHireDate() => hireDate;
    public void SetHireDate(HiringDate hireDate) => this.hireDate = hireDate;

    public Gender GetGender() => gender;
    public void SetGender(Gender gender) => this.gender = gender;

    public SecurityLevel GetSecurityLevel() => securityLevel;
    public void SetSecurityLevel(SecurityLevel level) => this.securityLevel = level;

   
    public string Print()
    {
        return $"ID: {id} | Salary: {salary:C} | Hire Date: {hireDate} | Gender: {gender} | Security: {securityLevel}";
    }

    public override string ToString()
    {
        return $"ID: {id} | Salary: {salary:C} | Hire Date: {hireDate} | Gender: {gender} | Security: {securityLevel}";
    }

  
    public int CompareTo(Employee other)
    {
        return this.hireDate.CompareTo(other.hireDate);
    }
}
