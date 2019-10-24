/*
 * @lc app=leetcode id=559 lang=csharp
 *
 * [559] Maximum Depth of N-ary Tree
 */

using System.Linq;

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
*/
public class Solution {
    public int MaxDepth(Node root) {
        if (root == null) {
            return 0;
        }
        return 1 + root.children.Select(child => MaxDepth(child)).DefaultIfEmpty(0).Max();
    }
}
// @lc code=end

