/*
 * @lc app=leetcode id=886 lang=csharp
 *
 * [886] Possible Bipartition
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool PossibleBipartition(int N, int[][] dislikes) {
        var dis = new Dictionary<int, ISet<int>>();
        var color = new Dictionary<int, bool>();
        var queue = new Queue<int>();
        foreach (var pair in dislikes) {
            int a = pair[0], b = pair[1];
            ISet<int> ad, bd;
            if (!dis.TryGetValue(a, out ad)) {
                ad = new HashSet<int>();
                dis[a] = ad;
            }
            if (!dis.TryGetValue(b, out bd)) {
                bd = new HashSet<int>();
                dis[b] = bd;
            }
            ad.Add(b);
            bd.Add(a);
        }
        foreach (var root in dis.Keys) {
            if (color.ContainsKey(root)) {
                continue;
            }
            color[root] = true;
            queue.Enqueue(root);
            while (queue.Count > 0) {
                for (int i = queue.Count; i > 0; --i) {
                    int curr = queue.Dequeue();
                    bool c = color[curr];
                    foreach (var next in dis[curr]) {
                        if (color.TryGetValue(next, out var val)) {
                            if (val == c) {
                                return false;
                            }
                            continue;
                        }
                        color[next] = !c;
                        queue.Enqueue(next);
                    }
                }
            }
        }
        return true;
    }
}
// @lc code=end

