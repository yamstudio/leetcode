/*
 * @lc app=leetcode id=1122 lang=java
 *
 * [1122] Relative Sort Array
 */

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public int[] relativeSortArray(int[] arr1, int[] arr2) {
        Map<Integer, Integer> map = new HashMap<>(arr2.length);
        int n = arr2.length;
        for (int i = 0; i < n; ++i) {
            map.put(arr2[i], i);
        }
        return Arrays.stream(arr1).boxed().sorted(comparing(x -> map.getOrDefault(x, x + 1001))).mapToInt(x -> x).toArray();
    }
}
// @lc code=end

