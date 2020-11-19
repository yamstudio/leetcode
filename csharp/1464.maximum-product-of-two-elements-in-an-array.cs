/*
 * @lc app=leetcode id=1464 lang=csharp
 *
 * [1464] Maximum Product of Two Elements in an Array
 */

// @lc code=start
public class Solution {
    public int MaxProduct(int[] nums) {
        int f = 0, s = 0;
        foreach (int x in nums) {
            if (x >= f) {
                s = f;
                f = x;
            } else if (x > s) {
                s = x;
            }
        }
        return (f - 1) * (s - 1);
    }
}
// @lc code=end

