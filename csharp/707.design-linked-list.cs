/*
 * @lc app=leetcode id=707 lang=csharp
 *
 * [707] Design Linked List
 */

// @lc code=start
public class MyLinkedList {

    private class Node {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node() {
            Value = -1;
            Next = null;
        }
    }

    private Node Head;
    private int Length;

    /** Initialize your data structure here. */
    public MyLinkedList() {
        Head = new Node();
        Length = 0;
    }

    private bool GetNode(int i, out Node ret) {
        if (i >= Length || i < -1) {
            ret = null;
            return false;;
        }
        ret = Head;
        while (i-- > -1) {
            ret = ret.Next;
        }
        return true;
    }
    
    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index) {
        if (GetNode(index, out Node ret)) {
            return ret.Value;
        }
        return -1;
    }
    
    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val) {
        AddAtIndex(0, val);
    }
    
    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val) {
        AddAtIndex(Length, val);
    }
    
    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val) {
        if (GetNode(index - 1, out Node prev)) {
            prev.Next = new Node {
                Value = val,
                Next = prev.Next
            };
            ++Length;
        }
    }
    
    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index) {
        if (index < Length && GetNode(index - 1, out Node prev)) {
            prev.Next = prev.Next.Next;
            --Length;
        }
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
// @lc code=end

