/*
 * @lc app=leetcode id=1508 lang=java
 *
 * [1508] Range Sum of Sorted Subarray Sums
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start
class Solution {
    public int rangeSum(int[] nums, int n, int left, int right) {
        Queue<Pair> queue = new PriorityQueue<>(right, java.util.Comparator.comparingInt(Pair::sum).thenComparing(Pair::nextIndex));
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            queue.offer(new Pair(nums[i], i + 1));
        }
        for (int i = 1; i <= right; ++i) {
            Pair min = queue.poll();
            if (i >= left) {
                ret = (ret + min.sum()) % 1000000007;
            }
            if (min.nextIndex() < n) {
                queue.offer(new Pair(min.sum() + nums[min.nextIndex()], min.nextIndex() + 1));
            }
        }
        return ret;
    }

    private record Pair(int sum, int nextIndex) {}
}
// @lc code=end

