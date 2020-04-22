/*
 * @lc app=leetcode id=889 lang=csharp
 *
 * [889] Construct Binary Tree from Preorder and Postorder Traversal
 */

using System.Collections.Generic;

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

    private static TreeNode ConstructFromPrePostRecurse(int[] pre, int[] post, int l, int r, int len, IDictionary<int, int> map) {
        if (len == 0) {
            return null;
        }
        var ret = new TreeNode(pre[l]);
        if (len > 1) {
            int ri = map[pre[l + 1]];
            ret.left = ConstructFromPrePostRecurse(pre, post, l + 1, r, ri - r + 1, map);
            ret.right = ConstructFromPrePostRecurse(pre, post, l + 2 + ri - r, ri + 1, len + r - ri - 2, map);
        }
        return ret;
    }

    public TreeNode ConstructFromPrePost(int[] pre, int[] post) {
        var map = new Dictionary<int, int>();
        int n = pre.Length;
        for (int i = 0; i < n; ++i) {
            map[post[i]] = i;
        }
        return ConstructFromPrePostRecurse(pre, post, 0, 0, n, map);
    }
}
// @lc code=end

