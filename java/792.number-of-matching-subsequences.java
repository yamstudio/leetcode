/*
 * @lc app=leetcode id=792 lang=java
 *
 * [792] Number of Matching Subsequences
 */

// @lc code=start
class Solution {
    public int numMatchingSubseq(String S, String[] words) {
        int ret = 0, n = words.length, k = S.length();
        Queue<int[]>[] queues = new Queue[26];
        for (int i = 0; i < 26; ++i) {
            queues[i] = new LinkedList<int[]>();
        }
        for (int i = 0; i < n; ++i) {
            queues[(int)words[i].charAt(0) - (int)'a'].add(new int[] { i, 0 });
        }
        for (int i = 0; i < k; ++i) {
            int c = (int)S.charAt(i) - (int)'a', m = queues[c].size();
            while (m-- > 0) {
                int[] curr = queues[c].poll();
                String word = words[curr[0]];
                if (curr[1] == word.length() - 1) {
                    ++ret;
                } else {
                    queues[(int)word.charAt(curr[1] + 1) - (int)'a'].offer(new int[] { curr[0], curr[1] + 1 });
                }
            }
        }
        return ret;
    }
}
// @lc code=end

