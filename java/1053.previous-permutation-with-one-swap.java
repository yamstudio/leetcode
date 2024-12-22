/*
 * @lc app=leetcode id=1053 lang=java
 *
 * [1053] Previous Permutation With One Swap
 */

// @lc code=start
class Solution {
    public int[] prevPermOpt1(int[] arr) {
        int n = arr.length, r;
        for (r = n - 1; r > 0 && arr[r] >= arr[r - 1]; --r);
        if (r == 0) {
            return arr;
        }
        int mv = arr[r - 1], s = r;
        for (int i = r + 1; i < n; ++i) {
            if (arr[i] > arr[i - 1] && arr[i] < mv) {
                s = i;
            }
        }
        arr[r - 1] = arr[s];
        arr[s] = mv;
        return arr;
    }
}
// @lc code=end

