/*
 * @lc app=leetcode id=1441 lang=java
 *
 * [1441] Build an Array With Stack Operations
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<String> buildArray(int[] target, int n) {
        List<String> ret = new ArrayList<>();
        int prev = 0;
        for (int num : target) {
            int diff = num - prev - 1;
            while (diff-- > 0) {
                ret.add("Push");
                ret.add("Pop");
            }
            ret.add("Push");
            prev = num;
        }
        return ret;
    }
}
// @lc code=end

