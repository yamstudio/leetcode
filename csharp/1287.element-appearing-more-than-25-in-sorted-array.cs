/*
 * @lc app=leetcode id=1287 lang=csharp
 *
 * [1287] Element Appearing More Than 25% In Sorted Array
 */

// @lc code=start
public class Solution {
    public int FindSpecialInteger(int[] arr) {
        int n = arr.Length, t = n / 4, i = 0;
        while (i < n) {
            int j = i;
            while (j < n && arr[j] == arr[i]) {
                ++j;
            }
            if (j - i > t) {
                return arr[i];
            }
            i = j;
        }
        return -1;
    }
}
// @lc code=end

