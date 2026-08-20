/*
 * @lc app=leetcode id=1792 lang=java
 *
 * [1792] Maximum Average Pass Ratio
 */

import java.util.Queue;
import java.util.PriorityQueue;

// @lc code=start
import static java.util.Comparator.comparingDouble;

class Solution {
    public double maxAverageRatio(int[][] classes, int extraStudents) {
        int n = classes.length;
        Queue<Element> queue = new PriorityQueue<>(n, comparingDouble(Element::inc).reversed());
        for (int[] c : classes) {
            queue.offer(Element.fromClass(c[0], c[1]));
        }
        while (extraStudents-- > 0) {
            Element e = queue.poll();
            queue.offer(Element.fromClass(e.p() + 1, e.t() + 1));
        }
        double ret = 0;
        while (!queue.isEmpty()) {
            Element e = queue.poll();
            ret += (double)e.p() / (double)e.t();
        }
        return ret / n;
    }

    private record Element(int p, int t, double inc) {
        private static Element fromClass(int p, int t) {
            return new Element(p, t, (double)(p + 1) / (double)(t + 1) - (double)p / (double)t);
        }
    }
}
// @lc code=end

