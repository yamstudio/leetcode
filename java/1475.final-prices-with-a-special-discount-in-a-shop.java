/*
 * @lc app=leetcode id=1475 lang=java
 *
 * [1475] Final Prices With a Special Discount in a Shop
 */

import java.util.Stack;

// @lc code=start
class Solution {
    public int[] finalPrices(int[] prices) {
        Stack<Integer> stack = new Stack<>();
        int n = prices.length;
        stack.push(0);
        for (int i = n - 1; i >= 0; --i) {
            int p = prices[i];
            while (p < stack.peek()) {
                stack.pop();
            }
            prices[i] -= stack.peek();
            stack.push(p);
        }
        return prices;
    }
}
// @lc code=end

