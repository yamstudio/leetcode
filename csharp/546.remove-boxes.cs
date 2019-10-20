/*
 * @lc app=leetcode id=546 lang=csharp
 *
 * [546] Remove Boxes
 */

// @lc code=start
public class Solution {

    private int RemoveBoxesRecurse(int[] boxes, int start, int end, int left, int[,,] dp) {
        if (end < start) {
            return 0;
        }
        int ret = dp[start, end, left];
        if (ret > 0) {
            return ret;
        }
        ret = (1 + left) * (1 + left) + RemoveBoxesRecurse(boxes, start + 1, end, 0, dp);
        int curr = boxes[start];
        for (int i = start + 1; i <= end; ++i) {
            if (curr == boxes[i]) {
                ret = Math.Max(ret, RemoveBoxesRecurse(boxes, start + 1, i - 1, 0, dp) + RemoveBoxesRecurse(boxes, i, end, left + 1, dp));
            }
        }
        dp[start, end, left] = ret;
        return ret;
    }

    public int RemoveBoxes(int[] boxes) {
        int n = boxes.Length;
        return RemoveBoxesRecurse(boxes, 0, n - 1, 0, new int[n, n, n]);
    }
}
// @lc code=end

