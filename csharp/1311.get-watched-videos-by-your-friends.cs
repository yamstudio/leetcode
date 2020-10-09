/*
 * @lc app=leetcode id=1311 lang=csharp
 *
 * [1311] Get Watched Videos by Your Friends
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level) {
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        visited.Add(id);
        queue.Enqueue(id);
        while (level-- > 0) {
            for (int i = queue.Count; i > 0; --i) {
                int curr = queue.Dequeue();
                foreach (int next in friends[curr]) {
                    if (visited.Add(next)) {
                        queue.Enqueue(next);
                    }
                }
            }
        }
        return queue
            .SelectMany(i => watchedVideos[i])
            .GroupBy(v => v, (string v, IEnumerable<string> all) => (Video: v, Count: all.Count()))
            .OrderBy(t => t.Count)
            .ThenBy(t => t.Video)
            .Select(t => t.Video)
            .ToList();
    }
}
// @lc code=end

