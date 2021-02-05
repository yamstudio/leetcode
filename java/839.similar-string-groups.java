/*
 * @lc app=leetcode id=839 lang=java
 *
 * [839] Similar String Groups
 */

// @lc code=start
class Solution {
    public int numSimilarGroups(String[] strs) {
        Set<String> set = new HashSet<String>(Arrays.asList(strs));
        int ret = 0, n = strs[0].length();
        for (String s : strs) {
            if (!set.remove(s)) {
                continue;
            }
            ++ret;
            Queue<String> queue = new LinkedList<String>();
            queue.offer(s);
            while (queue.size() > 0) {
                String c = queue.poll();
                for (String t : new ArrayList<String>(set)) {
                    int diff = 0;
                    for (int i = 0; i < n && diff <= 2; ++i) {
                        if (t.charAt(i) != c.charAt(i)) {
                            ++diff;
                        }
                    }
                    if (diff == 2 || diff == 0) {
                        set.remove(t);
                        queue.offer(t);
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

