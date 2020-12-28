/*
 * @lc app=leetcode id=1640 lang=csharp
 *
 * [1640] Check Array Formation Through Concatenation
 */

// @lc code=start
public class Solution {
    public bool CanFormArray(int[] arr, int[][] pieces) {
        int[] map = new int[101];
        for (int i = arr.Length - 1; i >= 0; --i) {
            map[arr[i]] = i + 1;
        }
        foreach (var piece in pieces) {
            int p = map[piece[0]];
            if (p == 0) {
                return false;
            }
            for (int i = 1; i < piece.Length; ++i) {
                if (map[piece[i]] != p + 1) {
                    return false;
                }
                ++p;
            }
        }
        return true;
    }
}
// @lc code=end

