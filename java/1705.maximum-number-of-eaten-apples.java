/*
 * @lc app=leetcode id=1705 lang=java
 *
 * [1705] Maximum Number of Eaten Apples
 */

import java.util.Queue;
import java.util.PriorityQueue;

// @lc code=start
class Solution {
    public int eatenApples(int[] apples, int[] days) {
        int n = apples.length, ret = 0, i;
        Queue<Apple> queue = new PriorityQueue<>(n, java.util.Comparator.comparing(Apple::end));
        for (i = 0; i < n; ++i) {
            while (!queue.isEmpty() && queue.peek().end() <= i) {
                queue.poll();
            }
            if (apples[i] > 0) {
                queue.offer(new Apple(apples[i], i + days[i]));
            }
            if (!queue.isEmpty()) {
                Apple apple = queue.poll();
                ++ret;
                if (apple.count() > 1) {
                    queue.offer(new Apple(apple.count() - 1, apple.end()));
                }
            }
        }
        while (!queue.isEmpty()) {
            Apple apple = queue.poll();
            if (apple.end() > i) {
                int e = Math.min(apple.count(), apple.end() - i);
                ret += e;
                i = Math.min(apple.end(), i + e);
            }
        }
        return ret;
    }

    private record Apple(int count, int end) {}
}
// @lc code=end

