/*
 * @lc app=leetcode id=1169 lang=csharp
 *
 * [1169] Invalid Transactions
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<string> InvalidTransactions(string[] transactions) {
        IList<string> ret = new List<string>();
        var sorted = transactions
            .Select(transaction => transaction.Split(','))
            .Select(transaction => (Name: transaction[0], Time: int.Parse(transaction[1]), Amount: int.Parse(transaction[2]), City: transaction[3]))
            .OrderBy(transaction => transaction.Time)
            .ToArray();
        int n = sorted.Length;
        bool[] flagged = new bool[n];
        for (int i = 0; i < n; ++i) {
            var curr = sorted[i];
            bool flag = flagged[i] || curr.Amount > 1000;
            for (int j = i + 1; j < n; ++j) {
                var next = sorted[j];
                if (next.Time > curr.Time + 60) {
                    break;
                }
                if (next.Name == curr.Name && next.City != curr.City) {
                    flag = true;
                    flagged[j] = true;
                }
            }
            if (flag) {
                ret.Add($"{curr.Name},{curr.Time},{curr.Amount},{curr.City}");
            }
        }
        return ret;
    }
}
// @lc code=end

