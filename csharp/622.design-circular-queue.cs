/*
 * @lc app=leetcode id=622 lang=csharp
 *
 * [622] Design Circular Queue
 */

// @lc code=start
public class MyCircularQueue {

    private int Count, Size, Index;
    private int[] Data;

    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k) {
        Count = 0;
        Size = k;
        Index = 0;
        Data = new int[Size];
    }
    
    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value) {
        if (Size == Count) {
            return false;
        }
        Data[(Index + Count++) % Size] = value;
        return true;
    }
    
    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue() {
        if (Count == 0) {
            return false;
        }
        Index = (Index + 1) % Size;
        --Count;
        return true;
    }
    
    /** Get the front item from the queue. */
    public int Front() {
        if (Count == 0) {
            return -1;
        }
        return Data[Index];
    }
    
    /** Get the last item from the queue. */
    public int Rear() {
        if (Count == 0) {
            return -1;
        }
        return Data[(Index + Count - 1) % Size];
    }
    
    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty() {
        return Count == 0;
    }
    
    /** Checks whether the circular queue is full or not. */
    public bool IsFull() {
        return Count == Size;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */
// @lc code=end

