/*
 * @lc app=leetcode id=1759 lang=java
 *
 * [1759] Count Number of Homogenous Substrings
 */

// @lc code=start
class Solution {
    public int countHomogenous(String s) {
        int n = s.length();
        long ret = 0;
        for (int i = 0; i < n;) {
            int ni = i + 1;
            char c = s.charAt(i);
            while (ni < n && s.charAt(ni) == c) {
                ++ni;
            }
            long l = ni - i;
            ret = (ret + ((1 + (long)l) * l / 2)) % 1000000007;
            i = ni;
        }
        return (int)ret;
    }
}
// @lc code=end

