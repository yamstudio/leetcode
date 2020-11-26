/*
 * @lc app=leetcode id=1497 lang=csharp
 *
 * [1497] Check If Array Pairs Are Divisible by k
 */

// @lc code=start
public class Solution {
    public bool CanArrange(int[] arr, int k) {
        var count = new int[k];
        foreach (int x in arr) {
            ++count[(x % k + k) % k];
        }
        if (count[0] % 2 != 0 || k % 2 == 0 && count[k / 2] % 2 != 0) {
            return false;
        }
        for (int x = (k - 1) / 2; x > 0; --x) {
            if (count[x] != count[k - x]) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

