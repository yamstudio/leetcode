/*
 * @lc app=leetcode id=1647 lang=java
 *
 * [1647] Minimum Deletions to Make Character Frequencies Unique
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

class Solution {
    public int minDeletions(String s) {
        int[] count = new int[26];
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            ++count[s.charAt(i) - 'a'];
        }
        Queue<Integer> queue = new PriorityQueue<>(26, java.util.Comparator.reverseOrder());
        for (int i = 0; i < 26; ++i) {
            if (count[i] > 0) {
                queue.offer(count[i]);
            }
        }
        int ret = 0, p = Integer.MAX_VALUE;
        while (!queue.isEmpty()) {
            int c = queue.poll();
            if (c < p) {
                p = c;
                continue;
            }
            if (p > 0) {
                --p;
            }
            ret += c - p;
        }
        return ret;
    }
}
// @lc code=end

