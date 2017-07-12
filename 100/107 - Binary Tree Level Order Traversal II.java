import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;

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
    public List<List<Integer>> levelOrderBottom(TreeNode root) {
        Queue<TreeNode> curr = new LinkedList<TreeNode>(), children = new LinkedList<TreeNode>(), temp;
        TreeNode node;
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        List<Integer> vals;
        
        children.add(root);
        while (children.peek() != null) {
            temp = curr;
            curr = children;
            children = temp;
            vals = new ArrayList<Integer>();
            while (! curr.isEmpty()) {
                node = curr.poll();
                vals.add(node.val);
                if (node.left != null)
                    children.add(node.left);
                if (node.right != null)
                    children.add(node.right);
            }
            ret.add(0, vals);
        }
        
        return ret;
    }
}
