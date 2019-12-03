/*
 * @lc app=leetcode id=706 lang=csharp
 *
 * [706] Design HashMap
 */

// @lc code=start
public class MyHashMap {

    private class Node {
        public int Value { get; set; }
        public Node[] Children { get; }

        public Node() {
            Value = -1;
            Children = new Node[10];
        }
    }

    private Node Root;

    /** Initialize your data structure here. */
    public MyHashMap() {
        Root = new Node();
    }
    
    /** value will always be non-negative. */
    public void Put(int key, int value) {
        Node curr = Root;
        while (key > 0) {
            int r = key % 10;
            key /= 10;
            if (curr.Children[r] == null) {
                curr.Children[r] = new Node();
            }
            curr = curr.Children[r];
        }
        curr.Value = value;
    }
    
    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key) {
        Node curr = Root;
        while (key > 0) {
            if (curr == null) {
                return -1;
            }
            curr = curr.Children[key % 10];
            key /= 10;
        }
        return curr == null ? -1 : curr.Value;
    }
    
    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
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
            curr.Value = -1;
        }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
// @lc code=end

