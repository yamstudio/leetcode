/*
 * @lc app=leetcode id=957 lang=csharp
 *
 * [957] Prison Cells After N Days
 */

// @lc code=start
public class Solution {
    public int[] PrisonAfterNDays(int[] cells, int N) {
        int[] tmp = new int[8];
        N = (13 + N) % 14 + 1;
        for (int i = 0; i < N; ++i) {
            for (int j = 1; j < 7; ++j) {
                if (cells[j - 1] == cells[j + 1]) {
                    tmp[j] = 1;
                } else {
                    tmp[j] = 0;
                }
            }
            tmp[0] = 0;
            tmp[7] = 0;
            var t = tmp;
            tmp = cells;
            cells = t;
        }
        return cells;
    }
}
// @lc code=end

