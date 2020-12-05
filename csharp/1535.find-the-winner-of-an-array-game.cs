/*
 * @lc app=leetcode id=1535 lang=csharp
 *
 * [1535] Find the Winner of an Array Game
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int GetWinner(int[] arr, int k) {
        int max = arr[0], count = 0;
        foreach (var x in arr.Skip(1)) {
            if (x > max) {
                count = 0;
                max = x;
            }
            if (++count == k) {
                break;
            }
        }
        return max;
    }
}
// @lc code=end

