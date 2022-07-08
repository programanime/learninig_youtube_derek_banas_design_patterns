using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class SomeArrays
    {
        public static void sample()
        {
            Console.WriteLine("this is the sample for string");
            string[] coffeeTypes = new string[]{"mocha", "java"};
            float[] coffeeValues = new float[]{1.2f, 1.3f};
            var test=new string[100];
            for(int i=0;i<coffeeTypes.Length;i++){
                Console.WriteLine(coffeeTypes[i]);
            }
        }
        
        public static void collections()
        {
            List<string> tacos = new List<string>();
            tacos.Add("taco bucanero");
            tacos.Add("taco madrigueño");
            
            foreach(string taco in tacos){
                Console.WriteLine(taco);
            }
        }
        
        public static void random()
        {
            Random random = new Random();
            var randomValue = random.Next(10000,20000) ;
            Console.WriteLine($"{randomValue}");
        }
    }
}