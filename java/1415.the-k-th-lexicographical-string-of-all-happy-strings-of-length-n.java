/*
 * @lc app=leetcode id=1415 lang=java
 *
 * [1415] The k-th Lexicographical String of All Happy Strings of Length n
 */

// @lc code=start
class Solution {
    public String getHappyString(int n, int k) {
        int total = 3;
        for (int i = 1; i < n; ++i) {
            total *= 2;
        }
        if (k > total) {
            return "";
        }
        StringBuilder sb = new StringBuilder(n);
        if (k <= total / 3) {
            sb.append('a');
        } else if (k <= total / 3 * 2) {
            sb.append('b');
        } else {
            sb.append('c');
        }
        total /= 3;
        k = k % total;
        if (k == 0) {
            k = total;
        }
        while (--n > 0) {
            boolean firstHalf = k <= total / 2;
            char c = sb.charAt(sb.length() - 1);
            if (c == 'a') {
                sb.append(firstHalf ? 'b' : 'c');
            } else if (c == 'b') {
                sb.append(firstHalf ? 'a' : 'c');
            } else {
                sb.append(firstHalf ? 'a' : 'b');
            }
            total /= 2;
            k = k % total;
            if (k == 0) {
                k = total;
            }
        }
        return sb.toString();
    }
}
// @lc code=end

