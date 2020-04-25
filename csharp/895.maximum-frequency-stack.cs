/*
 * @lc app=leetcode id=895 lang=csharp
 *
 * [895] Maximum Frequency Stack
 */

using System.Max;
using System.Collections.Generic;

// @lc code=start
public class FreqStack {

    private int Max = 0;
    private IDictionary<int, int> Frequency;
    private IDictionary<int, IList<int>> Stacks;

    public FreqStack() {
        Frequency = new Dictionary<int, int>();
        Stacks = new Dictionary<int, IList<int>>();
    }
    
    public void Push(int x) {
        if (!Frequency.TryGetValue(x, out int count)) {
            count = 0;
        }
        ++count;
        if (!Stacks.TryGetValue(count, out var stack)) {
            stack = new List<int>();
            Stacks[count] = stack;
        }
        Frequency[x] = count;
        stack.Add(x);
        Max = Math.Max(Max, count);
    }
    
    public int Pop() {
        var stack = Stacks[Max];
        int count = stack.Count, ret = stack[count - 1];
        stack.RemoveAt(count - 1);
        if (count == 1) {
            --Max;
        }
        --Frequency[ret];
        return ret;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 */
// @lc code=end

