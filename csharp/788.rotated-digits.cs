/*
 * @lc app=leetcode id=788 lang=csharp
 *
 * [788] Rotated Digits
 */

// @lc code=start
public class Solution {

    private static int[] ValidDigits = new int[] {
        1, 1, 2, 0, 0, 2, 2, 0, 1, 2
    };

    public int RotatedDigits(int N) {
        int ret = 0;
        int[] valid = new int[N + 1];
        for (int i = 0; i < 10 && i <= N; ++i) {
            valid[i] = ValidDigits[i];
            if (valid[i] == 2) {
                ++ret;
            }
        }
        for (int i = 10; i <= N; ++i) {
            int q = i / 10, r = i % 10;
            if (valid[q] == 1 && valid[r] == 1) {
                valid[i] = 1;
            } else if (valid[q] >= 1 && valid[r] >= 1) {
                valid[i] = 2;
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

