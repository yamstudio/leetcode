/*
 * @lc app=leetcode id=936 lang=java
 *
 * [936] Stamping The Sequence
 */

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

// @lc code=start
class Solution {

    public int[] movesToStamp(String stamp, String target) {
        int m = stamp.length(), n = target.length();
        char[] targetChars = target.toCharArray();
        boolean[] stamped = new boolean[n];
        List<Integer> seq = new ArrayList<>();
        Queue<Integer> queue = new ArrayDeque<>();
        for (int i = 0; i + m <= n; ++i) {
            if (match(targetChars, i, stamp)) {
                applyStamp(targetChars, i, m);
                stamped[i] = true;
                queue.offer(i);
                seq.add(i);
            }
        }
        while (!queue.isEmpty()) {
            int last = queue.poll();
            int left = Math.max(0, last - m + 1);
            int right = Math.min(n - m + 1, last + m);
            for (int i = left; i < right; ++i) {
                if (!stamped[i] && match(targetChars, i, stamp)) {
                    applyStamp(targetChars, i, m);
                    stamped[i] = true;
                    queue.offer(i);
                    seq.add(i);
                }
            }
        }
        for (int i = 0; i < n; ++i) {
            if (targetChars[i] != '?') {
                return new int[0];
            }
        }
        int[] ret = new int[seq.size()];
        for (int i = 0; i < ret.length; ++i) {
            ret[i] = seq.get(ret.length - i - 1);
        }
        return ret;
    }

    private static boolean match(char[] targetChars, int start, String stamp) {
        boolean allQuestionMark = true;
        for (int i = 0; i < stamp.length(); ++i) {
            char t = targetChars[i + start];
            if (t != '?' && t != stamp.charAt(i)) {
                return false;
            }
            allQuestionMark = allQuestionMark && (t == '?');
        }
        return !allQuestionMark;
    }

    private static void applyStamp(char[] targetChars, int start, int m) {
        for (int i = 0; i < m; ++i) {
            targetChars[start + i] = '?';
        }
    }
}
// @lc code=end

