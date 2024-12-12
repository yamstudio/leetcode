/*
 * @lc app=leetcode id=1007 lang=java
 *
 * [1007] Minimum Domino Rotations For Equal Row
 */

// @lc code=start
class Solution {
    public int minDominoRotations(int[] tops, int[] bottoms) {
        int n = tops.length, t = 0, tf = 1, b = 0, bf = 1, ta = tops[0], ba = bottoms[0];
        for (int i = 1; i < n && (t >= 0 || tf >= 0 || b >= 0 || bf >= 0); ++i) {
            if (t >= 0) {
                if (tops[i] != ta) {
                    if (bottoms[i] != ta) {
                        t = -1;
                    } else {
                        ++t;
                    }
                }
            }
            if (tf >= 0) {
                if (bottoms[i] != ta) {
                    if (tops[i] != ta) {
                        tf = -1;
                    } else {
                        ++tf;
                    }
                }
            }
            if (b >= 0) {
                if (bottoms[i] != ba) {
                    if (tops[i] != ba) {
                        b = -1;
                    } else {
                        ++b;
                    }
                }
            }
            if (bf >= 0) {
                if (tops[i] != ba) {
                    if (bottoms[i] != ba) {
                        bf = -1;
                    } else {
                        ++bf;
                    }
                }
            }
        }
        int ret = Integer.MAX_VALUE;
        if (t >= 0) {
            ret = Math.min(ret, t);
        }
        if (tf >= 0) {
            ret = Math.min(ret, tf);
        }
        if (b >= 0) {
            ret = Math.min(ret, b);
        }
        if (b >= 0) {
            ret = Math.min(ret, bf);
        }
        return ret == Integer.MAX_VALUE ? -1 : ret;
    }
}
// @lc code=end

