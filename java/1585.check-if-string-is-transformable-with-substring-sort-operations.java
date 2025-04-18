/*
 * @lc app=leetcode id=1585 lang=java
 *
 * [1585] Check If String Is Transformable With Substring Sort Operations
 */

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

// @lc code=start

class Solution {
    public boolean isTransformable(String s, String t) {
        List<Queue<Integer>> indices = new ArrayList<>(10);
        for (int i = 0; i < 10; ++i) {
            indices.add(new ArrayDeque<>());
        }
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            indices.get(s.charAt(i) - '0').add(i);
        }
        for (int i = 0; i < n; ++i) {
            int d = t.charAt(i) - '0';
            Integer right = indices.get(d).poll();
            if (right == null) {
                return false;
            }
            for (int p = 0; p < d; ++p) {
                Integer left = indices.get(p).peek();
                if (left != null && left < right) {
                    return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

