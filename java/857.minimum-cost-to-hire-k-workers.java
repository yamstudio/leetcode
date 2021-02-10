/*
 * @lc app=leetcode id=857 lang=java
 *
 * [857] Minimum Cost to Hire K Workers
 */

// @lc code=start
class Solution {
    public double mincostToHireWorkers(int[] quality, int[] wage, int K) {
        int n = wage.length;
        double ret = Double.MAX_VALUE, sum = 0;
        double[][] all = new double[n][];
        Comparator<double[]> comparator = (t1, t2) -> t1[0] == t2[0] ? Double.compare(t1[1], t2[1]) : Double.compare(t1[0], t2[0]);
        Queue<Double> queue = new PriorityQueue<Double>((q1, q2) -> Double.compare(q2, q1));
        for (int i = 0; i < n; ++i) {
            all[i] = new double[] { (double)wage[i] / (double)quality[i], (double)quality[i] };
        }
        Arrays.sort(all, comparator);
        for (double[] curr : all) {
            sum += curr[1];
            queue.offer(curr[1]);
            if (queue.size() > K) {
                sum -= queue.poll();
            }
            if (queue.size() == K) {
                ret = Math.min(ret, sum * curr[0]);
            }
        }
        return ret;
    }
}
// @lc code=end

