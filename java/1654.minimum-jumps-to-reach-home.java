/*
 * @lc app=leetcode id=1654 lang=java
 *
 * [1654] Minimum Jumps to Reach Home
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start

class Solution {
    public int minimumJumps(int[] forbidden, int a, int b, int x) {
        int gcd = gcd(a, b);
        if (x % gcd != 0) {
            return -1;
        }
        int ret = 0;
        boolean[] forbiddenB = new boolean[2001];
        for (int f : forbidden) {
            forbiddenB[f] = true;
        }
        boolean[][] visited = new boolean[10001][2];
        Queue<Pair> queue = new ArrayDeque<>();
        queue.offer(new Pair(0, true));
        while (!queue.isEmpty()) {
            int k = queue.size();
            while (k-- > 0) {
                Pair p = queue.poll();
                if (p.curr() == x) {
                    return ret;
                }
                int f = p.curr() + a;
                if (f <= 10000 && (f > 2000 || !forbiddenB[f]) && !visited[f][1]) {
                    queue.offer(new Pair(f, true));
                    visited[f][1] = true;
                }
                if (p.forward()) {
                    int back = p.curr() - b;
                    if (back > 0 && (back > 2000 || !forbiddenB[back]) && !visited[back][0]) {
                        queue.offer(new Pair(back, false));
                        visited[back][0] = true;
                    }
                }
            }
            ++ret;
        }
        return -1;
    }

    private static int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }

    private record Pair(int curr, boolean forward) {}
}
// @lc code=end

