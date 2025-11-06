using System;
using System.Collections.Generic;

public static class MysteryStack2
{
    // Evaluates expressions in Reverse Polish Notation (postfix)
    public static float Run(string text)
    {
        var stack = new Stack<float>();

        foreach (var token in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (float.TryParse(token, out float number))
            {
                stack.Push(number);
            }
            else if (token is "+" or "-" or "*" or "/")
            {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();

                float res = token switch
                {
                    "+" => op1 + op2,
                    "-" => op1 - op2,
                    "*" => op1 * op2,
                    "/" when op2 == 0 => throw new ApplicationException("Invalid Case 2!"),
                    "/" => op1 / op2,
                    _ => throw new ApplicationException("Invalid Case 3!")
                };

                stack.Push(res);
            }
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}
