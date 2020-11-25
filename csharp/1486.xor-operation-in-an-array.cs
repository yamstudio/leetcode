/*
 * @lc app=leetcode id=1486 lang=csharp
 *
 * [1486] XOR Operation in an Array
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int XorOperation(int n, int start) {
        return Enumerable
            .Range(0, n)
            .Select(i => start + 2 * i)
            .Aggregate((acc, x) => acc ^ x);
    }
}
// @lc code=end

