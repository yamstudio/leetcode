/*
 * @lc app=leetcode id=833 lang=java
 *
 * [833] Find And Replace in String
 */

// @lc code=start
class Solution {
    public String findReplaceString(String S, int[] indexes, String[] sources, String[] targets) {
        int k = indexes.length;
        Integer[] sorted = new Integer[k];
        for (int i = 0; i < k; ++i) {
            sorted[i] = i;
        }
        Arrays.sort(sorted, (t1, t2) -> Integer.compare(indexes[t2], indexes[t1]));
        for (int i : sorted) {
            String s = sources[i], t = targets[i];
            if (s.equals(S.substring(indexes[i], indexes[i] + s.length()))) {
                S = String.format("%s%s%s", S.substring(0, indexes[i]), t, S.substring(indexes[i] + s.length()));
            }
        }
        return S;
    }
}
// @lc code=end

