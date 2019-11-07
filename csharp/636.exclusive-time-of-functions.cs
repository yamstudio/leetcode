/*
 * @lc app=leetcode id=636 lang=csharp
 *
 * [636] Exclusive Time of Functions
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int[] ret = new int[n];
        int time = 0;
        IList<int> stack = new List<int>();
        foreach (var log in logs) {
            var split = log.Split(':');
            int i = int.Parse(split[0]), t = int.Parse(split[2]);
            if (stack.Count > 0) {
                ret[stack[stack.Count - 1]] += t - time;
            }
            time = t;
            if (split[1] == "start") {
                stack.Add(i);
            } else {
                ret[i]++;
                time++;
                stack.RemoveAt(stack.Count - 1);
            }
        }
        return ret;
    }
}
// @lc code=end

