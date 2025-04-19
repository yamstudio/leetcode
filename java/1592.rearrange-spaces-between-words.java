/*
 * @lc app=leetcode id=1592 lang=java
 *
 * [1592] Rearrange Spaces Between Words
 */

// @lc code=start
class Solution {
    public String reorderSpaces(String text) {
        int n = text.length(), count = 0, w = 0;
        for (int i = 0; i < n; ++i) {
            if (text.charAt(i) == ' ') {
                ++count;
            } else {
                if (i == 0 || text.charAt(i - 1) == ' ') {
                    ++w;
                }
            }
        }
        int gap, end;
        if (w == 1) {
            gap = 0;
            end = count;
        } else {
            gap = count / (w - 1);
            end = count % (w - 1);
        }
        StringBuilder sb = new StringBuilder(n);
        for (int i = 0; i < n; ++i) {
            if (text.charAt(i) == ' ') {
                continue;
            }
            --w;
            while (i < n && text.charAt(i) != ' ') {
                sb.append(text.charAt(i));
                ++i;
            }
            if (w > 0) {
                for (int k = 0; k < gap; ++k) {
                    sb.append(' ');
                }
            }
        }
        while (end-- > 0) {
            sb.append(' ');
        }
        return sb.toString();
    }
}
// @lc code=end

