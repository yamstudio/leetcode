/*
 * @lc app=leetcode id=1409 lang=csharp
 *
 * [1409] Queries on a Permutation With Key
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] ProcessQueries(int[] queries, int m) {
        var list = new LinkedList<int>(Enumerable.Range(1, m));
        int k = queries.Length;
        int[] ret = new int[k];
        for (int i = 0; i < k; ++i) {
            int q = queries[i];
            var node = list.First;
            int j = 0;
            while (node.Value != q) {
                node = node.Next;
                ++j;
            }
            ret[i] = j;
            list.Remove(node);
            list.AddFirst(q);
        }
        return ret;
    }
}
// @lc code=end

