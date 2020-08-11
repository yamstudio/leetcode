/*
 * @lc app=leetcode id=1012 lang=csharp
 *
 * [1012] Numbers With Repeated Digits
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int NumPermutation(int len, int free, IDictionary<(int Len, int Free), int> memo) {
        if (len == 0) {
            return 1;
        }
        var key = (len: len, Free: free);
        if (memo.TryGetValue(key, out int ret)) {
            return ret;
        }
        return memo[key] = NumPermutation(len - 1, free, memo) * (free - len + 1);
    }

    public int NumDupDigitsAtMostN(int N) {
        var list = new List<int>();
        for (int i = N + 1; i > 0; i /= 10) {
            list.Add(i % 10);
        }
        int len = list.Count, distinct = 0;
        var memo = new Dictionary<(int Len, int Free), int>();
        var used = new HashSet<int>();
        for (int i = 1; i < len; ++i) {
            distinct += 9 * NumPermutation(i - 1, 9, memo);
        }
        for (int i = 0; i < len; ++i) {
            int curr = list[len - i - 1];
            for (int j = i == 0 ? 1 : 0; j < curr; ++j) {
                if (!used.Contains(j)) {
                    distinct += NumPermutation(len - i - 1, 9 - i, memo);
                }
            }
            if (!used.Add(curr)) {
                break;
            }
        }
        return N - distinct;
    }
}
// @lc code=end

