/*
 * @lc app=leetcode id=771 lang=csharp
 *
 * [771] Jewels and Stones
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumJewelsInStones(string J, string S) {
        var jewels = new HashSet<char>(J);
        return S.Where(c => jewels.Contains(c)).Count();
    }
}
// @lc code=end

