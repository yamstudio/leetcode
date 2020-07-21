/*
 * @lc app=leetcode id=950 lang=csharp
 *
 * [950] Reveal Cards In Increasing Order
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck) {
        int n = deck.Length;
        int[] ret = new int[n];
        var queue = new Queue<int>(Enumerable.Range(0, n));
        Array.Sort(deck);
        for (int i = 0; i < n; ++i) {
            int curr = queue.Dequeue();
            ret[curr] = deck[i];
            if (queue.TryDequeue(out int d)) {
                queue.Enqueue(d);
            }
        }
        return ret;
    }
}
// @lc code=end

