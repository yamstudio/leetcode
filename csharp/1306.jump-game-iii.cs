/*
 * @lc app=leetcode id=1306 lang=csharp
 *
 * [1306] Jump Game III
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool CanReach(int[] arr, int start) {
        int n = arr.Length;
        var queue = new Queue<int>();
        var visited = new HashSet<int>() { start };
        queue.Enqueue(start);
        while (queue.Count > 0) {
            int curr = queue.Dequeue(), v = arr[curr];
            if (v == 0) {
                return true;
            }
            int l = curr - v, r = curr + v;
            if (l >= 0 && visited.Add(l)) {
                queue.Enqueue(l);
            }
            if (r < n && visited.Add(r)) {
                queue.Enqueue(r);
            }
        }
        return false;
    }
}
// @lc code=end

