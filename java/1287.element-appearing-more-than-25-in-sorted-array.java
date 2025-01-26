/*
 * @lc app=leetcode id=1287 lang=java
 *
 * [1287] Element Appearing More Than 25% In Sorted Array
 */

// @lc code=start
class Solution {
    public int findSpecialInteger(int[] arr) {
        int n = arr.length;
        for (int p = 1; p <= 3; ++p) {
            int i = n * p / 4, num = arr[i], l = n * (p - 1) / 4, r = i;
            while (l < r) {
                int m = (l + r) / 2;
                if (arr[m] > num) {
                    r = m - 1;
                } else if (arr[m] == num) {
                    r = m;
                } else {
                    l = m + 1;
                }
            }
            if (num == arr[l + n / 4]) {
                return num;
            }
        }
        return -1;
    }
}
// @lc code=end

