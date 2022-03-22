using System;

namespace Logic_x1
{
    public static class Logic1
    {
        public static bool isPrime(string number)
        {
            int myNumber;
            try
            {
                myNumber = Int32.Parse(number);
            }
            catch
            {
                Console.WriteLine("Please, introduce a number.");
                return false;
            }

            if (myNumber <= 1) return false;
            if (myNumber == 2) return true;
            if (myNumber % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(myNumber));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (myNumber % i == 0) return false;
            }

            return true;
        }

        public static string countPrimes(string start, string end)
        {
            var x = Int32.Parse(start);
            var y = Int32.Parse(end);
            var counter = 0;

            while (x <= y)
            {
                if (isPrime(x.ToString()))
                {
                    counter++;
                }
                x++;
            }
            return counter.ToString();
        }
    }
}
