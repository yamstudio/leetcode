/*
 * @lc app=leetcode id=1346 lang=csharp
 *
 * [1346] Check If N and Its Double Exist
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool CheckIfExist(int[] arr) {
        var set = new HashSet<int>();
        foreach (int x in arr) {
            if (set.Contains(x * 2) || x % 2 == 0 && set.Contains(x / 2)) {
                return true;
            }
            set.Add(x);
        }
        return false;
    }
}
// @lc code=end

