/*
 * @lc app=leetcode id=1282 lang=csharp
 *
 * [1282] Group the People Given the Group Size They Belong To
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<IList<int>> GroupThePeople(int[] groupSizes) {
        return groupSizes
            .Select((int size, int index) => (Index: index, Size: size))
            .GroupBy(t => t.Size, (int size, IEnumerable<(int Index, int Size)> all) => all
                .Select(((int Index, int Size) curr, int index) => (Index: curr.Index, GroupIndex: index))
                .GroupBy<(int Index, int GroupIndex), int, IList<int>>(t => t.GroupIndex / size, (int index, IEnumerable<(int Index, int GroupIndex)> group) => group
                    .Select(t => t.Index)
                    .ToList()
                )
            )
            .SelectMany(g => g)
            .ToList();
    }
}
// @lc code=end

