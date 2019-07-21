/*
 * @lc app=leetcode id=117 lang=csharp
 *
 * [117] Populating Next Right Pointers in Each Node II
 */
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node(){}
    public Node(int _val,Node _left,Node _right,Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
}
*/
public class Solution {
    public Node Connect(Node root) {
        Node first = root;
        while (first != null) {
            Node curr = first, nextFirst = null, nextCurr = null;
            while (curr != null) {
                if (curr.left != null) {
                    if (nextFirst == null) {
                        nextFirst = curr.left;
                        nextCurr = curr.left;
                    } else {
                        nextCurr.next = curr.left;
                        nextCurr = curr.left;
                    }
                }
                if (curr.right != null) {
                    if (nextFirst == null) {
                        nextFirst = curr.right;
                        nextCurr = curr.right;
                    } else {
                        nextCurr.next = curr.right;
                        nextCurr = curr.right;
                    }
                }
                curr = curr.next;
            }
            first = nextFirst;
        }
        return root;
    }
}

