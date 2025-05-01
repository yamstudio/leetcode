/*
 * @lc app=leetcode id=1639 lang=java
 *
 * [1639] Number of Ways to Form a Target String Given a Dictionary
 */

// @lc code=start
class Solution {
    public int numWays(String[] words, String target) {
        int n = words[0].length();
        int[][] count = new int[26][n];
        for (String w : words) {
            for (int i = 0; i < n; ++i) { 
                ++count[w.charAt(i) - 'a'][i];
            }
        }
        return numWays(target, 0, 0, count, new Integer[n][n]);
    }

    private static int numWays(String target, int ti, int wi, int[][] count, Integer[][] memo) {
        if (ti == target.length()) {
            return 1;
        }
        if (wi == count[0].length) {
            return 0;
        }
        Integer m = memo[ti][wi];
        if (m != null) {
            return m;
        }
        int ret = numWays(target, ti, wi + 1, count, memo), c = count[target.charAt(ti) - 'a'][wi];
        if (c > 0) {
            ret = (int)(((long)ret + (long)(((long)c * (long)numWays(target, 1 + ti, 1 + wi, count, memo)) % 1000000007)) % 1000000007);
        }
        memo[ti][wi] = ret;
        return ret;
    }
}
// @lc code=end

