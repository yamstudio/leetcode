/*
 * @lc app=leetcode id=1441 lang=csharp
 *
 * [1441] Build an Array With Stack Operations
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<string> BuildArray(int[] target, int n) {
        int prev = 0;
        var ret = new List<string>();
        foreach (int curr in target) {
            while (++prev < curr) {
                ret.Add("Push");
                ret.Add("Pop");
            }
            ret.Add("Push");
        }
        return ret;
    }
}
// @lc code=end

