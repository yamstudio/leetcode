/*
 * @lc app=leetcode id=1442 lang=java
 *
 * [1442] Count Triplets That Can Form Two Arrays of Equal XOR
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int countTriplets(int[] arr) {
        Map<Integer, Integer> count = new HashMap<>(), indexSum = new HashMap<>();
        int ret = 0, n = arr.length, xor = 0;
        count.put(0, 1);
        indexSum.put(0, 0);
        for (int i = 0; i < n; ++i) {
            xor ^= arr[i];
            int c = count.getOrDefault(xor, 0);
            if (c == 0) {
                count.put(xor, 1);
                indexSum.put(xor, i + 1);
                continue;
            }
            int sum = indexSum.get(xor);
            ret += c * i - sum;
            count.put(xor, c + 1);
            indexSum.put(xor, sum + i + 1);
        }
        return ret;
    }
}
// @lc code=end

