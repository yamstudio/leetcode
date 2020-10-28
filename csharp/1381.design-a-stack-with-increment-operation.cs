/*
 * @lc app=leetcode id=1381 lang=csharp
 *
 * [1381] Design a Stack With Increment Operation
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class CustomStack {

    private Stack<int> Stack;
    private int[] Increments;
    private int Index;

    public CustomStack(int maxSize) {
        Stack = new Stack<int>(maxSize);
        Increments = new int[maxSize];
        Index = -1;
    }
    
    public void Push(int x) {
        if (Index == Increments.Length - 1) {
            return;
        }
        Stack.Push(x);
        ++Index;
    }
    
    public int Pop() {
        if (!Stack.TryPop(out int ret)) {
            return -1;
        }
        ret += Increments[Index--];
        if (Index >= 0) {
            Increments[Index] += Increments[Index + 1];
        }
        Increments[Index + 1] = 0;
        return ret;
    }
    
    public void Increment(int k, int val) {
        int i = Math.Min(k, Stack.Count) - 1;
        if (i >= 0) {
            Increments[i] += val;
        }
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */
// @lc code=end

