import java.util.HashSet;
import java.util.ArrayList;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    public List<TreeNode> findDuplicateSubtrees(TreeNode root) {
        List<TreeNode> ret = new ArrayList<TreeNode>();
        
        helper(root, ret, new HashSet<String>(), new HashSet<String>());
        
        return ret;
    }
    
    private String helper(TreeNode root, List<TreeNode> ret, HashSet<String> found, HashSet<String> added) {
        StringBuilder sb;
        String s;
        
        if (root == null)
            return "n#";
        
        sb = new StringBuilder();
        
        sb.append(root.val);
        sb.append('#');
        sb.append(helper(root.left, ret, found, added));
        sb.append(helper(root.right, ret, found, added));
        
        s = sb.toString();
        
        if (found.contains(s)) {
            if (! added.contains(s)) {
                ret.add(root);
                added.add(s);
            }
        } else
            found.add(s);
        
        return s;
    }
}
