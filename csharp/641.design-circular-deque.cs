/*
 * @lc app=leetcode id=641 lang=csharp
 *
 * [641] Design Circular Deque
 */

// @lc code=start
public class MyCircularDeque {

    private int[] Data;
    private int Size, Index, Count;

    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k) {
        Data = new int[k];
        Size = k;
        Index = 0;
        Count = 0;
    }
    
    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public bool InsertFront(int value) {
        if (Count == Size) {
            return false;
        }
        ++Count;
        Index = (Index + Size - 1) % Size;
        Data[Index] = value;
        return true;
    }
    
    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public bool InsertLast(int value) {
        if (Count == Size) {
            return false;
        }
        ++Count;
        Data[(Index + Count - 1) % Size] = value;
        return true;
    }
    
    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public bool DeleteFront() {
        if (Count == 0) {
            return false;
        }
        Index = (Index + 1) % Size;
        --Count;
        return true;
    }
    
    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public bool DeleteLast() {
        if (Count == 0) {
            return false;
        }
        --Count;
        return true;
    }
    
    /** Get the front item from the deque. */
    public int GetFront() {
        if (Count == 0) {
            return -1;
        }
        return Data[Index];
    }
    
    /** Get the last item from the deque. */
    public int GetRear() {
        if (Count == 0) {
            return -1;
        }
        return Data[(Index + Count - 1) % Size];
    }
    
    /** Checks whether the circular deque is empty or not. */
    public bool IsEmpty() {
        return Count == 0;
    }
    
    /** Checks whether the circular deque is full or not. */
    public bool IsFull() {
        return Count == Size;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */
// @lc code=end

