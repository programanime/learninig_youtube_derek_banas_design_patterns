using System;

namespace ConsoleApp1
{
    class SomeNumbers
    {
        public static void square()
        {
            int sideA = 42;
            int sideB = 20;
            Console.WriteLine("the module si : "+ sideA % sideB);
            
            var (name, lastname, age) = ("daniel", "molina", 10);
            Console.WriteLine($"name:{name} lastname:{lastname} age:{age}");
            
            float money = float.Parse(Console.ReadLine());
            Console.WriteLine($"your money is : {money}");
        }
    }
}