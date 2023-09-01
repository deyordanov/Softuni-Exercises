namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char symbol in s)
            {
                if (symbol == '(') { stack.Push(')'); continue; };
                if (symbol == '{') { stack.Push('}'); continue; };
                if (symbol == '[') { stack.Push(']'); continue; };
                if (stack.Count == 0 || symbol != stack.Pop()) { return false; };
            }
            return stack.Count == 0;
        }
    }
}
