/*
 * @lc app=leetcode id=982 lang=java
 *
 * [982] Triples with Bitwise AND Equal To Zero
 */

import java.util.HashMap;

// @lc code=start

class Solution {
    public int countTriplets(int[] nums) {
        var combo = new HashMap<Integer, Integer>();
        for (int x : nums) {
            for (int y : nums) {
                combo.put(x & y, combo.getOrDefault(x & y, 0) + 1);
            }
        }
        int ret = 0;
        for (int z : nums) {
            for (var c : combo.entrySet()) {
                if ((z & c.getKey()) == 0) {
                    ret += c.getValue();
                }
            }
        }
        return ret;
    }
}
// @lc code=end

