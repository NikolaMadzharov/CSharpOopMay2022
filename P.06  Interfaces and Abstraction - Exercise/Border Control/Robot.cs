using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IDentible
    {
        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }

        public string Id { get; }

        public string Model { get;  }

        
    }
}
