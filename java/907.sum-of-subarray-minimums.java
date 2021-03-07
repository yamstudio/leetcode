/*
 * @lc app=leetcode id=907 lang=java
 *
 * [907] Sum of Subarray Minimums
 */

// @lc code=start
class Solution {
    public int sumSubarrayMins(int[] arr) {
        Stack<Integer> stack = new Stack<Integer>();
        long ret = 0;
        int n = arr.length;
        long[] dp = new long[n];
        for (int i = 0; i < n; ++i) {
            long acc;
            while (stack.size() > 0 && arr[stack.peek()] >= arr[i]) {
                stack.pop();
            }
            if (stack.size() > 0) {
                int t = stack.peek();
                acc = ((long)arr[i] * (long)(i - t) + dp[t]) % 1000000007;
            } else {
                acc = ((long)arr[i] * (i + 1)) % 1000000007;
            }
            dp[i] = acc;
            ret = (acc + ret) % 1000000007;
            stack.push(i);
        }
        return (int)ret;
    }
}
// @lc code=end

