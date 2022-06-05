using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstname;
        private int age;
        private string lastname;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            Salary = salary;

        }
        public decimal Salary { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.age>30)
            {
                Salary = Salary + Salary * percentage / 2;
            }
            else
            {
                Salary=Salary+Salary* percentage / 100;
            }
            
        }
        public override string ToString()
        {
            return $"{firstname} {lastname} receives {Salary:f2} leva.";

        }
    }
}
