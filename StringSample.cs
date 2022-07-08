using System;

namespace ConsoleApp1
{
    class StringSample
    {
        public static void sample()
        {
            Console.WriteLine("please write your full name:");
            string name = Console.ReadLine();
            Console.WriteLine($"your name is {name}");
            
            int age = Convert.ToInt32(Console.ReadLine());
            long money = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"your age is : {age}");
        }
        
        public static void casting()
        {
            int age = 10;
            short realAge = (short)age;
            Console.WriteLine($"the realAge si  : {realAge}");
        }
        
        public static void StringMethods()
        {
            string name = "daniele";    
            Console.WriteLine(name.Trim());
        }
    }
}
