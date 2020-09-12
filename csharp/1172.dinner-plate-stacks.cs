/*
 * @lc app=leetcode id=1172 lang=csharp
 *
 * [1172] Dinner Plate Stacks
 */

using System.Collections.Generic;

// @lc code=start
public class DinnerPlates {

    private IList<Stack<int>> Stacks;
    private SortedSet<int> Spaces;
    private int Capacity;

    public DinnerPlates(int capacity) {
        Stacks = new List<Stack<int>>();
        Spaces = new SortedSet<int>();
        Capacity = capacity;
    }
    
    public void Push(int val) {
        Stack<int> stack;
        if (Spaces.Count == 0) {
            stack = new Stack<int>(Capacity);
            stack.Push(val);
            Stacks.Add(stack);
            if (Capacity != 1) {
                Spaces.Add(Stacks.Count - 1);
            }
            return;
        }
        int index = Spaces.Min;
        stack = Stacks[index];
        stack.Push(val);
        if (stack.Count == Capacity) {
            Spaces.Remove(index);
        }
    }
    
    public int Pop() {
        return PopAtStack(Stacks.Count - 1);
    }
    
    public int PopAtStack(int index) {
        if (index < 0 || index >= Stacks.Count) {
            return -1;
        }
        if (!Stacks[index].TryPop(out int ret)) {
            return -1;
        }
        if (Stacks[index].Count == Capacity - 1) {
            Spaces.Add(index);
        }
        while (Stacks.Count > 0 && Stacks[Stacks.Count - 1].Count == 0) {
            Spaces.Remove(Stacks.Count - 1);
            Stacks.RemoveAt(Stacks.Count - 1);
        }
        return ret;
    }
}

/**
 * Your DinnerPlates object will be instantiated and called as such:
 * DinnerPlates obj = new DinnerPlates(capacity);
 * obj.Push(val);
 * int param_2 = obj.Pop();
 * int param_3 = obj.PopAtStack(index);
 */
// @lc code=end

