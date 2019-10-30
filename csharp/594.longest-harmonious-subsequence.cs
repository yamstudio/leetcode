/*
 * @lc app=leetcode id=594 lang=csharp
 *
 * [594] Longest Harmonious Subsequence
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindLHS(int[] nums) {
        int ret = 0;
        IDictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in nums) {
            int c = 0;
            count.TryGetValue(num, out c);
            count[num] = c + 1;
        }
        foreach (var pair in count) {
            int num = pair.Key;
            int c;
            if (count.TryGetValue(num + 1, out c)) {
                ret = Math.Max(ret, c + pair.Value);
            }
        }
        return ret;
    }
}
// @lc code=end

