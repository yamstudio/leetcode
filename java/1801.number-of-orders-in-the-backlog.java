/*
 * @lc app=leetcode id=1801 lang=java
 *
 * [1801] Number of Orders in the Backlog
 */

import java.util.Queue;
import java.util.PriorityQueue;

// @lc code=start

import static java.util.Comparator.comparingInt;

class Solution {
    public int getNumberOfBacklogOrders(int[][] orders) {
        Queue<Order> sells = new PriorityQueue<>(comparingInt(Order::price)), buys = new PriorityQueue<>(comparingInt(Order::price).reversed());
        for (int[] order : orders) {
            int price = order[0], amount = order[1];
            if (order[2] == 0) {
                execute(buys, sells, price, amount, 1);
            } else {
                execute(sells, buys, price, amount, -1);
            }
        }
        return (int)(((long)empty(sells) + (long)empty(buys)) % 1000000007);
    }

    private static void execute(Queue<Order> ours, Queue<Order> theirs, int price, int amount, int mul) {
        while (!theirs.isEmpty() && mul * (price - theirs.peek().price()) >= 0) {
            Order o = theirs.poll();
            if (o.amount() > amount) {
                theirs.offer(new Order(o.price(), o.amount() - amount));
                amount = 0;
                break;
            } else if (o.amount() == amount) {
                amount = 0;
                break;
            } else {
                amount -= o.amount();
            }
        }
        if (amount > 0) {
            ours.offer(new Order(price, amount));
        }
    }

    private static int empty(Queue<Order> queue) {
        int ret = 0;
        while (!queue.isEmpty()) {
            ret = (int)(((long)ret + (long)queue.poll().amount()) % 1000000007);
        }
        return ret;
    }

    private record Order(int price, int amount) {}
}
// @lc code=end

