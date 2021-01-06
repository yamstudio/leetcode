/*
 * @lc app=leetcode id=1670 lang=csharp
 *
 * [1670] Design Front Middle Back Queue
 */

using System.Collections.Generic;

// @lc code=start
public class FrontMiddleBackQueue {

    private LinkedList<int> Left, Right;

    public FrontMiddleBackQueue() {
        Left = new LinkedList<int>();
        Right = new LinkedList<int>();
    }

    private void Balance() {
        while (Left.Count > Right.Count) {
            Right.AddFirst(Left.Last.Value);
            Left.RemoveLast();
        }
        while (Right.Count > Left.Count + 1) {
            Left.AddLast(Right.First.Value);
            Right.RemoveFirst();
        }
    }
    
    public void PushFront(int val) {
        Left.AddFirst(val);
        Balance();
    }
    
    public void PushMiddle(int val) {
        Left.AddLast(val);
        Balance();
    }
    
    public void PushBack(int val) {
        Right.AddLast(val);
        Balance();
    }
    
    public int PopFront() {
        int ret = -1;
        if (Left.Count == 0) {
            if (Right.Count == 0) {
                return -1;
            }
            ret = Right.First.Value;
            Right.RemoveFirst();
        } else {
            ret = Left.First.Value;
            Left.RemoveFirst();
        }
        Balance();
        return ret;
    }
    
    public int PopMiddle() {
        int ret = -1;
        if (Left.Count == 0 && Right.Count == 0) {
            return -1;
        }
        if (Left.Count == Right.Count) {
            ret = Left.Last.Value;
            Left.RemoveLast();
        } else {
            ret = Right.First.Value;
            Right.RemoveFirst();
        }
        Balance();
        return ret;
    }
    
    public int PopBack() {
        if (Right.Count == 0) {
            return -1;
        }
        int ret = Right.Last.Value;
        Right.RemoveLast();
        Balance();
        return ret;
    }
}

/**
 * Your FrontMiddleBackQueue object will be instantiated and called as such:
 * FrontMiddleBackQueue obj = new FrontMiddleBackQueue();
 * obj.PushFront(val);
 * obj.PushMiddle(val);
 * obj.PushBack(val);
 * int param_4 = obj.PopFront();
 * int param_5 = obj.PopMiddle();
 * int param_6 = obj.PopBack();
 */
// @lc code=end

