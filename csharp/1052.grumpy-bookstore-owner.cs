/*
 * @lc app=leetcode id=1052 lang=csharp
 *
 * [1052] Grumpy Bookstore Owner
 */

// @lc code=start
public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int X) {
        int n = customers.Length, ret = 0, acc = 0, macc = 0;
        for (int i = 0; i < n; ++i) {
            if (grumpy[i] == 0) {
                ret += customers[i];
            } else {
                acc += customers[i];
            }
            if (i >= X && grumpy[i - X] == 1) {
                acc -= customers[i - X];
            }
            if (acc > macc) {
                macc = acc;
            }
        }
        return ret + macc;
    }
}
// @lc code=end

