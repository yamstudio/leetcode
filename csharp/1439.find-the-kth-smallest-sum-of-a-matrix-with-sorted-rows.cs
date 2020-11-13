/*
 * @lc app=leetcode id=1439 lang=csharp
 *
 * [1439] Find the Kth Smallest Sum of a Matrix With Sorted Rows
 */

// @lc code=start
public class Solution {

    private static void Count(int[][] mat, int m, int n, int sum, int target, int row, int k, ref int count) {
        if (sum > target) {
            return;
        }
        if (row == m) {
            ++count;
            return;
        }
        for (int i = 0; i < n && count < k; ++i) {
            int oldCount = count;
            Count(mat, m, n, sum + mat[row][i], target, row + 1, k, ref count);
            if (oldCount == count) {
                break;
            }
        }
    }

    public int KthSmallest(int[][] mat, int k) {
        int m = mat.Length, n = mat[0].Length, l = 0, r = m * 5000, ret = -1;
        while (l <= r) {
            int mid = (l + r) / 2, count = 0;
            Count(mat, m, n, 0, mid, 0, k, ref count);
            if (count < k) {
                l = mid + 1;
            } else {
                ret = mid;
                r = mid - 1;
            }
        }
        return ret;
    }
}
// @lc code=end

