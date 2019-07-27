/*
 * @lc app=leetcode id=138 lang=csharp
 *
 * [138] Copy List with Random Pointer
 */
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(){}
    public Node(int _val,Node _next,Node _random) {
        val = _val;
        next = _next;
        random = _random;
}
*/

using System.Collections.Generic;

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null) {
            return null;
        }
        IDictionary<Node, Node> map = new Dictionary<Node, Node>();
        Node ret = new Node(head.val, null, null);
        Queue<Node> queue = new Queue<Node>();
        map[head] = ret;
        queue.Enqueue(head);
        while (queue.Count != 0) {
            Node curr = queue.Dequeue(), next = curr.next, random = curr.random, currCopy = map[curr], nextCopy = null, randomCopy = null;
            if (next != null) {
                if (map.ContainsKey(next)) {
                    nextCopy = map[next];
                } else {
                    nextCopy = new Node(next.val, null, null);
                    map[next] = nextCopy;
                    queue.Enqueue(next);
                }
            }
            if (random != null) {
                if (map.ContainsKey(random)) {
                    randomCopy = map[random];
                } else {
                    randomCopy = new Node(random.val, null, null);
                    map[random] = randomCopy;
                    queue.Enqueue(random);
                }
            }
            currCopy.next = nextCopy;
            currCopy.random = randomCopy;
        }
        return ret;
    }
}

