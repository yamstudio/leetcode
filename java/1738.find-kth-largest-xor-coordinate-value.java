/*
 * @lc app=leetcode id=1738 lang=java
 *
 * [1738] Find Kth Largest XOR Coordinate Value
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start
class Solution {
    public int kthLargestValue(int[][] matrix, int k) {
        int m = matrix.length, n = matrix[0].length;
        Queue<Integer> queue = new PriorityQueue<>(k + 1);
        int[][] xors = new int[2][n + 1];
        for (int i = 0; i < m; ++i) {
            int r = i % 2;
            for (int j = 0; j < n; ++j) {
                int xor = matrix[i][j] ^ xors[r][j] ^ xors[1 - r][j + 1] ^ xors[1 - r][j];
                xors[r][j + 1] = xor;
                queue.offer(xor);
                if (queue.size() == k + 1) {
                    queue.poll();
                }
            }
        }
        return queue.poll();
    }
}
// @lc code=end

