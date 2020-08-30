/*
 * @lc app=leetcode id=1104 lang=csharp
 *
 * [1104] Path In Zigzag Labelled Binary Tree
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> PathInZigZagTree(int label) {
        int acc = 2;
        while (acc <= label) {
            acc *= 2;
        }
        var ret = new Stack<int>();
        while (label >= 1) {
            ret.Push(label);
            int half = acc / 2;
            label = half - (1 + (label - half) / 2);
            acc = half;
        }
        return ret.ToList();
    }
}
// @lc code=end

