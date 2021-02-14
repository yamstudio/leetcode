/*
 * @lc app=leetcode id=870 lang=java
 *
 * [870] Advantage Shuffle
 */

// @lc code=start
class Solution {
    public int[] advantageCount(int[] A, int[] B) {
        int n = A.length, l = 0, r = n - 1;
        int[] ret = new int[n];
        Queue<Integer> pq = new PriorityQueue<Integer>((a, b) -> Integer.compare(B[b], B[a]));
        Arrays.sort(A);
        for (int i = 0; i < n; ++i) {
            pq.offer(i);
        }
        for (int i = 0; i < n; ++i) {
            int j = pq.poll(), val = B[j];
            if (A[r] > val) {
                ret[j] = A[r--];
            } else {
                ret[j] = A[l++];
            }
        }
        return ret;
    }
}
// @lc code=end

