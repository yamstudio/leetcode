/*
 * @lc app=leetcode id=1333 lang=java
 *
 * [1333] Filter Restaurants by Vegan-Friendly, Price and Distance
 */

import java.util.Arrays;
import java.util.List;

// @lc code=start

import static java.util.Comparator.comparingInt;

class Solution {
    public List<Integer> filterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance) {
        return Arrays
            .stream(restaurants)
            .filter(restaurant -> (veganFriendly == 0 || restaurant[2] == 1) && restaurant[3] <= maxPrice && restaurant[4] <= maxDistance)
            .sorted(comparingInt((int[] restaurant) -> -restaurant[1]).thenComparingInt((int[] restaurant) -> -restaurant[0]))
            .map(restaurant -> restaurant[0])
            .toList();
    }
}
// @lc code=end

