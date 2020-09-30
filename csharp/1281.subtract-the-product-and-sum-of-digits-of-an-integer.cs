/*
 * @lc app=leetcode id=1281 lang=csharp
 *
 * [1281] Subtract the Product and Sum of Digits of an Integer
 */

// @lc code=start
public class Solution {
    public int SubtractProductAndSum(int n) {
        int p = 1, s = 0;
        while (n > 0) {
            int l = n % 10;
            p *= l;
            s += l;
            n /= 10;
        }
        return p - s;
    }
}
// @lc code=end

