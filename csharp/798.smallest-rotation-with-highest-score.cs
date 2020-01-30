/*
 * @lc app=leetcode id=798 lang=csharp
 *
 * [798] Smallest Rotation with Highest Score
 */

// @lc code=start
public class Solution {
    public int BestRotation(int[] A) {
        int ret = 0, n = A.Length;
        int[] shift = new int[n];
        for (int i = 0; i < n; ++i) {
            --shift[(i - A[i] + n + 1) % n];
        }
        for (int i = 1; i < n; ++i) {
            shift[i] += 1 + shift[i - 1];
            if (shift[i] > shift[ret]) {
                ret = i;
            }
        }
        return ret;
    }
}
// @lc code=end

