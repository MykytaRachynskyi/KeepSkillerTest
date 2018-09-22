using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        const string DateKeyword = "Date";
        static readonly char[] numberLiterals = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static void Main(string[] args)
        {
            Console.WriteLine("Press Q to exit");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q))
            {
                Console.WriteLine("Please input a line of text below");
                string input = Console.ReadLine();
                Console.WriteLine(Respond(input));
            }

        }

        static string Respond(string input)
        {
            if (input.Equals(DateKeyword))                       // Case sensitive .ToUpper to make case insensitive
                return DateTime.Now.Date.ToString();
            else if (numberLiterals.Any(s => input.Contains(s))) // shorthand for: foreach(char c in numberLiterals)
                return "I'm not a calculator";                   //                  if (input.Contains(c))
            else                                                 // which is an even shorterhand for:
                return "Hi!";                                    // foreach(char c in numberLiterals)
        }                                                        //     foreach(char i in input)
                                                                 //         if (c == i)
    }
}



        
    

