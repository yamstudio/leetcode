/*
 * @lc app=leetcode id=475 lang=csharp
 *
 * [475] Heaters
 */

using System;

// @lc code=start
public class Solution {
    public int FindRadius(int[] houses, int[] heaters) {
        int ret = 0, m = heaters.Length;
        Array.Sort(heaters);
        foreach (int house in houses) {
            int left = 0, right = m;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (heaters[mid] < house) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            int dl = left == 0 ? int.MaxValue : house - heaters[left - 1];
            int dr = left == m ? int.MaxValue : heaters[left] - house;
            ret = Math.Max(ret, Math.Min(dl, dr));
        }
        return ret;
    }
}
// @lc code=end

