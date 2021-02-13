/*
 * @lc app=leetcode id=862 lang=java
 *
 * [862] Shortest Subarray with Sum at Least K
 */

// @lc code=start
class Solution {
    public int shortestSubarray(int[] A, int K) {
        int n = A.length, ret = Integer.MAX_VALUE;
        int[] sums = new int[n + 1];
        Deque<Integer> deque = new LinkedList<Integer>();
        for (int i = 0; i < n; ++i) {
            sums[i + 1] = sums[i] + A[i];
        }
        for (int i = 0; i <= n; ++i) {
            while (deque.size() > 0 && sums[i] - sums[deque.peekFirst()] >= K) {
                ret = Math.min(ret, i - deque.peekFirst());
                deque.pollFirst();
            }
            while (deque.size() > 0 && sums[i] <= sums[deque.peekLast()]) {
                deque.pollLast();
            }
            deque.offerLast(i);
        }
        return ret == Integer.MAX_VALUE ? -1 : ret;
    }
}
// @lc code=end

