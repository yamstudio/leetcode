/*
 * @lc app=leetcode id=1610 lang=java
 *
 * [1610] Maximum Number of Visible Points
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start
class Solution {
    public int visiblePoints(List<List<Integer>> points, int angle, List<Integer> location) {
        int overlap = 0;
        List<Double> angles = new ArrayList<>();
        for (List<Integer> p : points) {
            double dx = p.get(0) - location.get(0), dy = p.get(1) - location.get(1);
            if (dx == 0) {
                if (dy == 0) {
                    ++overlap;
                } else if (dy > 0) {
                    angles.add(90.);
                } else {
                    angles.add(270.);
                }
                continue;
            }
            double a = Math.atan(dy / dx) * 180 / Math.PI;
            if (dx > 0) {
                if (dy < 0) {
                    a += 360;
                }
            } else {
                a += 180;
            }
            angles.add(a);
            
        }
        Collections.sort(angles);
        int n = angles.size(), r = 0, ret = 0;
        for (int l = 0; l < n;) {
            double a = angles.get(l);
            if (r == l) {
                r = (r + 1) % n;
            }
            while (r > l && angles.get(r) - a <= angle || r < l && angles.get(r) + 360 <= a + angle) {
                r = (r + 1) % n;
            }
            if (r == l) {
                return n + overlap;
            }
            if (r < l) {
                ret = Math.max(ret, r + n - l);
            } else {
                ret = Math.max(ret, r - l);
            }
            for (; l < n && angles.get(l) == a; ++l);
        }
        return ret + overlap;
    }
}
// @lc code=end

