/*
 * @lc app=leetcode id=823 lang=java
 *
 * [823] Binary Trees With Factors
 */

// @lc code=start
class Solution {
    public int numFactoredBinaryTrees(int[] arr) {
        Map<Integer, Integer> count = new HashMap<Integer, Integer>();
        int n = arr.length;
        long ret = 0;
        Arrays.sort(arr);
        for (int i = 0; i < n; ++i) {
            long c = 1;
            for (int j = 0; j < i; ++j) {
                if (arr[i] % arr[j] == 0 && count.containsKey(arr[i] / arr[j])) {
                    c = (c + (long)count.get(arr[j]) * (long)count.get(arr[i] / arr[j])) % 1000000007;
                }
            }
            count.put(arr[i], (int)c);
            ret = (ret + c) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

