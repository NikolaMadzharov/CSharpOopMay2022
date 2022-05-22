using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        Random random = new Random();
        public string RandomString()
        {
            
            int randomIndex = random.Next(0,base.Count);
            string element = base[randomIndex];
            base.RemoveAt(randomIndex);
            return element;
        }
    }
}
