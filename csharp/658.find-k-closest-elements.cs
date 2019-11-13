/*
 * @lc app=leetcode id=658 lang=csharp
 *
 * [658] Find K Closest Elements
 */

using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        int n = arr.Length, l = 0, r = n - 1;
        while (l < r) {
            int m = (l + r) / 2;
            if (arr[m] < x) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        if (l > 0 && Math.Abs(arr[l - 1] - x) <= Math.Abs(arr[l] - x)) {
            --l;
            --r;
        }
        while (l > 0 && r < n - 1 && r - l + 1 < k) {
            if (Math.Abs(arr[l - 1] - x) <= Math.Abs(arr[r + 1] - x)) {
                --l;
            } else {
                ++r;
            }
        }
        if (l == 0) {
            return arr.Take(k).ToArray();
        }
        if (r == n - 1) {
            return arr.Skip(n - k).Take(k).ToArray();
        }
        return arr.Skip(l).Take(k).ToArray();
    }
}
// @lc code=end

