/*
 * @lc app=leetcode id=850 lang=java
 *
 * [850] Rectangle Area II
 */

// @lc code=start
class Solution {

    private static void add(List<int[]> list, int[] rect, int i) {
        if (i >= list.size()) {
            list.add(rect);
            return;
        }
        int[] curr = list.get(i);
        if (curr[0] >= rect[2] || curr[1] >= rect[3] || rect[0] >= curr[2] || rect[1] >= curr[3]) {
            add(list, rect, i + 1);
            return;
        }
        if (curr[0] > rect[0]) {
            add(list, new int[] { rect[0], rect[1], curr[0], rect[3] }, i + 1);
        }
        if (curr[1] > rect[1]) {
            add(list, new int[] { rect[0], rect[1], rect[2], curr[1] }, i + 1);
        }
        if (curr[2] < rect[2]) {
            add(list, new int[] { curr[2], rect[1], rect[2], rect[3] }, i + 1);
        }
        if (curr[3] < rect[3]) {
            add(list, new int[] { rect[0], curr[3], rect[2], rect[3] }, i + 1);
        }
    }

    public int rectangleArea(int[][] rectangles) {
        List<int[]> list = new ArrayList<int[]>();
        long ret = 0;
        for (int[] rect : rectangles) {
            add(list, rect, 0);
        }
        for (int[] rect : list) {
            ret = (ret + (long)(rect[2] - rect[0]) * (long)(rect[3] - rect[1])) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

