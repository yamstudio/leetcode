/*
 * @lc app=leetcode id=589 lang=csharp
 *
 * [589] N-ary Tree Preorder Traversal
 */

using System.Collections.Generic;

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node(){}
    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Solution {
    public IList<int> Preorder(Node root) {
        IList<int> ret = new List<int>();
        IList<Node> stack = new List<Node>();
        if (root == null) {
            return ret;
        }
        stack.Add(root);
        while (stack.Count > 0) {
            root = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            ret.Add(root.val);
            int n = root.children.Count;
            for (int i = n - 1; i >= 0; --i) {
                stack.Add(root.children[i]);
            }
        }
        return ret;
    }
}
// @lc code=end

