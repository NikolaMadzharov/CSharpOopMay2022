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
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            Salary = salary;


        }
        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (this.salary>460)
                {
                    throw new Exception("Salary cannot be less than 650 leva!");
                }
                    this.salary = value;
            } }

        public string FirstName
        {
            get { return this.firstname; }
            private set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstname = value;
            } }

        public string LastName
        {
            get { return this.lastname; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                this.lastname = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age=value;
            } }

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
            return $"{firstname}{lastname} receives {Salary:f2} leva.";

        }
    }
}
