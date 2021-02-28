/*
 * @lc app=leetcode id=899 lang=java
 *
 * [899] Orderly Queue
 */

// @lc code=start
class Solution {
    public String orderlyQueue(String S, int K) {
        if (K > 1) {
            char[] chars = S.toCharArray();
            Arrays.sort(chars);
            return new String(chars);
        }
        int n = S.length();
        String ret = S;
        for (int i = 1; i < n; ++i) {
            String curr = String.format("%s%s", S.substring(i), S.substring(0, i));
            if (curr.compareTo(ret) < 0) {
                ret = curr;
            }
        }
        return ret;
    }
}
// @lc code=end

