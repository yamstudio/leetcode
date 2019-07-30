/*
 * @lc app=leetcode id=146 lang=csharp
 *
 * [146] LRU Cache
 */

using System.Collections.Generic;

public class LRUCache {

    private int Capacity;
    private IDictionary<int, Node> Map;
    private Node Head, Tail;

    public LRUCache(int capacity) {
        Capacity = capacity;
        Map = new Dictionary<int, Node>(capacity);
        Head = null;
        Tail = null;
    }
    
    public int Get(int key) {
        if (!Map.ContainsKey(key)) {
            return -1;
        }
        Node node = Map[key];
        if (node != Head) {
            node.prev.next = node.next;
            if (node != Tail) {
                node.next.prev = node.prev;
            } else {
                Tail = node.prev;
            }
            node.prev = null;
            node.next = Head;
            Head.prev = node;
            Head = node;
        }
        return node.val;
    }
    
    public void Put(int key, int value) {
        Node node;
        if (Map.ContainsKey(key)) {
            node = Map[key];
            node.val = value;
            if (node == Head) {
                return;
            }
            node.prev.next = node.next;
            if (node != Tail) {
                node.next.prev = node.prev;
            } else {
                Tail = node.prev;
            }
        } else {
            if (Map.Count == Capacity) {
                Map.Remove(Tail.key);
                if (Tail.prev != null) {
                    Tail.prev.next = null;
                    Tail = Tail.prev;
                } else {
                    Head = null;
                    Tail = null;
                }
            }
            node = new Node() {
                key = key,
                val = value,
            };
            Map[key] = node;
        }
        node.prev = null;
        node.next = Head;
        if (Head == null) {
            Tail = node;
        } else  {
            Head.prev = node;
        }
        Head = node;
    }

    private class Node {
        public int key { get; set; }
        public int val { get; set; }
        public Node prev { get; set; }
        public Node next { get; set; }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

