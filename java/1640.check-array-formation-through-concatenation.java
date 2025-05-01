/*
 * @lc app=leetcode id=1640 lang=java
 *
 * [1640] Check Array Formation Through Concatenation
 */

// @lc code=start
class Solution {
    public boolean canFormArray(int[] arr, int[][] pieces) {
        int[][] segs = new int[101][];
        for (int[] p : pieces) {
            segs[p[0]] = p;
        }
        int n = arr.length;
        for (int i = 0; i < n; ++i) {
            int[] p = segs[arr[i]];
            if (p == null) {
                return false;
            }
            int k = p.length;
            for (int j = 0; j < k; ++j) {
                if (p[j] != arr[i + j]) {
                    return false;
                }
            }
            i += k - 1;
        }
        return true;
    }
}
// @lc code=end

