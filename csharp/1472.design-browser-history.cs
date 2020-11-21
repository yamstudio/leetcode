/*
 * @lc app=leetcode id=1472 lang=csharp
 *
 * [1472] Design Browser History
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class BrowserHistory {

    private IList<string> History;
    private int Index;

    public BrowserHistory(string homepage) {
        History = new List<string>() { homepage };
        Index = 0;
    }
    
    public void Visit(string url) {
        ++Index;
        while (History.Count > Index) {
            History.RemoveAt(History.Count - 1);
        }
        History.Add(url);
    }
    
    public string Back(int steps) {
        Index = Math.Max(0, Index - steps);
        return History[Index];
    }
    
    public string Forward(int steps) {
        Index = Math.Min(History.Count - 1, Index + steps);
        return History[Index];
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */
// @lc code=end

