/*
 * @lc app=leetcode id=1010 lang=java
 *
 * [1010] Pairs of Songs With Total Durations Divisible by 60
 */

// @lc code=start
class Solution {
    public int numPairsDivisibleBy60(int[] time) {
        int[] count = new int[60];
        int ret = 0;
        for (int t : time) {
            int i = t % 60;
            ret += count[(60 - i) % 60];
            count[i]++;
        }
        return ret;
    }
}
// @lc code=end

