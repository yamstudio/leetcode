/*
 * @lc app=leetcode id=816 lang=java
 *
 * [816] Ambiguous Coordinates
 */

// @lc code=start
class Solution {

    private static List<String> getStrings(String S) {
        List<String> ret = new ArrayList<String>();
        int n = S.length();
        if (n == 0) {
            return ret;
        }
        if (n > 1 && S.charAt(0) == '0') {
             if (S.charAt(n - 1) != '0') {
                 ret.add(String.format("0.%s", S.substring(1)));
             }
            return ret;
        }
        ret.add(S);
        if (n == 1 || S.charAt(n - 1) == '0') {
            return ret;
        }
        for (int i = 1; i < n; ++i) {
            ret.add(String.format("%s.%s", S.substring(0, i), S.substring(i)));
        }
        return ret;
    }

    public List<String> ambiguousCoordinates(String S) {
        int n = S.length();
        List<String> ret = new ArrayList<String>();
        for (int i = 1; i < n - 2; ++i) {
            List<String> as = getStrings(S.substring(1, i + 1)), bs = getStrings(S.substring(1 + i, n - 1));
            for (String a : as) {
                for (String b : bs) {
                    ret.add(String.format("(%s, %s)", a, b));
                }
            }
        }
        return ret;
    }
}
// @lc code=end

