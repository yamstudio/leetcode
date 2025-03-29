/*
 * @lc app=leetcode id=1504 lang=java
 *
 * [1504] Count Submatrices With All Ones
 */

import java.util.Stack;

// @lc code=start
class Solution {
    public int numSubmat(int[][] mat) {
        int m = mat.length, n = mat[0].length, ret = 0;
        int[][] sums = new int[2][n];
        int[] upCount = new int[n];
        Stack<Integer> stack = new Stack<>();
        for (int i = 0; i < m; ++i) {
            int[] sum = sums[i % 2];
            int[] row = mat[i];
            stack.clear();
            for (int j = 0; j < n; ++j) {
                if (row[j] == 0) {
                    stack.clear();
                    stack.push(j);
                    upCount[j] = 0;
                    sum[j] = 0;
                    continue;
                }
                ++upCount[j];
                while (!stack.empty() && upCount[stack.peek()] >= upCount[j]) {
                    stack.pop();
                }
                if (stack.empty()) {
                    sum[j] = upCount[j] * (j + 1);
                } else {
                    int p = stack.peek();
                    sum[j] = sum[p] + upCount[j] * (j - p);
                }
                ret += sum[j];
                stack.push(j);
            }
        }
        return ret;
    }
}
// @lc code=end

