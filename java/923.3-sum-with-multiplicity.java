/*
 * @lc app=leetcode id=923 lang=java
 *
 * [923] 3Sum With Multiplicity
 */

// @lc code=start
class Solution {
    public int threeSumMulti(int[] arr, int target) {
        Map<Integer, Integer> count = new HashMap<Integer, Integer>();
        int n = arr.length, ret = 0;
        for (int i = 0; i < n; ++i) {
            ret = (ret + count.getOrDefault(target - arr[i], 0)) % 1000000007;
            for (int j = 0; j < i; ++j) {
                int sum = arr[i] + arr[j];
                count.put(sum, 1 + count.getOrDefault(sum, 0));
            }
        }
        return ret;
    }
}
// @lc code=end

