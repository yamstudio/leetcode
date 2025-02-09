/*
 * @lc app=leetcode id=1346 lang=java
 *
 * [1346] Check If N and Its Double Exist
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public boolean checkIfExist(int[] arr) {
        Set<Integer> seen = new HashSet<>();
        for (int num : arr) {
            if (num % 2 == 0 && seen.contains(num / 2)) {
                return true;
            }
            if (seen.contains(num * 2)) {
                return true;
            }
            seen.add(num);
        }
        return false;
    }
}
// @lc code=end

