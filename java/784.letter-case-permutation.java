/*
 * @lc app=leetcode id=784 lang=java
 *
 * [784] Letter Case Permutation
 */

// @lc code=start
class Solution {
    
    private static void letterCasePermutation(String S, int i, List<String> ret, StringBuilder sb) {
        if (i == S.length()) {
            ret.add(sb.toString());
            return;
        }
        char c = S.charAt(i);
        sb.append(c);
        letterCasePermutation(S, i + 1, ret, sb);
        sb.deleteCharAt(i);
        if (c >= 'a' && c <= 'z') {
            sb.append((char)((int)c - (int)'a' + (int)'A'));
            letterCasePermutation(S, i + 1, ret, sb);
            sb.deleteCharAt(i);
        } else if (c >= 'A' && c <= 'Z') {
            sb.append((char)((int)c - (int)'A' + (int)'a'));
            letterCasePermutation(S, i + 1, ret, sb);
            sb.deleteCharAt(i);
        }
    }

    public List<String> letterCasePermutation(String S) {
        List<String> ret = new ArrayList<String>();
        letterCasePermutation(S, 0, ret, new StringBuilder(S.length()));
        return ret;
    }
}
// @lc code=end

