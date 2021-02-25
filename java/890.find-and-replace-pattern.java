/*
 * @lc app=leetcode id=890 lang=java
 *
 * [890] Find and Replace Pattern
 */

// @lc code=start
class Solution {
    public List<String> findAndReplacePattern(String[] words, String pattern) {
        List<String> ret = new ArrayList<String>();
        int n = pattern.length();
        for (String word : words) {
            int[] wtp = new int[26], ptw = new int[26];
            boolean flag = false;
            for (int i = 0; i < n && !flag; ++i) {
                int w = (int)word.charAt(i) - (int)'a', p = pattern.charAt(i) - (int)'a';
                if (wtp[w] == 0) {
                    if (ptw[p] != 0) {
                        flag = true;
                    } else {
                        wtp[w] = p + 1;
                        ptw[p] = w + 1;
                    }
                } else {
                    if (wtp[w] != p + 1) {
                        flag = true;
                    }
                }
            }
            if (!flag) {
                ret.add(word);
            }
        }
        return ret;
    }
}
// @lc code=end

