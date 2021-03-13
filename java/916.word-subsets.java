/*
 * @lc app=leetcode id=916 lang=java
 *
 * [916] Word Subsets
 */

// @lc code=start
class Solution {
    public List<String> wordSubsets(String[] A, String[] B) {
        int[] template = new int[26];
        for (String b : B) {
            int[] curr = new int[26];
            for (char c : b.toCharArray()) {
                ++curr[(int)c - (int)'a'];
            }
            for (int i = 0; i < 26; ++i) {
                template[i] = Math.max(template[i], curr[i]);
            }
        }
        List<String> ret = new ArrayList<String>();
        for (String a : A) {
            int[] curr = new int[26];
            boolean flag = true;
            for (char c : a.toCharArray()) {
                ++curr[(int)c - (int)'a'];
            }
            for (int i = 0; i < 26 && flag; ++i) {
                flag = curr[i] >= template[i];
            }
            if (flag) {
                ret.add(a);
            }
        }
        return ret;
    }
}
// @lc code=end

