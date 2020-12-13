/*
 * @lc app=leetcode id=1566 lang=csharp
 *
 * [1566] Detect Pattern of Length M Repeated K or More Times
 */

// @lc code=start
public class Solution {
    public bool ContainsPattern(int[] arr, int m, int k) {
        int acc = 0, n = arr.Length;
        for (int i = 0; i + m < n; ++i) {
            if (arr[i] == arr[i + m]) {
                if (++acc == m * (k - 1)) {
                    return true;
                }
            } else {
                acc = 0;
            }
        }
        return false;
    }
}
// @lc code=end

