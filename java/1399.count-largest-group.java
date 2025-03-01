/*
 * @lc app=leetcode id=1399 lang=java
 *
 * [1399] Count Largest Group
 */

// @lc code=start
class Solution {
    public int countLargestGroup(int n) {
        int k = 1, t = n;
        while (t > 0) {
            k += 9;
            t /= 10;
        }
        int[] count = new int[k];
        for (int i = 1; i <= n; ++i) {
            t = i;
            int sum = 0;
            while (t > 0) {
                sum += t % 10;
                t /= 10;
            }
            ++count[sum];
        }
        int ret = -1, max = -1;
        for (int i = 1; i < k; ++i) {
            if (count[i] == max) {
                ++ret;
            } else if (count[i] > max) {
                max = count[i];
                ret = 1;
            }
        }
        return ret;
    }
}
// @lc code=end

