/*
 * @lc app=leetcode id=335 lang=csharp
 *
 * [335] Self Crossing
 */
public class Solution {
    public bool IsSelfCrossing(int[] x) {
        int n = x.Length;
        for (int i = 3; i < n; ++i) {
            if (x[i] >= x[i - 2] && x[i - 1] <= x[i - 3]) {
                return true;
            }
            if (i >= 4 && x[i] + x[i - 4] >= x[i - 2] && x[i - 1] == x[i - 3]) {
                return true;
            }
            if (i >= 5 && x[i] + x[i - 4] >= x[i - 2] && x[i - 1] + x[i - 5] >= x[i - 3] && x[i - 2] >= x[i - 4] && x[i - 3] >= x[i - 1]) {
                return true;
            }
        }
        return false;
    }
}

