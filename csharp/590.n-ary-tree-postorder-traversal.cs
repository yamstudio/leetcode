/*
 * @lc app=leetcode id=590 lang=csharp
 *
 * [590] N-ary Tree Postorder Traversal
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
    public IList<int> Postorder(Node root) {
        IList<Node> stack = new List<Node>();
        LinkedList<int> ret = new LinkedList<int>();
        if (root == null) {
            return new List<int>();
        }
        stack.Add(root);
        while (stack.Count > 0) {
            root = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            ret.AddFirst(root.val);
            foreach (var child in root.children) {
                stack.Add(child);
            }
        }
        return new List<int>(ret);
    }
}
// @lc code=end

