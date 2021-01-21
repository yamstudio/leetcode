/*
 * @lc app=leetcode id=796 lang=java
 *
 * [796] Rotate String
 */

// @lc code=start
class Solution {
    public boolean rotateString(String A, String B) {
        return A.length() == B.length() && (B + B).contains(A);
    }
}
// @lc code=end

