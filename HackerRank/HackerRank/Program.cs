using System;
using System.Numerics;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
namespace HackerRank
{
    class Program
    {
        /*
        static BigInteger extraLongFactorials(BigInteger n)
        {
            // Complete this function
            if (n <= 1)
            {
                return 1;
            }
            else
                return extraLongFactorials(n - 1) * n; ;
        }


        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger bigInt = Convert.ToInt64(n);
            BigInteger bigSol = extraLongFactorials(bigInt);
            Console.WriteLine(bigSol);
            Console.ReadLine();
        }
        */


        static int nonDivisibleSubset(int k, int[] arr)
        {
            //get all combinations
            List<int> numSet = new List<int>();
            IEnumerable<IEnumerable<int>> result = GetKCombs(arr, 2);
            int comSet = 0;
            int firstNum = 0;
            int secondNum = 0;
            int counter = 0;
            foreach (var item in result)
            {
                foreach (int x in item)
                {
                    if(counter ==0)
                    {
                        firstNum = x;
                        counter++;
                    }
                    else
                    {
                        secondNum = x;
                    }
                    comSet += x;
                }

                //make sure it is not divis by the by k
                if(comSet%k!=0)
                {
                    Console.WriteLine("Sum is not Divis with " + firstNum + "," + secondNum + "Sum = " + comSet);
                    if (!numSet.Contains(firstNum))
                        numSet.Add(firstNum);
                    else if (!numSet.Contains(secondNum))
                        numSet.Add(secondNum);
                }
                counter = 0;
                comSet = 0;
            }
            


            return numSet.Count;
        }
        //find all combinations 

        static void Main(String[] args)
        {
            //string[] tokens_n = Console.ReadLine().Split(' ');
            int n = 4;// Convert.ToInt32(tokens_n[0]);
            int k = 4;// Convert.ToInt32(tokens_n[1]);
            //string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr  = { 1,7,2,4,5,2,6,10 };//Array.ConvertAll(arr_temp, Int32.Parse);
            int result = nonDivisibleSubset(k, arr);
            Console.WriteLine(result);
            Console.Write(" ");
        }
    

        static IEnumerable<IEnumerable<T>>
        GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
