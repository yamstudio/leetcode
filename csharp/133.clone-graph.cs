/*
 * @lc app=leetcode id=133 lang=csharp
 *
 * [133] Clone Graph
 */
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node(){}
    public Node(int _val,IList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
}
*/

using System.Collections.Generic;

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) {
            return null;
        }
        IDictionary<Node, Node> map = new Dictionary<Node, Node>();
        Queue<Node> queue = new Queue<Node>();
        Node ret = new Node(node.val, new List<Node>(node.neighbors.Count));
        map[node] = ret;
        queue.Enqueue(node);
        while (queue.Count > 0) {
            Node curr = queue.Dequeue(), copy = map[curr];
            foreach (Node neighbor in curr.neighbors) {
                Node neighborCopy;
                if (map.ContainsKey(neighbor)) {
                    neighborCopy = map[neighbor];
                } else {
                    neighborCopy = new Node(neighbor.val, new List<Node>(neighbor.neighbors.Count));
                    map[neighbor] = neighborCopy;
                    queue.Enqueue(neighbor);
                }
                copy.neighbors.Add(neighborCopy);
            }
        }
        return ret;
    }
}

