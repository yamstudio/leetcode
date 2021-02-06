/*
 * @lc app=leetcode id=848 lang=java
 *
 * [848] Shifting Letters
 */

// @lc code=start
class Solution {
    public String shiftingLetters(String S, int[] shifts) {
        int n = shifts.length, acc = 0;
        char[] ret = new char[n];
        for (int i = n - 1; i >= 0; --i) {
            acc = (shifts[i] + acc) % 26;
            ret[i] = (char)((int)'a' + (((int)S.charAt(i) - (int)'a' + acc) % 26));
        }
        return new String(ret);
    }
}
// @lc code=end

