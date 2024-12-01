/*
 * @lc app=leetcode id=973 lang=java
 *
 * [973] K Closest Points to Origin
 */

// @lc code=start
class Solution {
    public int[][] kClosest(int[][] points, int k) {
        int n = points.length, l = 0, r = n - 1;
        while (l < r) {
            int m = setPivot(points, l, r);
            if (m == k) {
                break;
            }
            if (m < k) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        int[][] ret = new int[k][2];
        for (int i = 0; i < k; ++i) {
            ret[i][0] = points[i][0];
            ret[i][1] = points[i][1];
        }
        return ret;
    }

    private static int setPivot(int[][] points, int l, int r) {
        int[] p = points[l];
        int dp = dist(p);
        while (l < r) {
            while (l < r && dist(points[r]) >= dp) {
                --r;
            }
            points[l] = points[r];
            while (l < r && dist(points[l]) <= dp) {
                ++l;
            }
            points[r] = points[l]; 
        }
        points[l] = p;
        return l;
    }

    private static int dist(int[] p) {
        return p[0] * p[0] + p[1] * p[1];
    }
}
// @lc code=end

