/*
 * @lc app=leetcode id=1475 lang=csharp
 *
 * [1475] Final Prices With a Special Discount in a Shop
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] FinalPrices(int[] prices) {
        int n = prices.Length;
        int[] ret = new int[n];
        var stack = new Stack<int>();
        for (int i = 0; i < n; ++i) {
            int price = prices[i];
            ret[i] = price;
            while (stack.TryPeek(out var j) && prices[j] >= price) {
                ret[j] -= price;
                stack.Pop();
            }
            stack.Push(i);
        }
        return ret;
    }
}
// @lc code=end

