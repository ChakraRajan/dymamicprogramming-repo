using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        public static long Fibonacci(int value, Hashtable prevValues = null)
        {
            if (prevValues is null)
                prevValues = new Hashtable();

            if (value <= 2)
                return 1;

            if (prevValues.Contains(value))
                return Convert.ToInt64(prevValues[value]);

            prevValues[value] = Fibonacci(value - 1, prevValues) + Fibonacci(value - 2, prevValues);
            
            return Convert.ToInt64(prevValues[value]);

        }

        public static long gridTraveller(int row, int col, Hashtable prevValues= null)
        {
            string key = row.ToString() + ',' + col.ToString();

            if(prevValues is null)
                prevValues = new Hashtable();

            if (prevValues.ContainsKey(key))
                return Convert.ToInt64(prevValues[key]);

            if (row == 1 && col == 1)
                return 1;   

            if (row == 0 || col == 0)
                return 0;

            prevValues[key] = gridTraveller(row - 1, col, prevValues) + gridTraveller(row, col - 1, prevValues);
            return Convert.ToInt64(prevValues[key]);
        }

        public static bool CanSum(int target, int[] values, Hashtable prevValues = null)
        {
            if (prevValues is null)
                prevValues = new Hashtable();

            if (prevValues.ContainsKey(target))
                return Convert.ToBoolean(prevValues[target]);

            if (target == 0)
                return true;

            if (target < 0)
                return false;

            foreach(var num in values)
            {
                int remainderValue = target - num;
                if (CanSum(remainderValue, values))
                {
                    prevValues[target] = true;
                    return true;
                }
            }

            return false;            
        }

        public static List<int> HowSum(int target, int[] values, Hashtable prevValues = null)
        {
            if (prevValues is null)
                prevValues = new Hashtable();

            if (prevValues.ContainsKey(target))
                return (List<int>)prevValues[target];

            if (target == 0)
                return new List<int>() { };

            if (target < 0)
                return null;

            foreach (var num in values)
            {
                int remainderValue = target - num;
                List<int> remainderResult = HowSum(remainderValue, values);

                if(remainderResult != null)
                {
                    remainderResult.Add(num);
                    
                    prevValues[target] = remainderResult;

                    return remainderResult;
                }
            }

            return null;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Fibonacci Sequence!");
            //Console.WriteLine(Fibonacci(50));

            //Console.WriteLine("Grid Sequence!");
            //Console.WriteLine(gridTraveller(18,18));

            //Console.WriteLine("Can Sum");
            //Console.WriteLine(CanSum(7, new int[] { 2, 3, 4 }));

            Console.WriteLine("How Sum");
            List<int> returnValues;
            
            returnValues = HowSum(8, new int[] { 2, 3, 5 });

            foreach (var v in returnValues)
            {
                Console.WriteLine(v.ToString());
            }

        }
    }
}
