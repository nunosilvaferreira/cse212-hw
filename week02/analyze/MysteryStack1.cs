using System;
using System.Collections.Generic;

public static class MysteryStack1
{
    // Reverse a string using a stack
    public static string Run(string text)
    {
        var stack = new Stack<char>();

        foreach (var letter in text)
            stack.Push(letter);

        var result = new System.Text.StringBuilder();
        while (stack.Count > 0)
            result.Append(stack.Pop());

        return result.ToString();
    }
}
