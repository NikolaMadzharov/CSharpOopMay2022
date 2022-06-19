using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IDentible> collection = new List<IDentible>();

            string input = Console.ReadLine();
            while (input!="End")
            {
                string[] info = input.Split();
                if (info.Length==3)
                {
                    string name = info[0];
                    int age =  int.Parse(info[1]);
                    string id = info[2];
                    IDentible citizen =  new Citizens(id,name,age);
                    collection.Add(citizen);
                }
                else if (info.Length==2)
                {
                    string model=info[0];
                    string id = info[1];
                    IDentible robot = new Robot(id,model);
                    collection.Add(robot);
                }
                input = Console.ReadLine();
            }
            string idToCheck = Console.ReadLine();

            foreach (var item in collection)
            {
                if (item.Id.EndsWith(idToCheck))
                {
                    Console.WriteLine(item.Id);
                }
            }
        } 
    }
}
