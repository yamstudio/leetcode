/*
 * @lc app=leetcode id=1001 lang=csharp
 *
 * [1001] Grid Illumination
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static IEnumerable<(int Dir, int Key)> GetKeys(int r, int c) {
        yield return (Dir: 0, Key: r);
        yield return (Dir: 1, Key: c);
        yield return (Dir: 2, Key: r + c);
        yield return (Dir: 3, Key: r - c);
    }

    public int[] GridIllumination(int N, int[][] lamps, int[][] queries) {
        int qs = queries.Length;
        int[] ret = new int[qs];
        var set = new HashSet<(int R, int C)>();
        var count = new Dictionary<(int Dir, int Key), int>();
        foreach (var lamp in lamps) {
            int r = lamp[0], c = lamp[1];
            set.Add((R: r, C: c));
            foreach (var key in GetKeys(r, c)) {
                if (count.TryGetValue(key, out int v)) {
                    count[key] = v + 1;
                } else {
                    count[key] = 1;
                }
            }
        }
        for (int i = 0; i < qs; ++i) {
            var query = queries[i];
            int r = query[0], c = query[1];
            if (!GetKeys(r, c).Any(k => count.TryGetValue(k, out int v) && v > 0)) {
                continue;
            }
            ret[i] = 1;
            for (int nr = r - 1; nr <= r + 1; ++nr) {
                if (nr < 0 || nr >= N) {
                    continue;
                }
                for (int nc = c - 1; nc <= c + 1; ++nc) {
                    if (nc < 0 || nc >= N) {
                        continue;
                    }
                    if (set.Remove((R: nr, C: nc))) {
                        foreach (var key in GetKeys(nr, nc)) {
                            if (count.TryGetValue(key, out int v)) {
                                count[key] = v - 1;
                            }
                        }
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

