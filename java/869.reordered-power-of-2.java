/*
 * @lc app=leetcode id=869 lang=java
 *
 * [869] Reordered Power of 2
 */

// @lc code=start
class Solution {

    private static int[] count(int n) {
        int[] ret = new int[10];
        while (n != 0) {
            ret[n % 10]++;
            n /= 10;
        }
        return ret;
    }

    public boolean reorderedPowerOf2(int N) {
        int[] nCount= count(N);
        for (int i = 0; i < 31; ++i) {
            int[] tCount = count(1 << i);
            boolean flag = true;
            for (int j = 0; j < 10 && flag; ++j) {
                if (tCount[j] != nCount[j]) {
                    flag = false;
                }
            }
            if (flag) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

