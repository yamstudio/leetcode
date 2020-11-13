/*
 * @lc app=leetcode id=1442 lang=csharp
 *
 * [1442] Count Triplets That Can Form Two Arrays of Equal XOR
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int CountTriplets(int[] arr) {
        int n = arr.Length, ret = 0;
        var xor = new int[n + 1];
        IDictionary<int, int> count = new Dictionary<int, int>(), indices = new Dictionary<int, int>();
        for (int i = 0; i < n; ++i) {
            xor[i + 1] = xor[i] ^ arr[i];
        }
        for (int i = 0; i <= n; ++i) {
            int x = xor[i];
            if (!count.TryGetValue(x, out var c)) {
                count[x] = 1;
                indices[x] = i;
                continue;
            }
            ret += c * (i - 1) - indices[x];
            count[x] = c + 1;
            indices[x] += i;
        }
        return ret;
    }
}
// @lc code=end

