/*
 * @lc app=leetcode id=1502 lang=java
 *
 * [1502] Can Make Arithmetic Progression From Sequence
 */

// @lc code=start
class Solution {
    public boolean canMakeArithmeticProgression(int[] arr) {
        int n = arr.length, min = Integer.MAX_VALUE, max = Integer.MIN_VALUE;
        boolean[] okay = new boolean[n];
        for (int x : arr) {
            min = Math.min(min, x);
            max = Math.max(max, x);
        }
        int d = max - min;
        if (d % (n - 1) != 0) {
            return false;
        }
        d /= n - 1;
        for (int x : arr) {
            if (d == 0) {
                if (x != min) {
                    return false;
                }
                continue;
            }
            int i = x - min;
            if (i % d != 0) {
                return false;
            }
            i /= d;
            if (i >= n || okay[i]) {
                return false;
            }
            okay[i] = true;
        }
        return true;
    }
}
// @lc code=end

