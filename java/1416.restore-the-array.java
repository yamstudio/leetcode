/*
 * @lc app=leetcode id=1416 lang=java
 *
 * [1416] Restore The Array
 */

// @lc code=start
class Solution {
    public int numberOfArrays(String s, int k) {
        int n = s.length();
        int[] memo = new int[n];
        for (int i = 0; i < n; ++i) {
            memo[i] = -1;
        }
        return numberOfArrays(s, 0, k, memo);
    }

    private static int numberOfArrays(String s, int i, int k, int[] memo) {
        int n = s.length();
        if (i >= n) {
            return 1;
        }
        if (s.charAt(i) == '0') {
            return 0;
        }
        int ret = memo[i];
        if (ret >= 0) {
            return ret;
        }
        ret = 0;
        long acc = 0;
        for (int j = i; j < n; ++j) {
            acc = acc * 10 + (s.charAt(j) - '0');
            if (acc > k) {
                break;
            }
            ret = (ret + numberOfArrays(s, j + 1, k, memo)) % 1000000007;
        }
        memo[i] = ret;
        return ret;
    }
}
// @lc code=end

