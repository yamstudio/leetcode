/*
 * @lc app=leetcode id=1131 lang=java
 *
 * [1131] Maximum of Absolute Value Expression
 */

// @lc code=start
class Solution {
    private static int[] COEFF = new int[] { -1, 1 };
    
    public int maxAbsValExpr(int[] arr1, int[] arr2) {
        int ret = 0, n = arr1.length;
        for (int cx : COEFF) {
            for (int cy : COEFF) {
                int max = cx * arr1[0] + cy * arr2[0], min = max;
                for (int i = 1; i < n; ++i) {
                    int v = cx * arr1[i] + cy * arr2[i] + i;
                    max = Math.max(max, v);
                    min = Math.min(min, v);
                }
                ret = Math.max(ret, max - min);
            }
        }
        return ret;
    }
}
// @lc code=end

