using System;
using System.Collections.Generic;

namespace Algos.StackProb
{
    public static class ArithmaticExpression
    {
        public static void Test()
        {
            UnitTest("5 + 2", 7);
            UnitTest("5 + 2 * 2", 9);
            UnitTest("5 * 2 + 2", 12);
            UnitTest("5 * 2 * 2", 20);
            UnitTest("5 * 2 / 2 + 2", 7);
            UnitTest("50 * 20 / 20 + 20", 70);

            UnitTest_PostFix("5 2 +", 7);
            UnitTest_PostFix("50 20 * 20 / 20 +", 70);
        }

        private static void UnitTest(string expr, int result)
        {
            int expected = EvaluateInfix_Precedence(expr);
            Console.WriteLine($"{expected == result}, {expr} = {expected}");
        }

        private static bool IsOperator(char valOp)
        {
            return valOp == '*' || valOp == '/' || valOp == '+' || valOp == '-';
        }        

        private static string ApplyOperator(string num1, string num2, string op)
        {
            int p1 = int.Parse(num1);
            int p2 = int.Parse(num2);
            if (op == "*")
            {
                return $"{p1 * p2}";
            }
            else if (op == "/")
            {
                return $"{p2 / p1}";
            }
            else if (op == "+")
            {
                return $"{p1 + p2}";
            }
            else if (op == "-")
            {
                return $"{p1 - p2}";
            }
            throw new Exception("Invalid op");
        }

        private static int GetOpPrecedence(string op)
        {
            if (op[0] == '*')
            {
                return 3;
            }
            else if (op[0] == '/')
            {
                return 2;
            }
            else if (op[0] == '+')
            {
                return 1;
            }
            else if (op[0] == '-')
            {
                return 0;
            }
            throw new Exception("Invalid op");
        }

        public static int EvaluateInfix_Precedence(string expr)
        {
            var arrExpr = expr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var opStack = new Stack<string>();
            var stack = new Stack<string>();
            for (int i = 0; i < arrExpr.Length; i++)
            {
                if (arrExpr[i] == "(")
                {
                    opStack.Push("(");
                }
                else if (arrExpr[i] == ")")
                {
                    while (opStack.Peek() != "(")
                    {
                        var value = ApplyOperator(stack.Pop(), stack.Pop(), opStack.Pop());
                        stack.Push(value);
                    }
                    stack.Pop(); //flush the "(" from stack
                }
                else if (IsOperator(arrExpr[i][0]))
                {
                    while (opStack.Count > 0 && GetOpPrecedence(arrExpr[i]) < GetOpPrecedence(opStack.Peek()))
                    {
                        var value = ApplyOperator(stack.Pop(), stack.Pop(), opStack.Pop());
                        stack.Push(value);
                    }

                    opStack.Push(arrExpr[i]);
                }
                else
                {
                    stack.Push(arrExpr[i]);
                }
            }

            while (opStack.Count > 0)
            {
                var value = ApplyOperator(stack.Pop(), stack.Pop(), opStack.Pop());
                stack.Push(value);
            }
            return int.Parse(stack.Pop());
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
                    var prevNumber = ApplyOperator(stack.Pop(), stack.Pop(), arrExpr[i]);
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
