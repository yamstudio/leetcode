import java.util.ArrayList;
import java.util.Deque;
import java.util.LinkedList;

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
    public List<List<Integer>> zigzagLevelOrder(TreeNode root) {
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        List<Integer> vals;
        TreeNode curr;
        Deque<TreeNode> parent = new LinkedList<TreeNode>(), children = new LinkedList<TreeNode>(), temp;
        boolean fromLeft = true;
        
        children.add(root);
        while (children.peek() != null) {
            vals = new ArrayList<Integer>();
            temp = parent;
            parent = children;
            children = temp;
            
            while (! parent.isEmpty()) {
                if (fromLeft) {
                    curr = parent.poll();
                    if (curr.left != null)
                        children.push(curr.left);
                    if (curr.right != null)
                        children.push(curr.right);
                } else  {
                    curr = parent.pop();
                    if (curr.right != null)
                        children.addFirst(curr.right);
                    if (curr.left != null)
                        children.addFirst(curr.left);
                }
                vals.add(curr.val);
            }
            
            ret.add(vals);
            fromLeft = ! fromLeft;
        }
        
        return ret;
    }
}
