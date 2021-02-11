/*
 * @lc app=leetcode id=859 lang=java
 *
 * [859] Buddy Strings
 */

// @lc code=start
class Solution {
    public boolean buddyStrings(String A, String B) {
        int f = -1, s = -1, n = A.length(), mask = 0;
        boolean hasMultiple = false;
        if (n != B.length()) {
            return false;
        }
        for (int i = 0; i < n; ++i) {
            if (A.charAt(i) == B.charAt(i)) {
                if (((1 << ((int)A.charAt(i) - (int)'a')) & mask) != 0) {
                    hasMultiple = true;
                }
                mask |= 1 << ((int)A.charAt(i) - (int)'a');
                continue;
            }
            if (f < 0) {
                f = i;
            } else if (s < 0) {
                s = i;
            } else {
                return false;
            }
        }
        return f >= 0 && s >= 0 && A.charAt(f) == B.charAt(s) && A.charAt(s) == B.charAt(f) || f < 0 && s < 0 && hasMultiple;
    }
}
// @lc code=end

