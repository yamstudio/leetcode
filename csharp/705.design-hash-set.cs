/*
 * @lc app=leetcode id=705 lang=csharp
 *
 * [705] Design HashSet
 */

// @lc code=start
public class MyHashSet {

    private class Node {
        public bool IsEnd { get; set; }
        public Node[] Children { get; }

        public Node() {
            IsEnd = false;
            Children = new Node[10];
        }
    }

    private Node Root;

    /** Initialize your data structure here. */
    public MyHashSet() {
        Root = new Node();
    }
    
    public void Add(int key) {
        Node curr = Root;
        while (key > 0) {
            int r = key % 10;
            key /= 10;
            if (curr.Children[r] == null) {
                curr.Children[r] = new Node();
            }
            curr = curr.Children[r];
        }
        curr.IsEnd = true;
    }
    
    public void Remove(int key) {
        Node curr = Root;
        while (key > 0) {
            if (curr == null) {
                return;
            }
            curr = curr.Children[key % 10];
            key /= 10;
        }
        if (curr != null) {
            curr.IsEnd = false;
        }
    }
    
    /** Returns true if this set contains the specified element */
    public bool Contains(int key) {
        Node curr = Root;
        while (key > 0) {
            if (curr == null) {
                return false;
            }
            curr = curr.Children[key % 10];
            key /= 10;
        }
        return curr != null && curr.IsEnd;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
// @lc code=end

