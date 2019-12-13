/*
 * @lc app=leetcode id=747 lang=csharp
 *
 * [747] Largest Number At Least Twice of Others
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int DominantIndex(int[] nums) {
        return nums
            .Select((num, index) => (Num: num, Index: index))
            .Aggregate(
                (Max: 0, Index: -1, Second: 0),
                (acc, curr) => curr.Num > acc.Max ? (Max: curr.Num, Index: curr.Index, Second: acc.Max) : (curr.Num > acc.Second ? (Max: acc.Max, Index: acc.Index, Second: curr.Num) : acc),
                ret => ret.Max >= 2 * ret.Second ? ret.Index : -1
            );
    }
}
// @lc code=end

