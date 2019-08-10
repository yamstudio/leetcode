/*
 * @lc app=leetcode id=210 lang=csharp
 *
 * [210] Course Schedule II
 */

using System;
using System.Collections.Generic;

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var deps = new IList<int>[numCourses];
        var count = new int[numCourses];
        var queue = new Queue<int>();
        var ret = new List<int>(numCourses);
        foreach (int[] pair in prerequisites) {
            int f = pair[0], s = pair[1];
            IList<int> dep = deps[s];
            if (dep == null) {
                dep = new List<int>();
                deps[s] = dep;
            }
            dep.Add(f);
            ++count[f];
        }
        for (int i = 0; i < numCourses; ++i) {
            if (count[i] == 0) {
                queue.Enqueue(i);
            }
        }
        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            ret.Add(curr);
            if (deps[curr] != null) {
                foreach (int next in deps[curr]) {
                    --count[next];
                    if (count[next] == 0) {
                        queue.Enqueue(next);
                    }
                }
            }
        }
        return ret.Count == numCourses ? ret.ToArray() : Array.Empty<int>();
    }
}

