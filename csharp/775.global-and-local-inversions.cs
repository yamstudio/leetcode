/*
 * @lc app=leetcode id=775 lang=csharp
 *
 * [775] Global and Local Inversions
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public bool IsIdealPermutation(int[] A) {
        return A.Select((x, i) => (x, i)).All(tuple => Math.Abs(tuple.x - tuple.i) <= 1);
    }
}
// @lc code=end

