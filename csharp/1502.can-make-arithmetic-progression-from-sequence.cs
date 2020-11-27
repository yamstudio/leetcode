/*
 * @lc app=leetcode id=1502 lang=csharp
 *
 * [1502] Can Make Arithmetic Progression From Sequence
 */

// @lc code=start
public class Solution {
    public bool CanMakeArithmeticProgression(int[] arr) {
        int min = int.MaxValue, max = int.MinValue, n = arr.Length;
        foreach (int x in arr) {
            if (x < min) {
                min = x;
            }
            if (x > max) {
                max = x;
            }
        }
        if (min == max) {
            return true;
        }
        int d = max - min;
        if (d % (n - 1) != 0) {
            return false;
        }
        d /= n - 1;
        var seen = new bool[n];
        foreach (int x in arr) {
            if ((x - min) % d != 0) {
                return false;
            }
            int i = (x - min) / d;
            if (seen[i]) {
                return false;
            }
            seen[i] = true;
        }
        return true;
    }
}
// @lc code=end

