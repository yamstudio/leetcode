/*
 * @lc app=leetcode id=1318 lang=csharp
 *
 * [1318] Minimum Flips to Make a OR b Equal to c
 */

// @lc code=start
public class Solution {
    public int MinFlips(int a, int b, int c) {
        int ret = 0;
        for (int i = 0; i < 32; ++i) {
            int m = 1 << i;
            if ((c & m) != 0) {
                if ((a & m) == 0 && (b & m) == 0) {
                    ++ret;
                }
            } else {
                if ((a & m) != 0) {
                    ++ret;
                }
                if ((b & m) != 0) {
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

