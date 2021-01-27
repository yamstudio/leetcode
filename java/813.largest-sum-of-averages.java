/*
 * @lc app=leetcode id=813 lang=java
 *
 * [813] Largest Sum of Averages
 */

// @lc code=start
class Solution {

    private static double largestSumOfAverages(int[] A, int i, int k, Map<String, Double> memo) {
        String key = String.format("%d,%d", i, k);
        if (memo.containsKey(key)) {
            return memo.get(key);
        }
        double sum = 0, ret = 0;
        for (int j = i; j + k <= A.length; ++j) {
            sum += (double)A[j];
            if (k > 1) {
                ret = Math.max(ret, sum / (double)(j - i + 1) + largestSumOfAverages(A, j + 1, k - 1, memo));
            }
        }
        if (k == 1) {
            ret = sum / (double)(A.length - i);
        }
        memo.put(key, ret);
        return ret;
    }

    public double largestSumOfAverages(int[] A, int K) {
        return largestSumOfAverages(A, 0, K, new HashMap<String, Double>());
    }
}
// @lc code=end

