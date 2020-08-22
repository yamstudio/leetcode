/*
 * @lc app=leetcode id=1046 lang=csharp
 *
 * [1046] Last Stone Weight
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LastStoneWeight(int[] stones) {
        var sorted = new SortedList<int, int>();
        sorted[0] = 1;
        foreach (var stone in stones) {
            if (sorted.TryGetValue(stone, out int count)) {
                sorted[stone] = count + 1;
            } else {
                sorted[stone] = 1;
            }
        }
        while (sorted.Count > 1) {
            var keys = sorted.Keys;
            int m = keys[sorted.Count - 1], m2 = keys[sorted.Count - 2];
            if (sorted[m] > 2) {
                sorted[m] -= 2;
                continue;
            }
            if (sorted[m] == 2) {
                sorted.RemoveAt(sorted.Count - 1);
                continue;
            }
            int diff = m - m2;
            sorted.RemoveAt(sorted.Count - 1);
            if (sorted[m2] == 1) {
                sorted.RemoveAt(sorted.Count - 1);
            } else {
                sorted[m2]--;
            }
            if (sorted.TryGetValue(diff, out int count)) {
                sorted[diff] = count + 1;
            } else {
                sorted[diff] = 1;
            }
        }
        return sorted.Keys[0];
    }
}
// @lc code=end

