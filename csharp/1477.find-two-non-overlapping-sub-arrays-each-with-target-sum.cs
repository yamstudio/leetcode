/*
 * @lc app=leetcode id=1477 lang=csharp
 *
 * [1477] Find Two Non-overlapping Sub-arrays Each With Target Sum
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        var map = new Dictionary<int, int>();
        int acc = 0, n = arr.Length, ret = int.MaxValue, size = int.MaxValue;
        map[0] = -1;
        for (int i = 0; i < n; ++i) {
            acc += arr[i];
            map[acc] = i;
        }
        acc = 0;
        for (int i = 0; i < n; ++i) {
            acc += arr[i];
            if (map.TryGetValue(acc - target, out int j)) {
                size = Math.Min(size, i - j);
            }
            if (size < int.MaxValue && map.TryGetValue(acc + target, out int k)) {
                ret = Math.Min(size + k - i, ret);
            }
        }
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

