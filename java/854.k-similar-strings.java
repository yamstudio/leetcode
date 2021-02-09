/*
 * @lc app=leetcode id=854 lang=java
 *
 * [854] K-Similar Strings
 */

// @lc code=start
class Solution {
    public int kSimilarity(String A, String B) {
        Set<String> visited = new HashSet<String>();
        Queue<String> queue = new LinkedList<String>();
        int ret = 0, n = A.length();
        visited.add(A);
        queue.offer(A);
        while (queue.size() > 0) {
            for (int i = queue.size(); i > 0; --i) {
                String curr = queue.poll();
                if (curr.equals(B)) {
                    return ret;
                }
                int l = 0;
                while (curr.charAt(l) == B.charAt(l)) {
                    ++l;
                }
                for (int r = l + 1; r < n; ++r) {
                    char c = curr.charAt(r);
                    if (c == B.charAt(r) || c != B.charAt(l)) {
                        continue;
                    }
                    StringBuilder sb = new StringBuilder(curr);
                    sb.replace(r, r + 1, Character.toString(curr.charAt(l)));
                    sb.replace(l, l + 1, Character.toString(c));
                    String next = sb.toString();
                    if (visited.add(next)) {
                        queue.offer(next);
                    }
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

