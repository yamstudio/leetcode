/*
 * @lc app=leetcode id=1530 lang=csharp
 *
 * [1530] Number of Good Leaf Nodes Pairs
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private static readonly int[] Sentinel = new int[11];

    private static int[] CountPairs(TreeNode root, int distance, ref int count) {
        if (root == null) {
            return Sentinel;
        }
        var ret = new int[distance + 1];
        if (root.left == null && root.right == null) {
            ret[1] = 1;
            return ret;
        }
        int[] l = CountPairs(root.left, distance, ref count), r = CountPairs(root.right, distance, ref count);
        for (int i = 1; i < distance; ++i) {
            for (int j = 1; j + i <= distance; ++j) {
                count += l[i] * r[j];
            }
        }
        for (int i = 2; i <= distance; ++i) {
            ret[i] = l[i - 1] + r[i - 1];
        }
        return ret;
    }

    public int CountPairs(TreeNode root, int distance) {
        int ret = 0;
        CountPairs(root, distance, ref ret);
        return ret;
    }
}
// @lc code=end

