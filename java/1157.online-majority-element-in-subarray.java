/*
 * @lc app=leetcode id=1157 lang=java
 *
 * [1157] Online Majority Element In Subarray
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;

// @lc code=start

import java.time.Clock;

class MajorityChecker {

    private int[] arr;
    private final Random random;
    private final Map<Integer, List<Integer>> valToIndices;

    public MajorityChecker(int[] arr) {
        this.arr = arr;
        random = new Random(Clock.systemUTC().millis());
        valToIndices = new HashMap<>();
        int n = arr.length;
        for (int i = 0; i < n; ++i) {
            valToIndices.computeIfAbsent(arr[i], ignored -> new ArrayList<>()).add(i);
        }
    }
    
    public int query(int left, int right, int threshold) {
        for (int i = 0; i < 20; ++i) {
            int val = arr[left + random.nextInt(right - left + 1)];
            List<Integer> indices = valToIndices.get(val);
            int l = Collections.binarySearch(indices, left);
            int r = Collections.binarySearch(indices, right);
            if (l < 0) {
                l = -l - 1;
            }
            if (r < 0) {
                r = -r - 2;
            }
            if (r - l + 1 >= threshold) {
                return val;
            }
        }
        return -1;
    }
}

/**
 * Your MajorityChecker object will be instantiated and called as such:
 * MajorityChecker obj = new MajorityChecker(arr);
 * int param_1 = obj.query(left,right,threshold);
 */
// @lc code=end

