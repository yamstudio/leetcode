/*
 * @lc app=leetcode id=1337 lang=java
 *
 * [1337] The K Weakest Rows in a Matrix
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start
class Solution {
    public int[] kWeakestRows(int[][] mat, int k) {
        int m = mat.length, n = mat[0].length;
        Queue<Pair> queue = new PriorityQueue<>(m);
        for (int i = 0; i < m; ++i) {
            int j;
            for (j = 0; j < n && mat[i][j] == 1; ++j);
            queue.offer(new Pair(i + m * j, i));
        }
        int[] ret = new int[k];
        for (int i = 0; i < k; ++i) {
            ret[i] = queue.poll().i();
        }
        return ret;
    }

    private record Pair(int strength, int i) implements Comparable<Pair> {
        @Override
        public int compareTo(Pair other) {
            return strength - other.strength;
        }
        
    }
}
// @lc code=end

