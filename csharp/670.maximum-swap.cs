/*
 * @lc app=leetcode id=670 lang=csharp
 *
 * [670] Maximum Swap
 */

// @lc code=start
public class Solution {
    public int MaximumSwap(int num) {
        int[] last = new int[10];
        var s = num.ToString().ToCharArray();
        int n = s.Length;
        for (int i = 0; i < n; ++i) {
            last[(int) s[i] - (int) '0'] = i;
        }
        for (int i = 0; i < n; ++i) {
            int curr = (int) s[i] - (int) '0';
            for (int j = 9; j > curr; --j) {
                if (last[j] <= i) {
                    continue;
                }
                s[last[j]] = (char) (curr + (int) '0');
                s[i] = (char) (j + (int) '0');
                return int.Parse((new string(s)));
            }
        }
        return num;
    }
}
// @lc code=end

