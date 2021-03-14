/*
 * @lc app=leetcode id=917 lang=java
 *
 * [917] Reverse Only Letters
 */

// @lc code=start
class Solution {
    public String reverseOnlyLetters(String S) {
        char[] array = S.toCharArray();
        int l = 0, r = S.length() - 1;
        while (l < r) {
            if (!Character.isLetter(array[l])) {
                ++l;
            } else if (!Character.isLetter(array[r])) {
                --r;
            } else {
                char t = array[l];
                array[l++] = array[r];
                array[r--] = t;
            }
        }
        return new String(array);
    }
}
// @lc code=end

