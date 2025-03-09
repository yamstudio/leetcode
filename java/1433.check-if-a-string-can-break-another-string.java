/*
 * @lc app=leetcode id=1433 lang=java
 *
 * [1433] Check If a String Can Break Another String
 */

// @lc code=start
class Solution {
    public boolean checkIfCanBreak(String s1, String s2) {
        int n = s1.length();
        int[] acc = new int[26];
        for (int i = 0; i < n; ++i) {
            ++acc[s1.charAt(i) - 'a'];
            --acc[s2.charAt(i) - 'a'];
        }
        int a = 0;
        boolean allPos = true, allNeg = true;
        for (int i = 0; i < 26; ++i) {
            a += acc[i];
            if (a > 0) {
                allNeg = false;
            } else if (a < 0) {
                allPos = false;
            }
        }
        return allNeg || allPos;
    }
}
// @lc code=end

