using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Section_A
{
    public class Program
    {
       public  static void Main(string[] args)
        {
            int aNum = 87;
            int bNum = 45;

            SwapTwoNumbers(aNum, bNum); // swap two number after and before

            Console.WriteLine();
            Console.WriteLine("Absolute values");

            int num1 = 6832;
            int num2 = -392;

            int absValue1 = AbsoluteValue(num1);  // calling absolute value method
            int absValue2 = AbsoluteValue(num2);

            Console.WriteLine($"Absolute value of {num1} is {absValue1}");
            Console.WriteLine($"Absolute value of {num2} is {absValue2}");

            Console.WriteLine();
            Console.WriteLine(" Check leap year");
                                    // check if a year leap year
            int year = 2016; 
            int year2 = 2018;

            bool isLeapYear = IfYearIsLeap(year);
            bool isLeapYear2 = IfYearIsLeap(year2);

            Console.WriteLine($"IsleapYear ({year}) -> {isLeapYear}");
            Console.WriteLine($"IsleapYear ({year2}) -> {isLeapYear2}");

            Console.WriteLine(); //4. calling methods whether a number contains 3 digit or not
            Console.WriteLine("Is the number contains 3 digit"); 
            //int num = 7201432;
            int num4 = 87501;
            bool contains3 = IfNumberContains3(num4);
           

            if (contains3)
            {
                Console.WriteLine($"The number contains {num4} -> {contains3}");
            }
            else 
            {
                Console.WriteLine($"The number does not contain ({num4}) -> {contains3}");
            }

            int num5 = 30; // 5. chech prime number
            List<int> primes = SieveOfEratosthenes(num5);

            Console.WriteLine("Prime numbers from range [2, 30]:");
            foreach (int prime in primes)
            {
                Console.WriteLine(prime);
            }

            Console.WriteLine(); // 6. check string
            Console.WriteLine(" Checking string");

            string str1 = "##abc##def";
            string str2 = "12####78";
            string str3 = "gar##d#en";
            string str4 = "++##--##++";

            Console.WriteLine(ExtractString(str1)); // abc
            Console.WriteLine($"{ExtractString(str2)} empty string"); // empty string
           // Console.WriteLine(ExtractString(str3), " Empty string"); // empty string
            Console.WriteLine(ExtractString(str4)); // --

            Console.WriteLine(); // 7. method that returns number of occurrences of substring in the string
            Console.WriteLine("Check the occurence of the letter in a word");
            string str = "do it now";
            string substring = "do";

            /*string str = "empty";
            string substring = "d";*/

            int count = HowManyOccurrences(str, substring);
            Console.WriteLine($"The number of occurrences of {substring} in {str} is {count}");


        }

        public static void SwapTwoNumbers(int aNum, int bNum)
        {
            int temp = aNum;
            aNum = bNum;
            bNum = temp;
            Console.WriteLine("Swaps them using temporary variable");
            Console.WriteLine($"Before: a = {bNum}, b = {aNum}");
            Console.WriteLine($"After: a = {aNum}, b = {bNum}");
           
        }
        // check absolute value
        public static int AbsoluteValue(int num)
        {
            if (num >= 0)
            {
                return num;
            }
            else
            {
                return -num;
            }
        }
        // Check if a year is leap
        public static bool IfYearIsLeap(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }
        public static bool IfNumberContains3(int num)
        {
            while (num > 0)
            {
                if (num % 10 == 3)
                {
                    return true;
                }
                num /= 10;
            }
            return false;
        }
        public static List<int> SieveOfEratosthenes(int num)
        {
            // Create a boolean array to track prime numbers.
            bool[] isPrime = new bool[num + 1];
            for (int i = 0; i < num + 1; i++)
            {
                isPrime[i] = true;
            }

            // Mark all multiples of prime numbers as non-prime.
            for (int i = 2; i * i <= num; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= num; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            // Create a list to store the prime numbers.
            List<int> primes = new List<int>();
            for (int i = 2; i <= num; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
        //6
        public static string ExtractString(string str)
        {
            int start = str.IndexOf("##");
            int end = str.LastIndexOf("##");

            if (start == -1 || end == -1)
            {
                return "";
            }
            else 
            {
                return str.Substring(start + 2, end - start - 2);
            }
        }
        public static int HowManyOccurrences(string str, string substring) // 7
        {
            int count = 0;
            int index = str.IndexOf(substring);

            while (index != -1)
            {
                count++;
                index = str.IndexOf(substring, index + substring.Length);
            }

            return count;
        }

    }
}
