import java.util.HashMap;

/**
 * Definition for undirected graph.
 * class UndirectedGraphNode {
 *     int label;
 *     List<UndirectedGraphNode> neighbors;
 *     UndirectedGraphNode(int x) { label = x; neighbors = new ArrayList<UndirectedGraphNode>(); }
 * };
 */
public class Solution {
    public UndirectedGraphNode cloneGraph(UndirectedGraphNode node) {
        HashMap<UndirectedGraphNode, UndirectedGraphNode> hm = new HashMap<UndirectedGraphNode, UndirectedGraphNode>();
        Stack<UndirectedGraphNode> stack = new Stack<UndirectedGraphNode>();
        UndirectedGraphNode curr, clone, neighborClone;
        
        if (node == null)
            return null;
        
        stack.push(node);
        while (! stack.empty()) {
            curr = stack.pop();
            if ((clone = hm.get(curr)) == null) {
                clone = new UndirectedGraphNode(curr.label);
                hm.put(curr, clone);
            }
            
            for (UndirectedGraphNode neighbor : curr.neighbors) {
                if ((neighborClone = hm.get(neighbor)) == null) {
                    neighborClone = new UndirectedGraphNode(neighbor.label);
                    hm.put(neighbor, neighborClone);
                    stack.push(neighbor);
                }
                clone.neighbors.add(neighborClone);
            }
        }
        
        return hm.get(node);
    }
}
