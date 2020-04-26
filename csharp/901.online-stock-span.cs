/*
 * @lc app=leetcode id=901 lang=csharp
 *
 * [901] Online Stock Span
 */

using System.Collections.Generic;

// @lc code=start
public class StockSpanner {

    private Stack<(int Value, int Index)> Stack;
    private int Index;

    public StockSpanner() {
        Stack = new Stack<(int Value, int Index)>();
        Stack.Push((Value: int.MaxValue, Index: -1));
        Index = 0;
    }
    
    public int Next(int price) {
        while (Stack.Peek().Value <= price) {
            Stack.Pop();
        }
        int ret = Index - Stack.Peek().Index;
        Stack.Push((Value: price, Index: Index++));
        return ret;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
// @lc code=end

