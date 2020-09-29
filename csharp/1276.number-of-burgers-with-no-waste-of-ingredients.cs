/*
 * @lc app=leetcode id=1276 lang=csharp
 *
 * [1276] Number of Burgers with No Waste of Ingredients
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices) {
        if (tomatoSlices % 2 == 1 || tomatoSlices < 2 * cheeseSlices || tomatoSlices > 4 * cheeseSlices) {
            return new List<int>(0);
        }
        int t = (tomatoSlices - 2 * cheeseSlices) / 2;
        return new List<int>() { t, cheeseSlices - t };
    }
}
// @lc code=end

