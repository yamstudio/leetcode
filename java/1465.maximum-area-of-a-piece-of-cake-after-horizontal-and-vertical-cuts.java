/*
 * @lc app=leetcode id=1465 lang=java
 *
 * [1465] Maximum Area of a Piece of Cake After Horizontal and Vertical Cuts
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int maxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
        Arrays.sort(horizontalCuts);
        Arrays.sort(verticalCuts);
        long mh = Math.max(horizontalCuts[0], h - horizontalCuts[horizontalCuts.length - 1]), mw = Math.max(verticalCuts[0], w - verticalCuts[verticalCuts.length - 1]);
        for (int i = horizontalCuts.length - 1; i > 0; --i) {
            mh = Math.max(mh, horizontalCuts[i] - horizontalCuts[i - 1]);
        }
        for (int i = verticalCuts.length - 1; i > 0; --i) {
            mw = Math.max(mw, verticalCuts[i] - verticalCuts[i - 1]);
        }
        return (int)(((mh % 1000000007) * (mw % 1000000007)) % 1000000007);
    }
}
// @lc code=end

