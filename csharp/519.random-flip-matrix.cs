/*
 * @lc app=leetcode id=519 lang=csharp
 *
 * [519] Random Flip Matrix
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private int Rows, Cols;
    private ISet<int> Flipped;
    private Random Random;

    public Solution(int n_rows, int n_cols) {
        Rows = n_rows;
        Cols = n_cols;
        Flipped = new HashSet<int>();
        Random = new Random();
    }
    
    public int[] Flip() {
        while (true) {
            int rand = Random.Next(0, Rows * Cols);
            if (!Flipped.Contains(rand)) {
                Flipped.Add(rand);
                return new int[] { rand / Cols, rand % Cols };
            }
        }
    }
    
    public void Reset() {
        Flipped.Clear();
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(n_rows, n_cols);
 * int[] param_1 = obj.Flip();
 * obj.Reset();
 */
// @lc code=end

