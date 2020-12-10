/*
 * @lc app=leetcode id=1550 lang=csharp
 *
 * [1550] Three Consecutive Odds
 */

// @lc code=start
public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int n = arr.Length;
        for (int i = 0; i + 2 < n; ++i) {
            if (arr[i] % 2 == 1 && arr[i + 1] % 2 == 1 && arr[i + 2] % 2 == 1) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

