/*
 * @lc app=leetcode id=846 lang=csharp
 *
 * [846] Hand of Straights
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool IsNStraightHand(int[] hand, int W) {
        int count = hand.Length;
        if (count % W != 0) {
            return false;
        }
        count /= W;
        var sorted = new SortedList<int, int>();
        foreach (var card in hand) {
            if (sorted.TryGetValue(card, out var val)) {
                sorted[card] = val + 1;
            } else {
                sorted[card] = 1;
            }
        }
        while (count-- > 0) {
            var min = sorted.Keys[0];
            for (int i = 0; i < W; ++i) {
                var card = min + i;
                if (sorted.TryGetValue(card, out var val)) {
                    if (val == 1) {
                        sorted.Remove(card);
                    } else {
                        sorted[card]--;
                    }
                } else {
                    return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

