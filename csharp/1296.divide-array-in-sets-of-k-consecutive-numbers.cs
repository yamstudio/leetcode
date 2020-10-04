/*
 * @lc app=leetcode id=1296 lang=csharp
 *
 * [1296] Divide Array in Sets of K Consecutive Numbers
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool IsPossibleDivide(int[] nums, int k) {
        int n = nums.Length;
        if (n % k != 0) {
            return false;
        }
        var count = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (count.TryGetValue(num, out int c)) {
                count[num] = c + 1;
            } else {
                count[num] = 1;
            }
        }
        var keys = count.Keys.OrderBy(x => x).ToArray();
        int m = keys.Length;
        for (int i = 0; i < m; ++i) {
            int b = keys[i];
            if (!count.TryGetValue(b, out var c)) {
                continue;
            }
            count.Remove(b);
            for (int j = 1; j < k; ++j) {
                if (!count.TryGetValue(b + j, out var t) || t < c) {
                    return false;
                }
                if (t == c) {
                    count.Remove(b + j);
                } else {
                    count[b + j] = t - c;
                }
            }
        }
        return true;
    }
}
// @lc code=end

