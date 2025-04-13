/*
 * @lc app=leetcode id=1569 lang=java
 *
 * [1569] Number of Ways to Reorder Array to Get Same BST
 */

import java.util.ArrayList;
import java.util.List;
import java.util.stream.IntStream;

// @lc code=start

class Solution {
    public int numOfWays(int[] nums) {
        int n = nums.length;
        int[][] choose = new int[n][n];
        for (int i = 0; i < n; ++i) {
            choose[i][0] = 1;
            choose[i][i] = 1;
            for (int j = 1; j < i; ++j) {
                choose[i][j] = (choose[i - 1][j - 1] + choose[i - 1][j]) % 1000000007;
            }
        }
        return numOfWays(IntStream.of(nums).boxed().toList(), choose) - 1;
    }

    private static int numOfWays(List<Integer> nums, int[][] choose) {
        int k = nums.size();
        if (k <= 2) {
            return 1;
        }
        int piv = nums.get(0);
        List<Integer> left = new ArrayList<>(), right = new ArrayList<>();
        for (int i = 1; i < k; ++i) {
            int x = nums.get(i);
            if (x < piv) {
                left.add(x);
            } else {
                right.add(x);
            }
        }
        return (int)(((long)choose[k - 1][left.size()] * (((long)numOfWays(left, choose) * (long)numOfWays(right, choose)) % 1000000007)) % 1000000007);
    }
}
// @lc code=end

