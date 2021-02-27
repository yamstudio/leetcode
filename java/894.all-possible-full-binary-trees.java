/*
 * @lc app=leetcode id=894 lang=java
 *
 * [894] All Possible Full Binary Trees
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    public List<TreeNode> allPossibleFBT(int N) {
        List<TreeNode>[] all = new List[N + 1];
        all[0] = new ArrayList<TreeNode>();
        all[1] = new ArrayList<TreeNode>();
        all[1].add(new TreeNode());
        for (int i = 2; i <= N; ++i) {
            all[i] = new ArrayList<TreeNode>();
            for (int l = 1; l + 2 <= i; ++l) {
                for (TreeNode left : all[l]) {
                    for (TreeNode right : all[i - 1 - l]) {
                        all[i].add(new TreeNode(0, left, right));
                    }
                }
            }
        }
        return all[N];
    }
}
// @lc code=end

