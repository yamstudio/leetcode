/*
 * @lc app=leetcode id=752 lang=csharp
 *
 * [752] Open the Lock
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int OpenLock(string[] deadends, string target) {
        var dead = new HashSet<string>(deadends);
        if (dead.Contains("0000")) {
            return -1;
        }
        if (target == "0000") {
            return 0;
        }
        int ret = 0;
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("0000");
        dead.Add("0000");
        while (queue.Count > 0) {
            int count = queue.Count;
            ++ret;
            while (count-- > 0) {
                var curr = queue.Dequeue().ToCharArray();
                for (int i = 0; i < 4; ++i) {
                    for (int d = -1; d < 2; d += 2) {
                        char tmp = curr[i];
                        curr[i] = (char) (((int) curr[i] - (int) '0' + 10 + d) % 10 + (int) '0');
                        string next = new string(curr);
                        if (next == target) {
                            return ret;
                        }
                        if (!dead.Contains(next)) {
                            queue.Enqueue(next);
                            dead.Add(next);
                        }
                        curr[i] = tmp;
                    }
                }
            }
        }
        return -1;
    }
}
// @lc code=end

