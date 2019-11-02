/*
 * @lc app=leetcode id=605 lang=csharp
 *
 * [605] Can Place Flowers
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int len = 1;
        foreach (int c in flowerbed) {
            if (c == 0) {
                ++len;
                continue;
            }
            if (len > 2) {
                n -= (len - 1) / 2;
                if (n <= 0) {
                    return true;
                }
            }
            len = 0;
        }
        ++len;
        if (len > 2) {
            n -= (len - 1) / 2;
        }
        return n <= 0;
    }
}
// @lc code=end

