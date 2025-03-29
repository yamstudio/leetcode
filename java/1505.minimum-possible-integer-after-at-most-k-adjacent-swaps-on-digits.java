/*
 * @lc app=leetcode id=1505 lang=java
 *
 * [1505] Minimum Possible Integer After at Most K Adjacent Swaps On Digits
 */

// @lc code=start
class Solution {
    public String minInteger(String num, int k) {
        char[] arr = num.toCharArray();
        int n = arr.length;
        for (int i = 0; i < n && k > 0; ++i) {
            int minI = i, r = Math.min(i + k + 1, n);
            for (int j = i + 1; j < r; ++j) {
                if (arr[j] < arr[minI]) {
                    minI = j;
                }
            }
            char t = arr[minI];
            for (int j = minI; j > i; --j) {
                arr[j] = arr[j - 1];
            }
            arr[i] = t;
            k -= minI - i;
        }
        return new String(arr);
    }
}
// @lc code=end

