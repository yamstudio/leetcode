/*
 * @lc app=leetcode id=1394 lang=csharp
 *
 * [1394] Find Lucky Integer in an Array
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int FindLucky(int[] arr) {
        return arr
            .GroupBy(x => x, (x, a) => (Value: x, Count: a.Count()))
            .Where(t => t.Value == t.Count)
            .Append((Value: -1, Count: 0))
            .Max(t => t.Value);
    }
}
// @lc code=end

