import java.util.ArrayList;
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
    public List<Integer> postorderTraversal(TreeNode root) {
        TreeNode curr, prev = null;
        List<Integer> ret = new ArrayList<Integer>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        
        if (root == null)
            return ret;
        stack.push(root);
        while (! stack.empty()) {
            curr = stack.peek();
            if (prev == null || prev.left == curr || prev.right == curr) {
                if (curr.left != null)
                    stack.push(curr.left);
                else if (curr.right != null)
                    stack.push(curr.right);
                else
                    ret.add(stack.pop().val);
            } else if (prev == curr.left && curr.right != null)
                stack.push(curr.right);
            else
                ret.add(stack.pop().val);
            prev = curr;
        }
        
        return ret;
    }
}
