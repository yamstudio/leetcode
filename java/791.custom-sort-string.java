/*
 * @lc app=leetcode id=791 lang=java
 *
 * [791] Custom Sort String
 */

// @lc code=start
class Solution {
    public String customSortString(String S, String T) {
        int[] dict = new int[26];
        int n = S.length();
        for (int i = 0; i < n; ++i) {
            dict[(int)S.charAt(i) - (int)'a'] = i + 1;
        }
        return T.chars().boxed().sorted((c1, c2) -> Integer.compare(dict[(int)c1 - (int)'a'], dict[(int)c2 - (int)'a'])).map(c -> Character.toString((char)c.intValue())).collect(Collectors.joining());
    }
}
// @lc code=end

