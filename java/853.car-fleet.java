/*
 * @lc app=leetcode id=853 lang=java
 *
 * [853] Car Fleet
 */

// @lc code=start
class Solution {
    public int carFleet(int target, int[] position, int[] speed) {
        int n = position.length, ret = 0;
        double[][] sorted = new double[n][];
        double time = 0;
        for (int i = 0; i < n; ++i) {
            sorted[i] = new double[] { (double)position[i], (double)(target - position[i]) / (double)speed[i] };
        }
        Arrays.sort(sorted, (t1, t2) -> Double.compare(t2[0], t1[0]));
        for (double[] t : sorted) {
            if (time < t[1]) {
                time = t[1];
                ret++;
            }
        }
        return ret;
    }
}
// @lc code=end

