/*
 * @lc app=leetcode id=1824 lang=java
 *
 * [1824] Minimum Sideway Jumps
 */

// @lc code=start
class Solution {
    public int minSideJumps(int[] obstacles) {
        int[] minJumps = new int[] {1, 0, 1};
        for (int b : obstacles) {
            if (b > 0) {
                minJumps[b - 1] = 600000;
            }
            for (int lane = 0; lane < 3; ++lane) {
                if (lane == b - 1) {
                    continue;
                }
                minJumps[lane] = Math.min(
                    minJumps[lane],
                    1 + Math.min(minJumps[(1 + lane) % 3], minJumps[(2 + lane) % 3])
                );
            }
        }
        return Math.min(
            minJumps[0],
            Math.min(minJumps[1], minJumps[2])
        );
    }
}
// @lc code=end

