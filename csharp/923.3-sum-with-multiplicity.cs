/*
 * @lc app=leetcode id=923 lang=csharp
 *
 * [923] 3Sum With Multiplicity
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int ThreeSumMulti(int[] A, int target) {
        int ret = 0, n = A.Length;
        var count = new Dictionary<int, int>();
        for (int i = 0; i < n; ++i) {
            int x = A[i];
            if (count.TryGetValue(target - x, out int c)) {
                ret = (ret + c) % 1000000007;
            }
            for (int j = 0; j < i; ++j) {
                int sum = x + A[j];
                count[sum] = count.TryGetValue(sum, out int d) ? d + 1 : 1;
            }
        }
        return ret;
    }
}
// @lc code=end

