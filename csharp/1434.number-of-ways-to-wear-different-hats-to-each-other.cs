/*
 * @lc app=leetcode id=1434 lang=csharp
 *
 * [1434] Number of Ways to Wear Different Hats to Each Other
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int NumberWays(int curr, int target, int h, IList<int>[] people, int?[,] memo) {
        if (curr == target) {
            return 1;
        }
        if (h >= people.Length) {
            return 0;
        }
        if (memo[curr, h].HasValue) {
            return memo[curr, h].Value;
        }
        int ret = NumberWays(curr, target, h + 1, people, memo);
        foreach (int p in people[h]) {
            if ((curr & (1 << p)) != 0) {
                continue;
            }
            ret = (ret + NumberWays(curr | (1 << p), target, h + 1, people, memo)) % 1000000007;
        }
        memo[curr, h] = ret;
        return ret;
    }

    public int NumberWays(IList<IList<int>> hats) {
        int n = hats.Count;
        var people = new Dictionary<int, IList<int>>();
        for (int i = 0; i < n; ++i) {
            foreach (int h in hats[i]) {
                if (!people.TryGetValue(h, out var l)) {
                    l = new List<int>();
                    people[h] = l;
                }
                l.Add(i);
            }
        }
        return NumberWays(0, -1 + (1 << n), 0, people.Values.ToArray(), new int?[1 << n, people.Count]);
    }
}
// @lc code=end

