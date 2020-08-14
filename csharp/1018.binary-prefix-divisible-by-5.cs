/*
 * @lc app=leetcode id=1018 lang=csharp
 *
 * [1018] Binary Prefix Divisible By 5
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<bool> PrefixesDivBy5(int[] A) {
        int curr = 0;
        var ret = new List<bool>(A.Length);
        foreach (int num in A) {
            curr = ((curr << 1) | num) % 5;
            ret.Add(curr == 0);
        }
        return ret;
    }
}
// @lc code=end

