/*
 * @lc app=leetcode id=945 lang=java
 *
 * [945] Minimum Increment to Make Array Unique
 */

 import java.util.Arrays;
import java.util.List;

 // @lc code=start

class Solution {
    public int minIncrementForUnique(int[] nums) {
        List<Integer> sorted = Arrays.stream(nums).boxed().sorted().toList();
        int prev = sorted.get(0);
        int ret = 0;
        for (int i = 1; i < nums.length; ++i) {
            int curr = sorted.get(i);
            if (curr <= prev) {
                ret += 1 + (prev - curr);
                prev++;
            } else {
                prev = curr;
            }
        }
        return ret;
    }
}
// @lc code=end

