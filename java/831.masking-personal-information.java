/*
 * @lc app=leetcode id=831 lang=java
 *
 * [831] Masking Personal Information
 */

// @lc code=start
class Solution {
    public String maskPII(String S) {
        int n = S.length(), at = S.indexOf('@');
        S = S.toLowerCase();
        if (at > 0) {
            return String.format("%c*****%c%s", S.charAt(0), S.charAt(at - 1), S.substring(at));
        }
        List<Character> numbers = new ArrayList<Character>(13);
        for (int i = 0; i < n; ++i) {
            char c = S.charAt(i);
            if (c <= '9' && c >= '0') {
                numbers.add(c);
            }
        }
        int d = numbers.size() - 10;
        StringBuilder sb = new StringBuilder();
        if (d > 0) {
            sb.append('+');
            while (d-- > 0) {
                sb.append('*');
            }
            sb.append('-');
        }
        sb.append("***-***-");
        sb.append(numbers.get(numbers.size() - 4));
        sb.append(numbers.get(numbers.size() - 3));
        sb.append(numbers.get(numbers.size() - 2));
        sb.append(numbers.get(numbers.size() - 1));
        return sb.toString();
    }
}
// @lc code=end

