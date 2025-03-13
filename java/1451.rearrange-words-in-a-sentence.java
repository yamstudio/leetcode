/*
 * @lc app=leetcode id=1451 lang=java
 *
 * [1451] Rearrange Words in a Sentence
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public String arrangeWords(String text) {
        String[] split = text.split(" ");
        int n = split.length;
        Pair[] sorted = new Pair[n];
        sorted[0] = new Pair(split[0].toLowerCase(), 0);
        for (int i = 1; i < n; ++i) {
            sorted[i] = new Pair(split[i], i);
        }
        Arrays.sort(sorted, java.util.Comparator.comparing((Pair p) -> p.s().length()).thenComparingInt(Pair::i));
        StringBuilder sb = new StringBuilder(text.length());
        sb.append(Character.toUpperCase(sorted[0].s().charAt(0)));
        sb.append(sorted[0].s().substring(1));
        for (int i = 1; i < n; ++i) {
            sb.append(' ');
            sb.append(sorted[i].s());
        }
        return sb.toString();
    }

    private record Pair(String s, int i) {}
}
// @lc code=end

