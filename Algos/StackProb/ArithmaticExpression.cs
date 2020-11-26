using System;
using System.Collections.Generic;

namespace Algos.StackProb
{
    public static class ArithmaticExpression
    {
        public static void Test()
        {
            UnitTest("5+2", 7);
            UnitTest("5+2*2", 9);
            UnitTest("5*2*2", 20);
            UnitTest("5*2/2+2", 7);
            UnitTest("50*20/20+20", 70);

            UnitTest_PostFix("5 2 +", 7);
            UnitTest_PostFix("50 20 * 20 / 20 +", 70);
        }

        private static void UnitTest(string expr, int result)
        {
            int expected = EvaluateInfix(expr);
            Console.WriteLine($"{expected == result}, {expr} = {expected}");
        }

        private static bool IsOperator(char valOp)
        {
            return valOp == '*' || valOp == '/' || valOp == '+' || valOp == '-';
        }

        private static string ApplyOperator(string num1, Stack<string> stack, char op)
        {
            int p1 = int.Parse(num1);
            int p2 = int.Parse(stack.Pop());
            if (op == '*')
            {
                return $"{p1 * p2}";
            }
            else if (op == '/')
            {
                return $"{p2 / p1}";
            }
            else if (op == '+')
            {
                return $"{p1 + p2}";
            }
            else if (op == '-')
            {
                return $"{p1 - p2}";
            }
            throw new Exception("Invalid op");
        }

        public static int EvaluateInfix(string expr)
        {
            var stack = new Stack<string>();
            string prevNumber = "";
            char lastOperator = '\0';
            for (int i = 0; i < expr.Length; i++)
            {

                if (char.IsNumber(expr[i]))
                {
                    prevNumber += expr[i];
                }

                if (!char.IsNumber(expr[i]) || i == expr.Length - 1)
                {
                    if (lastOperator == '*' || lastOperator == '/')
                    {
                        prevNumber = ApplyOperator(prevNumber, stack, lastOperator);
                    }

                    stack.Push(prevNumber);
                    prevNumber = string.Empty;
                    lastOperator = expr[i];

                    if (lastOperator == '+' || lastOperator == '-')
                    {
                        stack.Push(expr[i].ToString());
                    }
                }
            }

            while (stack.Count != 0)
            {
                if (stack.Peek() == "+" || stack.Peek() == "-")
                {
                    prevNumber = ApplyOperator(prevNumber, stack, stack.Pop()[0]);
                }
                else
                {
                    prevNumber = stack.Pop();
                }
            }
            return int.Parse(prevNumber);
        }


        private static void UnitTest_PostFix(string expr, int result)
        {
            int expected = EvaluatePostfix(expr);
            Console.WriteLine($"{expected == result}, {expr} = {expected}");
        }

        public static int EvaluatePostfix(string expr)
        {
            var arrExpr = expr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>();
            for (int i = 0; i < arrExpr.Length; i++)
            {
                if (IsOperator(arrExpr[i][0]))
                {
                    var prevNumber = ApplyOperator(stack.Pop(), stack, arrExpr[i][0]);
                    stack.Push(prevNumber);
                }
                else
                {
                    stack.Push(arrExpr[i]);
                }                
            }

            return int.Parse(stack.Pop());
        }
    }
}
