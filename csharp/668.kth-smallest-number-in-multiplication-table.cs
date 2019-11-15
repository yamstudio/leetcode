/*
 * @lc app=leetcode id=668 lang=csharp
 *
 * [668] Kth Smallest Number in Multiplication Table
 */

// @lc code=start
public class Solution {
    public int FindKthNumber(int m, int n, int k) {
        int left = 1, right = m * n;
        while (left < right) {
            int count = 0, mid = (left + right) / 2;
            for (int i = 1; i <= m; ++i) {
                count += Math.Min(n, mid / i);
            }
            if (count < k) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return right;
    }
}
// @lc code=end

