using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : IDentible
    {
        public Citizens(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; }

        public string Name { get; }

        public int Age { get; }

        
    }
}
