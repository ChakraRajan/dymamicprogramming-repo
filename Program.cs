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
                if (CanSum(remainderValue, values, prevValues))
                {
                    prevValues[target] = true;
                    return true;
                }
            }

            prevValues[target] = false;
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
                List<int> remainderResult = HowSum(remainderValue, values, prevValues);

                if(remainderResult != null)
                {
                    remainderResult.Add(num);
                    
                    prevValues[target] = remainderResult;

                    return remainderResult;
                }
            }

            prevValues[target] = null;
            return null;
        }

        public static List<int> BestSum(int target, int[] values, Hashtable prevValues = null)
        {
            if (prevValues is null)
                prevValues = new Hashtable();

            if (prevValues.ContainsKey(target))
                return (List<int>)prevValues[target];

            if (target == 0)
                return new List<int>() { };

            if (target < 0)
                return null;

            List<int> shortestRemainderResult = null;

            foreach (var num in values)
            {
                int remainderValue = target - num;
                List<int> remainderResult = BestSum(remainderValue, values, prevValues);

                if (remainderResult != null)
                {
                    remainderResult.Add(num);

                    prevValues[target] = remainderResult;

                    if(shortestRemainderResult is null || shortestRemainderResult.Count > remainderResult.Count)
                    {
                        shortestRemainderResult = remainderResult;
                    }

                    
                }
            }

            prevValues[target] = shortestRemainderResult;
            return shortestRemainderResult;
        }

        public static bool canConstruct(string target, string[] values, Hashtable prevValues = null)
        {
            if (prevValues is null)
                prevValues = new Hashtable();

            if (prevValues.ContainsKey(target))
                return Convert.ToBoolean(prevValues[target]);                 

            if (target is null || target == "")
                return true;

            foreach(var word in values)
            {
                if(target.IndexOf(word) == 0)
                {
                    var suffix = target.Substring(word.Length);
                    if(canConstruct(suffix, values, prevValues))
                    {
                        prevValues[target] = true;
                        return true;
                    }
                }
            }

            prevValues[target] = false;
            return false;
        }

        public static int countConstruct(string target, string[] values, Hashtable prevValues = null)
        {
            if (prevValues is null)
                prevValues = new Hashtable();

            if (prevValues.ContainsKey(target))
                return Convert.ToInt32(prevValues[target]);

            if (target is null || target == "")
                return 1;

            int totalCount = 0;

            foreach (var word in values)
            {
                if (target.IndexOf(word) == 0)
                {
                    var suffix = target.Substring(word.Length);
                    int numWays = countConstruct(suffix, values, prevValues);
                    totalCount += numWays;
                }
            }

            prevValues[target] = totalCount;
            return totalCount;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Fibonacci Sequence!");
            //Console.WriteLine(Fibonacci(50));

            //Console.WriteLine("Grid Sequence!");
            //Console.WriteLine(gridTraveller(18,18));

            //Console.WriteLine("Can Sum");
            //Console.WriteLine(CanSum(7, new int[] { 2, 3, 4 }));

            //Console.WriteLine("How Sum");
            //List<int> returnValues;

            //returnValues = HowSum(8, new int[] { 2, 3, 5 });

            //foreach (var v in returnValues)
            //{
            //    Console.WriteLine(v.ToString());
            //}

            //Console.WriteLine("Best Sum");
            //List<int> returnBestValues;

            //returnBestValues = BestSum(8, new int[] { 2, 3, 5 });

            //foreach (var v in returnValues)
            //{
            //    Console.WriteLine(v.ToString());
            //}

            //Console.WriteLine(canConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }));

            //Console.WriteLine(countConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef" }));

        }
    }
}
