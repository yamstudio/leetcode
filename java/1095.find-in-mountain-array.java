/*
 * @lc app=leetcode id=1095 lang=java
 *
 * [1095] Find in Mountain Array
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * interface MountainArray {
 *     public int get(int index) {}
 *     public int length() {}
 * }
 */
 
class Solution {
    public int findInMountainArray(int target, MountainArray mountainArr) {
        Map<Integer, Integer> cache = new HashMap<>();
        int n = mountainArr.length(), l = 0, r = n - 1, cand = -1;
        while (l < r) {
            int m = (l + r) / 2, mv = get(cache, mountainArr, m);
            if (mv == target) {
                if (cand < 0) {
                    cand = m;
                } else if (cand != m) {
                    return Math.min(m, cand);
                }
            }
            int mnv = get(cache, mountainArr, m + 1);
            if (mnv == target) {
                if (cand < 0) {
                    cand = m + 1;
                } else if (cand != m + 1) {
                    return Math.min(m + 1, cand);
                }
            }
            if (mv < mnv) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        int p = l;
        if (cand >= 0 && cand <= p) {
            return cand;
        }
        l = 0;
        r = p - 1;
        while (l < r) {
            int m = (l + r) / 2, mv = get(cache, mountainArr, m);
            if (mv == target) {
                return m;
            }
            if (mv < target) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        if (get(cache, mountainArr, l) == target) {
            return l;
        }
        if (cand > p) {
            return cand;
        }
        l = p + 1;
        r = n - 1;
        while (l < r) {
            int m = (l + r) / 2, mv = get(cache, mountainArr, m);
            if (mv == target) {
                return m;
            }
            if (mv > target) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        if (get(cache, mountainArr, r) == target) {
            return r;
        }
        return -1;
    }

    private static int get(Map<Integer, Integer> cache, MountainArray mountainArr, int k) {
        Integer v = cache.get(k);
        if (v != null) {
            return v;
        }
        v = mountainArr.get(k);
        cache.put(k, v);
        return v;
    }
}
// @lc code=end

interface MountainArray {
    int get(int index);
    int length();
}
