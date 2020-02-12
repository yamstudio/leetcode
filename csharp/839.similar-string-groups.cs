/*
 * @lc app=leetcode id=839 lang=csharp
 *
 * [839] Similar String Groups
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumSimilarGroups(string[] A) {
        var set = new HashSet<string>(A);
        int ret = 0, n = set.Count, k = A[0].Length;
        var queue = new Queue<string>();
        foreach (var s in A) {
            if (!set.Contains(s)) {
                continue;
            }
            ++ret;
            set.Remove(s);
            queue.Enqueue(s);
            while (queue.Count > 0) {
                string curr = queue.Dequeue();
                foreach (var next in set.ToArray()) {
                    int diff = 0;
                    for (int i = 0; i < k && diff <= 2; ++i) {
                        if (curr[i] != next[i]) {
                            ++diff;
                        }
                    }
                    if (diff == 2) {
                        set.Remove(next);
                        queue.Enqueue(next);
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

