/*
 * @lc app=leetcode id=1776 lang=java
 *
 * [1776] Car Fleet II
 */

// @lc code=start

import java.util.Stack;

class Solution {
    public double[] getCollisionTimes(int[][] cars) {
        int n = cars.length;
        double[] ret = new double[n];
        Stack<Car> stack = new Stack<>();
        for (int i = n - 1; i >= 0; --i) {
            int[] car = cars[i];
            double pos = car[0], sp = car[1];
            while (!stack.isEmpty()) {
                Car p = stack.peek();
                if (sp > p.sp() && p.col() > (p.pos() - pos) / (sp - p.sp())) {
                    break;
                }
                stack.pop();
            }
            if (stack.isEmpty()) {
                stack.push(new Car(pos, sp, Double.MAX_VALUE));
                ret[i] = -1;
                continue;
            }
            Car p = stack.peek();
            double t = (p.pos() - pos) / (sp - p.sp());
            stack.push(new Car(pos, sp, t));
            ret[i] = t;
        }
        return ret;
    }

    private static record Car(double pos, double sp, double col) {}
}
// @lc code=end

