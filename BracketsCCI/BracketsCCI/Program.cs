using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string expression = Console.ReadLine();
                if (isBalanced(expression))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        public static bool isBalanced(String expression)
        {

            // Must be even
            if ((expression.Length & 1) == 1)
                return false;
            else
            {
                char[] brackets = expression.ToCharArray();
                Stack<char> s = new Stack<char>();
                foreach (char bracket in brackets)
                {
                if ('{' == bracket)
                    s.Push('}');
                else if ('[' == bracket)
                    s.Push(']');
                else if ('(' == bracket)
                    s.Push(')');
                else
                    if (s.Count==0 || bracket != s.Peek())
                        return false;
                    s.Pop();
                }
            return s.Count == 0;
            }

        }
    }
