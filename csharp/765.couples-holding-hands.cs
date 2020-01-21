/*
 * @lc app=leetcode id=765 lang=csharp
 *
 * [765] Couples Holding Hands
 */

// @lc code=start
public class Solution {
    public int MinSwapsCouples(int[] row) {
        int ret = 0, n = row.Length;
        for (int i = 0; i < n; i += 2) {
            int p = row[i] ^ 1;
            if (row[i + 1] == p) {
                continue;
            }
            for (int j = i + 1; j < n; ++j) {
                if (row[j] == p) {
                    row[j] = row[i + 1];
                    row[i + 1] = p;
                    break;
                }
            }
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

