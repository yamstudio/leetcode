/*
 * @lc app=leetcode id=1333 lang=csharp
 *
 * [1333] Filter Restaurants by Vegan-Friendly, Price and Distance
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance) {
        return restaurants
            .Where(r => r[3] <= maxPrice && r[4] <= maxDistance && (r[2] == 1 || veganFriendly == 0))
            .OrderByDescending(r => r[1])
            .ThenByDescending(r => r[0])
            .Select(r => r[0])
            .ToList();
    }
}
// @lc code=end

