/*
 * @lc app=leetcode id=832 lang=csharp
 *
 * [832] Flipping an Image
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[][] FlipAndInvertImage(int[][] A) {
        return A.Select(row => row.Select(x => x ^ 1).Reverse().ToArray()).ToArray();
    }
}
// @lc code=end

