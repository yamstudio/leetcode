/*
 * @lc app=leetcode id=1832 lang=java
 *
 * [1832] Check if the Sentence Is Pangram
 */

// @lc code=start
class Solution {
    public boolean checkIfPangram(String sentence) {
        int n = sentence.length(), acc = 0;
        for (int i = 0; i < n; ++i) {
            acc |= 1 << (sentence.charAt(i) - 'a');
        }
        return acc == 0b11111111111111111111111111;
    }
}
// @lc code=end

