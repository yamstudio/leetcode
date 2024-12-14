/*
 * @lc app=leetcode id=1013 lang=java
 *
 * [1013] Partition Array Into Three Parts With Equal Sum
 */

// @lc code=start
class Solution {
    public boolean canThreePartsEqualSum(int[] arr) {
        int sum = 0;
        for (int num : arr) {
            sum += num;
        }
        if (sum % 3 != 0) {
            return false;
        }
        int acc = 0, n = arr.length - 1;
        boolean first = false;
        for (int i = 0; i < n; ++i) {
            acc += arr[i];
            if (!first) {
                first = acc == sum / 3;
                continue;
            }
            if (acc == sum / 3 * 2) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

