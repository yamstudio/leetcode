/*
 * @lc app=leetcode id=869 lang=csharp
 *
 * [869] Reordered Power of 2
 */

// @lc code=start
public class Solution {
    public bool ReorderedPowerOf2(int N) {
        var curr = new int[10];
        int higher = 1, lower, t = 1;
        while (N > 0) {
            ++curr[N % 10];
            N /= 10;
            higher *= 10;
        }
        lower = higher / 10;
        while (t < higher) {
            if (t >= lower) {
                int tmp = t;
                int[] comp = new int[10];
                while (tmp > 0) {
                    int c = tmp % 10;
                    if (++comp[c] > curr[c]) {
                        break;
                    }
                    tmp /= 10;
                }
                if (tmp == 0) {
                    return true;
                }
            }
            t *= 2;
        }
        return false;
    }
}
// @lc code=end

