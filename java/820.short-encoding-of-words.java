/*
 * @lc app=leetcode id=820 lang=java
 *
 * [820] Short Encoding of Words
 */

// @lc code=start
class Solution {
    public int minimumLengthEncoding(String[] words) {
        Set<String> set = new HashSet<String>(Arrays.asList(words)), remove = new HashSet<String>();
        for (String word : set) {
            if (remove.contains(word)) {
                continue;
            }
            int k = word.length();
            for (int i = 1; i < k; ++i) {
                String s = word.substring(k - i);
                if (set.contains(s)) {
                    remove.add(s);
                }
            }
        }
        int ret = 0;
        for (String word : set) {
            if (!remove.contains(word)) {
                ret += word.length() + 1;
            }
        }
        return ret;
    }
}
// @lc code=end

