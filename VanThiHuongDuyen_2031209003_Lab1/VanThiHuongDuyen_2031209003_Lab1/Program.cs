using System;
using static System.Net.Mime.MediaTypeNames;

namespace VanThiHuongDuyen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            //Console.WriteLine("Enter number a: ");
            //int a = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter number b: ");
            //int b = Convert.ToInt32(Console.ReadLine());

            //Sum of two number
            //SumOfTwoNumber(a, b);
            //Swap two number
            //SwapTwoNumber(a, b);

            //Classify student
            //Console.WriteLine("Enter score: ");
            //int score = Convert.ToInt32(Console.ReadLine());
            //ClassifyStudent(score);

            //Corresponding month name
            //Console.WriteLine("Enter month: ");
            //int month = Convert.ToInt32(Console.ReadLine());
            //CorrespondingMonthName(month);

            //Sum of positieve number
            Console.WriteLine("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            CalSum(number);
        }

        static void SumOfTwoNumber(int a, int b)
        {
            Console.WriteLine("The sum of a and b is: " + (a + b));
        }

        static void SwapTwoNumber(int firstNumber, int secondNumber)
        {

            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;

            Console.WriteLine("After swapping,number a : " + firstNumber);
            Console.WriteLine("After swapping,number b: " + secondNumber);

        }

        static void ClassifyStudent(int score)
        {
            if (score < 70)
            {
                Console.WriteLine("Average");
            }
            else if (score <= 79)
            {
                Console.WriteLine("Fair");
            }
            else if (score <= 89)
            {
                Console.WriteLine("Good");
            }
            else
            {
                Console.Write("Excellent");
            }
        }

        static void CorrespondingMonthName(int month)
        {
            if (month < 1 || month > 12)
            {
                Console.WriteLine("The month input is invalid");
            }

            switch (month)
            {
                case 1:
                    Console.WriteLine("January - Have 31 days.");
                    break;
                case 2:
                    Console.WriteLine("February - Have 28 days.");
                    break;
                case 3:
                    Console.WriteLine("March - Have 31 days.");
                    break;
                case 4:
                    Console.WriteLine("April - Have 30 days.");
                    break;
                case 5:
                    Console.WriteLine("May - Have 31 days.");
                    break;
                case 6:
                    Console.WriteLine("June - Have 30 days.");
                    break;
                case 7:
                    Console.WriteLine("July - Have 31 days.");
                    break;
                case 8:
                    Console.WriteLine("August - Have 31 days.");
                    break;
                case 9:
                    Console.WriteLine("September - Have 30 days.");
                    break;
                case 10:
                    Console.WriteLine("October - Have 31 days.");
                    break;
                case 11:
                    Console.WriteLine("November - Have 30 days.");
                    break;
                case 12:
                    Console.WriteLine("December - Have 31 days.");
                    break;
            }
        }

        static void CalSum(int number)
        {
            if (number <= 0)
            {
                Console.WriteLine("The entered number is invalid");
            }
            int sum = 0;
            for (int i = 0; i < number; i++)
            {
                sum += i;
            }

            Console.WriteLine("Sum of number is: " + sum);
        }
    }
}
