/*
 * @lc app=leetcode id=1224 lang=java
 *
 * [1224] Maximum Equal Frequency
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public int maxEqualFreq(int[] nums) {
        int n = nums.length, ret = 2;
        int[] numToFreq = new int[100001];
        int[] freqToNum = new int[n + 1];
        Set<Integer> freqs = new HashSet<>();
        for (int i = 0; i < n; ++i) {
            int num = nums[i], freq = numToFreq[num];
            if (freq > 0 && --freqToNum[freq] == 0) {
                freqs.remove(freq);
            }
            ++freq;
            freqs.add(freq);
            ++freqToNum[freq];
            ++numToFreq[num];
            if (freqs.size() > 2) {
                continue;
            }
            if (freqs.size() == 1) {
                if (freq == 1 || freqToNum[freq] == 1) {
                    ret = i + 1;
                }
                continue;
            }
            var it = freqs.iterator();
            int a = it.next(), b = it.next(), max = Math.max(a, b), min = a + b - max;
            if ((min == 1 && freqToNum[min] == 1) || (max - min == 1 && freqToNum[max] == 1)) {
                ret = i + 1;
            }
        }
        return ret;
    }
}
// @lc code=end

