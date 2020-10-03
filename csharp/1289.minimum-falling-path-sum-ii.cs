/*
 * @lc app=leetcode id=1289 lang=csharp
 *
 * [1289] Minimum Falling Path Sum II
 */

// @lc code=start
public class Solution {
    public int MinFallingPathSum(int[][] arr) {
        int n = arr.Length;
        (int Value, int Index) min = (Value: 0, Index: -1), min2 = (Value: 0, Index: -1);
        int[] tmp = new int[n];
        foreach (var row in arr) {
            for (int i = 0; i < n; ++i) {
                if (i == min.Index) {
                    tmp[i] = row[i] + min2.Value;
                } else {
                    tmp[i] = row[i] + min.Value;
                }
            }
            min = (Value: 0, Index: -1);
            min2 = (Value: 0, Index: -1);
            for (int i = 0; i < n; ++i) {
                if (min.Index == -1 || min.Value >= tmp[i]) {
                    min2 = min;
                    min = (Value: tmp[i], Index: i);
                } else if (min2.Index == -1 || min2.Value > tmp[i]) {
                    min2 = (Value: tmp[i], Index: i);
                }
            }
        }
        return min.Value;
    }
}
// @lc code=end

