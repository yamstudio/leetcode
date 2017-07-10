import java.util.Stack;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public boolean isValidBST(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr;
        int prev = 0;
        boolean flag = false;
        
        curr = root;
        while (curr != null || ! stack.empty()) {
            while (curr != null) {
                stack.push(curr);
                curr = curr.left;
            }
            curr = stack.pop();
            if (flag) {
                if (curr.val <= prev)
                    return false;
            } else
                flag = true;
            prev = curr.val;
            curr = curr.right;
        }
        
        return true;
    }
}
