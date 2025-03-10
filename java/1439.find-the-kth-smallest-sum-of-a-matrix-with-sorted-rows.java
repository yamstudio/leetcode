/*
 * @lc app=leetcode id=1439 lang=java
 *
 * [1439] Find the Kth Smallest Sum of a Matrix With Sorted Rows
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

class Solution {
    public int kthSmallest(int[][] mat, int k) {
        int m = Math.min(mat[0].length, k);
        Queue<Integer> curr = new PriorityQueue<>(k + 1, java.util.Comparator.reverseOrder()), prev = new PriorityQueue<>(k + 1, java.util.Comparator.reverseOrder());
        prev.offer(0);
        for (int[] row : mat) {
            for (int sum : prev) {
                for (int i = 0; i < m; ++i) {
                    curr.add(sum + row[i]);
                    if (curr.size() > k) {
                        curr.poll();
                    }
                }
            }
            var tmp = prev;
            prev = curr;
            curr = tmp;
            curr.clear();
        }
        return prev.poll();
    }
}
// @lc code=end

