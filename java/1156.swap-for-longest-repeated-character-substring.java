/*
 * @lc app=leetcode id=1156 lang=java
 *
 * [1156] Swap For Longest Repeated Character Substring
 */

// @lc code=start
class Solution {
    public int maxRepOpt1(String text) {
        int i = 0, n = text.length(), pp = 0, p = 0, ret = 1;
        char ppc = '\0', pc = '\0';
        int[] maxSegmentWithGap = new int[26];
        int[] maxSegment = new int[26];
        int[] firstIndexPlusOne = new int[26];
        while (i < n) {
            char c = text.charAt(i);
            int k = c - 'a', j;
            ret = Math.max(Math.max(ret, 1 + maxSegment[k]), 1 + maxSegmentWithGap[k]);
            for (j = i + 1; j < n && text.charAt(j) == c; ++j);
            if (ppc == c && p == 1) {
                ret = Math.max(ret, pp + j - i + (firstIndexPlusOne[k] != 0 && firstIndexPlusOne[k] < i - 1 - pp ? 1 : 0));
                maxSegmentWithGap[k] = Math.max(maxSegmentWithGap[k], pp + j - i);
            } else {
                ret = Math.max(ret, j - i + (firstIndexPlusOne[k] != 0 ? 1 : 0));
            }
            pp = p;
            ppc = pc;
            p = j - i;
            pc = c;
            if (firstIndexPlusOne[k] == 0) {
                firstIndexPlusOne[k] = i + 1;
            }
            maxSegment[k] = Math.max(maxSegment[k], j - i);
            i = j;
        }
        return ret;
    }
}
// @lc code=end

