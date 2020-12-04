/*
 * @lc app=leetcode id=1526 lang=csharp
 *
 * [1526] Minimum Number of Increments on Subarrays to Form a Target Array
 */

// @lc code=start
public class Solution {
    public int MinNumberOperations(int[] target) {
        int ret = 0, p = 0;
        foreach (int x in target) {
            if (x > p) {
                ret += x - p;
            }
            p = x;
        }
        return ret;
    }
}
// @lc code=end

