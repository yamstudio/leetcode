/*
 * @lc app=leetcode id=894 lang=csharp
 *
 * [894] All Possible Full Binary Trees
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<TreeNode> AllPossibleFBT(int N) {
        var nodes = new IList<TreeNode>[N];
        nodes[0] = new List<TreeNode>()
        {
            new TreeNode(0)
        };
        for (int i = 1; i < N; ++i) {
            nodes[i] = nodes
                .Take(i - 1)
                .SelectMany((leftRoots, j) => leftRoots
                    .SelectMany(leftRoot => nodes[i - j - 2]
                        .Select(rightRoot => {
                            var root = new TreeNode(0);
                            root.left = leftRoot;
                            root.right = rightRoot;
                            return root;
                        })
                    )
                )
                .ToList();
        }
        return nodes[N - 1];
    }
}
// @lc code=end

