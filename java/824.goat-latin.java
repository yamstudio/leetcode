/*
 * @lc app=leetcode id=824 lang=java
 *
 * [824] Goat Latin
 */

// @lc code=start
class Solution {
    public String toGoatLatin(String S) {
        String[] split = S.split(" ");
        StringBuilder sb = new StringBuilder();
        int n = split.length;
        for (int i = 0; i < n; ++i) {
            String word = split[i];
            char c = Character.toLowerCase(word.charAt(0));
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
                sb.append(word);
            } else {
                sb.append(word.substring(1));
                sb.append(word.charAt(0));
            }
            sb.append("maa");
            for (int j = 0; j < i; ++j) {
                sb.append('a');
            }
            if (i != n - 1) {
                sb.append(' ');
            }
        }
        return sb.toString();
    }
}
// @lc code=end

