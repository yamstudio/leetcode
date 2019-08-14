/*
 * @lc app=leetcode id=225 lang=csharp
 *
 * [225] Implement Stack using Queues
 */

using System.Collections.Generic;

public class MyStack {

    private Queue<int> queue1, queue2;

    /** Initialize your data structure here. */
    public MyStack() {
        queue1 = new Queue<int>();
        queue2 = new Queue<int>();
    }
    
    /** Push element x onto stack. */
    public void Push(int x) {
        queue2.Enqueue(x);
        while (queue2.Count > 1) {
            queue1.Enqueue(queue2.Dequeue());
        }
    }
    
    /** Removes the element on top of the stack and returns that element. */
    public int Pop() {
        Top();
        return queue2.Dequeue();
    }
    
    /** Get the top element. */
    public int Top() {
        if (queue2.Count == 0) {
            int size = queue1.Count - 1;
            while (size-- > 0) {
                queue1.Enqueue(queue1.Dequeue());
            }
            queue2.Enqueue(queue1.Dequeue());
        }
        return queue2.Peek();
    }
    
    /** Returns whether the stack is empty. */
    public bool Empty() {
        return queue1.Count == 0 && queue2.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */

