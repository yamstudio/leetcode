/*
 * @lc app=leetcode id=150 lang=csharp
 *
 * [150] Evaluate Reverse Polish Notation
 */

using System;
using System.Collections.Generic;

public static class Ext {
    public static void PopAndApply<T>(this IList<T> list, Func<T, T, T> func)
    {
        T a = list[list.Count - 2], b = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        list.RemoveAt(list.Count - 1);
        list.Add(func(a, b));
    }
}

public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new List<int>();
        foreach (string token in tokens) {
            switch (token) {
                case "-":
                    stack.PopAndApply((a, b) => a - b);
                    break;
                case "+":
                    stack.PopAndApply((a, b) => a + b);
                    break;
                case "/":
                    stack.PopAndApply((a, b) => a / b);
                    break;
                case "*":
                    stack.PopAndApply((a, b) => a * b);
                    break;
                default:
                    stack.Add(int.Parse(token));
                    break;
            }
        }
        return stack[0];
    }
}

