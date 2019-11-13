/*
 * @lc app=leetcode id=659 lang=csharp
 *
 * [659] Split Array into Consecutive Subsequences
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool IsPossible(int[] nums) {
        IDictionary<int, int> count = new Dictionary<int, int>(), end = new Dictionary<int, int>();
        foreach (int num in nums) {
            int val = 0;
            count.TryGetValue(num, out val);
            count[num] = val + 1;
        }
        foreach (int num in nums) {
            int v = 0;
            if (!count.TryGetValue(num, out v) || v == 0) {
                continue;
            }
            count[num] = v - 1;
            int e = 0;
            if (end.TryGetValue(num, out e) && e > 0) {
                end[num] = e - 1;
                e = 0;
                end.TryGetValue(num + 1, out e);
                end[num + 1] = e + 1;
                continue;
            }
            int n = 0, nn = 0;
            if (count.TryGetValue(num + 1, out n) && n > 0 && count.TryGetValue(num + 2, out nn) && nn > 0) {
                count[num + 1] = n - 1;
                count[num + 2] = nn - 1;
                end.TryGetValue(num + 3, out e);
                end[num + 3] = e + 1;
                continue;
            }
            return false;
        }
        return true;
    }
}
// @lc code=end

