/*
 * @lc app=leetcode id=1819 lang=java
 *
 * [1819] Number of Different Subsequences GCDs
 */

// @lc code=start
class Solution {
    public int countDifferentSubsequenceGCDs(int[] nums) {
        int[] gcd = new int[200001];
        int n = nums.length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int v = nums[i];
            for (int f = 1; f * f <= v; ++f) {
                if (v % f != 0) {
                    continue;
                }
                int d = v / f;
                gcd[f] = gcd(v, gcd[f]);
                gcd[d] = gcd(v, gcd[d]);
            }
        }
        for (int i = 1; i <= 200000; ++i) {
            if (gcd[i] == i) {
                ++ret;
            }
        }
        return ret;
    }

    private static int gcd(int x, int y) {
        return y == 0 ? x : gcd(y, x % y);
    }
}
// @lc code=end

