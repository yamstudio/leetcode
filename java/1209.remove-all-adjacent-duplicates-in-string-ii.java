/*
 * @lc app=leetcode id=1209 lang=java
 *
 * [1209] Remove All Adjacent Duplicates in String II
 */

import java.util.ArrayDeque;

// @lc code=start

class Solution {
    public String removeDuplicates(String s, int k) {
        ArrayDeque<Pair> deque = new ArrayDeque<>();
        deque.offerLast(new Pair('\n', 0));
        int n = s.length(), l = n;
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            Pair last = deque.getLast();
            if (last.c() == c) {
                int newCount = last.count() + 1;
                deque.removeLast();
                if (newCount == k) {
                    l -= k;
                } else {
                    deque.offerLast(new Pair(c, newCount));
                }
            } else {
                deque.offerLast(new Pair(c, 1));
            }
        }
        StringBuilder sb = new StringBuilder(l);
        for (Pair p : deque) {
            for (int i = 0; i < p.count(); ++i) {
                sb.append(p.c());
            }
        }
        return sb.toString();
    }

    private record Pair(char c, int count) {}
}
// @lc code=end

