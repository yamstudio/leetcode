/*
 * @lc app=leetcode id=851 lang=csharp
 *
 * [851] Loud and Rich
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] LoudAndRich(int[][] richer, int[] quiet) {
        int n = quiet.Length;
        var richMap = new IList<int>[n];
        var poorMap = new IList<int>[n];
        int[] ret = new int[n], visitedCount = new int[n];
        var queue = new Queue<int>();
        foreach (var pair in richer) {
            int r = pair[0], p = pair[1];
            if (richMap[p] == null) {
                richMap[p] = new List<int>();
            }
            richMap[p].Add(r);
            if (poorMap[r] == null) {
                poorMap[r] = new List<int>();
            }
            poorMap[r].Add(p);
        }
        for (int i = 0; i < n; ++i) {
            if (richMap[i] == null) {
                ret[i] = i;
                queue.Enqueue(i);
            }
        }
        while (queue.Count > 0) {
            int i = queue.Dequeue();
            ret[i] = i;
            if (richMap[i] != null) {
                foreach (var r in richMap[i]) {
                    if (quiet[ret[r]] < quiet[ret[i]]) {
                        ret[i] = ret[r];
                    }
                }
            }
            if (poorMap[i] != null) {
                foreach (var p in poorMap[i]) {
                    if (visitedCount[p] < richMap[p].Count) {
                        ++visitedCount[p];
                        if (visitedCount[p] == richMap[p].Count) {
                            queue.Enqueue(p);
                        }
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

