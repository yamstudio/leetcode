/*
 * @lc app=leetcode id=969 lang=java
 *
 * [969] Pancake Sorting
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

class Solution {
    public List<Integer> pancakeSort(int[] arr) {
        int n = arr.length;
        List<Integer> ret = new ArrayList<>(n * 2);
        for (int i = 0; i < n; ++i) {
            int maxIndex = 0, endIndex = n - 1 - i;
            for (int j = 1; j <= endIndex; ++j) {
                if (arr[j] > arr[maxIndex]) {
                    maxIndex = j;
                }
            }
            if (maxIndex == endIndex) {
                continue;
            }
            if (maxIndex > 0) {
                flip(arr, maxIndex);
                ret.add(maxIndex + 1);
            }
            if (endIndex > 0) {
                flip(arr, endIndex);
                ret.add(endIndex + 1);
            }
        }
        return ret;
    }

    private static void flip(int[] arr, int endIndex) {
        for (int i = 0; 2 * i < endIndex; ++i) {
            int tmp = arr[i];
            arr[i] = arr[endIndex - i];
            arr[endIndex - i] = tmp;
        }
    }
}
// @lc code=end

