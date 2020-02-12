/*
 * @lc app=leetcode id=841 lang=csharp
 *
 * [841] Keys and Rooms
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        int n = rooms.Count, count = 1;
        bool[] visited = new bool[n];
        var queue = new Queue<int>();
        queue.Enqueue(0);
        visited[0] = true;
        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            foreach (var next in rooms[curr]) {
                if (visited[next]) {
                    continue;
                }
                ++count;
                visited[next] = true;
                queue.Enqueue(next);
            }
        }
        return n == count;
    }
}
// @lc code=end

