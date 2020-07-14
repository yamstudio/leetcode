/*
 * @lc app=leetcode id=933 lang=csharp
 *
 * [933] Number of Recent Calls
 */

using System.Collections.Generic;

// @lc code=start
public class RecentCounter {

    private Queue<int> Queue;

    public RecentCounter() {
        Queue = new Queue<int>();
    }
    
    public int Ping(int t) {
        Queue.Enqueue(t);
        while (Queue.Peek() < t - 3000) {
            Queue.Dequeue();
        }
        return Queue.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */
// @lc code=end

