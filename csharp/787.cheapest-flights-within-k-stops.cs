/*
 * @lc app=leetcode id=787 lang=csharp
 *
 * [787] Cheapest Flights Within K Stops
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        var map = new IList<(int City, int Price)>[n];
        int ret = int.MaxValue;
        foreach (var flight in flights) {
            int s = flight[0];
            if (map[s] == null) {
                map[s] = new List<(int City, int Price)>();
            }
            map[s].Add((City: flight[1], Price: flight[2]));
        }
        var queue = new Queue<(int City, int Cost)>();
        queue.Enqueue((City: src, Cost: 0));
        for (int i = -1; i <= K && queue.Count > 0; ++i) {
            for (int j = queue.Count - 1; j >= 0; --j) {
                var curr = queue.Dequeue();
                if (curr.City == dst) {
                    ret = Math.Min(ret, curr.Cost);
                }
                if (map[curr.City] == null) {
                    continue;
                }
                foreach (var flight in map[curr.City]) {
                    if (curr.Cost + flight.Price > ret) {
                        continue;
                    }
                    queue.Enqueue((City: flight.City, Cost: flight.Price + curr.Cost));
                }
            }
        }
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

