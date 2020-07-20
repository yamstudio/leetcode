/*
 * @lc app=leetcode id=946 lang=csharp
 *
 * [946] Validate Stack Sequences
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        var stack = new Stack<int>();
        int i = 0;
        foreach (int num in pushed) {
            stack.Push(num);
            while (stack.TryPeek(out int top) && top == popped[i]) {
                stack.Pop();
                ++i;
            }
        }
        return stack.Count == 0;
    }
}
// @lc code=end

