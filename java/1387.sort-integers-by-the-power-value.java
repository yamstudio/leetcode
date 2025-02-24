/*
 * @lc app=leetcode id=1387 lang=java
 *
 * [1387] Sort Integers by The Power Value
 */

import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

class Solution {
    public int getKth(int lo, int hi, int k) {
        Map<Integer, Integer> powers = new HashMap<>();
        powers.put(1, 0);
        Queue<Pair> queue = new PriorityQueue<>(k + 1);
        for (int i = lo; i <= hi; ++i) {
            int power = getPower(powers, i);
            queue.offer(new Pair(power, i));
            if (queue.size() > k) {
                queue.poll();
            }
        }
        return queue.poll().val();
    }

    private static int getPower(Map<Integer, Integer> powers, int val) {
        Integer memo = powers.get(val);
        if (memo != null) {
            return memo;
        }
        int m;
        if (val % 2 == 1) {
            m = 1 + getPower(powers, val * 3 + 1);
        } else {
            m = 1 + getPower(powers, val / 2);
        }
        powers.put(val, m);
        return m;
    }

    private record Pair(int power, int val) implements Comparable<Pair> {
        @Override
        public int compareTo(Pair other) {
            if (power != other.power) {
                return other.power - power;
            }
            return other.val - val;
        }
    }
}
// @lc code=end

