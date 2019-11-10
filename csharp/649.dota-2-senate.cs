/*
 * @lc app=leetcode id=649 lang=csharp
 *
 * [649] Dota2 Senate
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public string PredictPartyVictory(string senate) {
        Queue<int> r = new Queue<int>(), d = new Queue<int>();
        int n = senate.Length;
        for (int i = 0; i < n; ++i) {
            if (senate[i] == 'R') {
                r.Enqueue(i);
            } else {
                d.Enqueue(i);
            }
        }

        while (r.Count > 0 && d.Count > 0) {
            int ir = r.Dequeue(), id = d.Dequeue();
            if (ir < id) {
                r.Enqueue(ir + n);
            } else {
                d.Enqueue(id + n);
            }
        }
        return r.Count > d.Count ? "Radiant" : "Dire";
    }
}
// @lc code=end

