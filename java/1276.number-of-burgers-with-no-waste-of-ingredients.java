/*
 * @lc app=leetcode id=1276 lang=java
 *
 * [1276] Number of Burgers with No Waste of Ingredients
 */

import java.util.Collections;
import java.util.List;

// @lc code=start
class Solution {
    public List<Integer> numOfBurgers(int tomatoSlices, int cheeseSlices) {
        if (tomatoSlices % 2 == 1 || tomatoSlices < 2 * cheeseSlices || tomatoSlices > 4 * cheeseSlices) {
            return Collections.emptyList();
        }
        int j = (tomatoSlices - 2 * cheeseSlices) / 2;
        return List.of(j, cheeseSlices - j);
    }
}
// @lc code=end

