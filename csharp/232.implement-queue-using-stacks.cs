/*
 * @lc app=leetcode id=232 lang=csharp
 *
 * [232] Implement Queue using Stacks
 */

using System.Collections.Generic;

public static class Ext {
    public static void Push<T>(this IList<T> stack, T item) {
        stack.Add(item);
    }

    public static T Pop<T>(this IList<T> stack) {
        T ret = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return ret;
    }

    public static T Peek<T>(this IList<T> stack) {
        return stack[stack.Count - 1];
    }

    public static bool IsEmpty<T>(this IList<T> stack) {
        return stack.Count == 0;
    }
}

public class MyQueue {

    private IList<int> s1, s2;

    /** Initialize your data structure here. */
    public MyQueue() {
        s1 = new List<int>();
        s2 = new List<int>();
    }
    
    private void Reverse() {
        if (!s1.IsEmpty()) {
            return;
        }
        while (!s2.IsEmpty()) {
            s1.Push(s2.Pop());
        }
    }

    /** Push element x to the back of queue. */
    public void Push(int x) {
        s2.Push(x);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        Reverse();
        return s1.Pop();
    }
    
    /** Get the front element. */
    public int Peek() {
        Reverse();
        return s1.Peek();
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() {
        return s1.IsEmpty() && s2.IsEmpty();
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

