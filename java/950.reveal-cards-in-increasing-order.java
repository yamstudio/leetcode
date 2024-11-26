/*
 * @lc app=leetcode id=950 lang=java
 *
 * [950] Reveal Cards In Increasing Order
 */

import java.util.Arrays;
import java.util.LinkedList;

// @lc code=start

class Solution {
    public int[] deckRevealedIncreasing(int[] deck) {
        int n = deck.length;
        int[] indices = new int[n];
        int i = 0;
        LinkedList<Integer> list = new LinkedList<>();
        for (int j = 0; j < n; ++j) {
            list.addLast(j);
        }
        while (!list.isEmpty()) {
            indices[i++] = list.removeFirst();
            if (!list.isEmpty()) {
                list.addLast(list.removeFirst());
            }
        }
        int[] sorted = Arrays.stream(deck).sorted().toArray();
        int[] ret = new int[n];
        for (int j = 0; j < n; ++j) {
            ret[indices[j]] = sorted[j];
        }
        return ret;
    }
}
// @lc code=end

