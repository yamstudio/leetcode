/*
 * @lc app=leetcode id=207 lang=csharp
 *
 * [207] Course Schedule
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var deps = new IList<int>[numCourses];
        var count = new int[numCourses];
        var queue = new Queue<int>();
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
            if (deps[curr] != null) {
                foreach (int next in deps[curr]) {
                    --count[next];
                    if (count[next] == 0) {
                        queue.Enqueue(next);
                    }
                }
            }
        }
        return count.All(x => x == 0);
    }
}

