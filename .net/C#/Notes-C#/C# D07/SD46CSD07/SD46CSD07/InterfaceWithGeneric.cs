using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    ///with generic [in,out] applicable with 
    ///1-interface
    ///2-delegate
    ///
    interface IMathService<in T, out U>
    {
        U Add(T left, T right);
        U Sub(T left, T right);
        U Mul(T left, T right);
        U Div(T left, T right);
    }

    ///IMathService<int,float> o1=......


    //Repository pattern
    //class EmployeeService
    //{
    //    public Employee[] GetAll()
    //    {
    //        ////
    //    }
    //    public Employee GetOne(int id) 
    //    {
    //        ///
    //    }
    //    public void Add(Employee employee) { }
    //    public void update(Employee employee) { }
    //    public void Delete(int id) { }
    //}

    ////////////////
    //public interface IEmployeeService
    //{
    //    public Employee[] GetAll();
    //    public Employee GetOne(int id);
    //    void Add(Employee employee);
    //    void update(Employee employee);
    //    void Delete(int id);
    //}
    //class EmployeeService : IEmployeeService
    //{
    //    public void Add(Employee employee)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Employee[] GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Employee GetOne(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void update(Employee employee)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    ////////////////////////////////////////////////////
    //public interface ICompanyService<T> 
    //{
    //    public T[] GetAll();
    //    public T GetOne(int id);
    //    void Add(T item);
    //    void update(T item);
    //    void Delete(int id);
    //}

    //class EmployeeService : ICompanyService<Employee>
    //{
    //    public void Add(Employee item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Employee[] GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Employee GetOne(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void update(Employee item)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //class DepartmentService : ICompanyService<Department>
    //{
    //    public void Add(Department item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Department[] GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Department GetOne(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void update(Department item)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    ////////////////////////////////////////////////

    public interface ICompanyService<T>
    {
        public T[] GetAll();
        public T GetOne(int id);
        void Add(T item);
        void update(T item);
        void Delete(int id);
    }

    public class CompanyService<T> : ICompanyService<T>
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
            //EFObject.Add(item)
            //EFObject.SaveChanges()

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T[] GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void update(T item)
        {
            throw new NotImplementedException();
        }
    }

    ///Main
    ///CompanyService<Employee> s1=new CompanyService<Employee>();
    /////s1.Add(new Employee())
    ///CompanyService<Department> s2=new CompanyService<Department>();
    /////s2.Add(new Department(){})

}
