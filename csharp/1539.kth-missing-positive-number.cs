/*
 * @lc app=leetcode id=1539 lang=csharp
 *
 * [1539] Kth Missing Positive Number
 */

// @lc code=start
public class Solution {
    public int FindKthPositive(int[] arr, int k) {
        int p = 0;
        foreach (int x in arr) {
            if (x - p - 1 >= k) {
                break;
            }
            k -= x - p - 1;
            p = x;
        }
        return p + k;
    }
}
// @lc code=end

