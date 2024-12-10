/*
 * @lc app=leetcode id=1003 lang=java
 *
 * [1003] Check If Word Is Valid After Substitutions
 */

import java.util.Stack;

// @lc code=start
class Solution {
    public boolean isValid(String s) {
        Stack<Boolean> isA = new Stack<>();
        int l = s.length(), aCount = 0;
        for (int i = 0; i < l; ++i) {
            int c = s.charAt(i);
            if (c == 'a') {
                isA.push(true);
                ++aCount;
                continue;
            }
            if (c == 'b') {
                isA.push(false);
                if (isA.size() > 2 * aCount) {
                    return false;
                }
                continue;
            }
            if (isA.size() < 2) {
                return false;
            }
            if (isA.pop()) {
                return false;
            }
            if (!isA.pop()) {
                return false;
            }
            --aCount;
        }
        return isA.empty();
    }
}
// @lc code=end

