/*
 * @lc app=leetcode id=155 lang=csharp
 *
 * [155] Min Stack
 */

using System.Collections.Generic;

public class MinStack {

    private List<int> elements;
    private List<int> minElements;

    /** initialize your data structure here. */
    public MinStack() {
        elements = new List<int>();
        minElements = new List<int>();
    }
    
    public void Push(int x) {
        elements.Add(x);
        minElements.Add(minElements.Count > 0 ? Math.Min(x, minElements[minElements.Count - 1]) : x);
    }
    
    public void Pop() {
        elements.RemoveAt(elements.Count - 1);
        minElements.RemoveAt(minElements.Count - 1);
    }
    
    public int Top() {
        return elements[elements.Count - 1];
    }
    
    public int GetMin() {
        return minElements[minElements.Count - 1];
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

