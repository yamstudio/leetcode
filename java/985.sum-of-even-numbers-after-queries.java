/*
 * @lc app=leetcode id=985 lang=java
 *
 * [985] Sum of Even Numbers After Queries
 */

// @lc code=start
class Solution {
    public int[] sumEvenAfterQueries(int[] nums, int[][] queries) {
        int e = 0;
        for (int num : nums) {
            if (num % 2 == 0) {
                e += num;
            }
        }
        int n = queries.length;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            int[] query = queries[i];
            int j = query[1], o = nums[j], v = query[0];
            if (o % 2 == 0) {
                if (v % 2 == 0) {
                    e += v;
                } else {
                    e -= o;
                }
            } else {
                if (v % 2 != 0) {
                    e += v + o;
                }
            }
            nums[j] += v;
            ret[i] = e;
        }
        return ret;
    }
}
// @lc code=end

