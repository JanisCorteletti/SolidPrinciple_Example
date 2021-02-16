using System;
using System.Collections;
using System.Collections.Generic;
using static ConsoleApp2.EventTest;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ABOUT LSP AND OCP!");

            Employee baseEmployee = new Employee(1, "John", "john@gmail.com", "Male", "Active");

            Developer myDeveloper = new Developer(2, "Ann", "Ann@gmail.com", "Female", "Active");

            Secretary mySecretary = new Secretary(3, "Beth", "beth@gmail.com", "Female", "Active");

            //This implementation proves the code is doing LSP
            //We can use the Base (employee) without know the type (developer, adm, manager, lawyer)
            //LSP do NOT need type-checking and type-conversion
            //This mean subclass is subtle for the base class
            IList<Employee> employeeList = new List<Employee>();
            employeeList.Add(baseEmployee);
            employeeList.Add(myDeveloper);
            employeeList.Add(mySecretary);

            foreach (var employee in employeeList)
            {
                Console.WriteLine("Employee Name: " + employee.Name);
                Console.WriteLine("Employee Type: " + employee.Type);
                Console.WriteLine("Employee Salary: " + employee.CalMontlySalaryEmployee(120, 50));
            }
            
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime Created_at { get; set; }

        public Employee() { }

        public Employee(int id, string name, string email, string gender, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Gender = gender;
            this.Status = status;

            this.Type = "Employee";
        }

        public virtual int CalMontlySalaryEmployee(int montlyWorkedHour, int valueHour)
        {
            //If we had to check the type of employee inside the class 
            //to do the calculation, we are not following the OCP
            //This mean the class should be inherited
            //So for this example, we DO are following the OCP =)

            //We could not following the OCP, even when we have inheratance,
            //if we have code here that can be modify before the return
            return montlyWorkedHour * valueHour;
        }
    }

    public class Developer : Employee
    {
        public int BonusDeveloper { get; set; }

        public Developer()
        {
        }

        public Developer(int id, string name, string email, string gender, string status)
        {
            base.Id = id;
            base.Name = name;
            base.Email = gender;
            base.Status = status;
            this.Type = "Developer";
        }

        public override sealed int CalMontlySalaryEmployee(int montlyWorkedHour, int valueHour)
        {
            this.BonusDeveloper = 50;

            var total = base.CalMontlySalaryEmployee(montlyWorkedHour, valueHour) + BonusDeveloper;

            return total;
        }
    }

    public class Secretary : Employee
    {
        public int BonusDeveloper { get; set; }

        public Secretary()
        {
        }

        public Secretary(int id, string name, string email, string gender, string status)
        {
            base.Id = id;
            base.Name = name;
            base.Email = gender;
            base.Status = status;
            this.Type = "Secretary";

        }

        public override sealed int CalMontlySalaryEmployee(int montlyWorkedHour, int valueHour)
        {
            this.BonusDeveloper = 80;

            var total = base.CalMontlySalaryEmployee(montlyWorkedHour, valueHour) + BonusDeveloper;

            return total;
        }
    }


}
