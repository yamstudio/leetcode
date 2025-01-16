/*
 * @lc app=leetcode id=1240 lang=java
 *
 * [1240] Tiling a Rectangle with the Fewest Squares
 */

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

// @lc code=start

import static java.util.stream.Collectors.joining;

class Solution {
    public int tilingRectangle(int n, int m) {
        if (n == m) {
            return 1;
        }
        int length = Math.max(m, n), width = Math.min(m, n);
        int[] ret = new int[] { m * n };
        helper(length, width, 0, new int[width], ret, new HashMap<>());
        return ret[0];
    }

    private void helper(int length, int width, int count, int[] heights, int[] ret, Map<String, Integer> keyToMinCount) {
        if (count >= ret[0]) {
            return;
        }
        int minHeight = length, minIndex = -1;
        for (int i = 0; i < width; ++i) {
            if (heights[i] < minHeight) {
                minIndex = i;
                minHeight = heights[i];
            }
        }
        if (minIndex == -1) {
            ret[0] = count;
            return;
        }
        String key = Arrays.stream(heights).mapToObj(Integer::toString).collect(joining(","));
        Integer existingMinCount = keyToMinCount.get(key);
        if (existingMinCount != null && existingMinCount <= count) {
            return;
        }
        keyToMinCount.put(key, count);
        int end;
        for (end = minIndex; end + 1 < width && minHeight == heights[end + 1] && minHeight + (end + 1 - minIndex + 1) <= length; ++end);
        for (; end >= minIndex; --end) {
            int l = end - minIndex + 1;
            for (int i = minIndex; i <= end; ++i) {
                heights[i] += l;
            }
            helper(length, width, count + 1, heights, ret, keyToMinCount);
            for (int i = minIndex; i <= end; ++i) {
                heights[i] -= l;
            }
        }
    }
}
// @lc code=end

