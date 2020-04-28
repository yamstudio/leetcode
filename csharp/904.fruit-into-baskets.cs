/*
 * @lc app=leetcode id=904 lang=csharp
 *
 * [904] Fruit Into Baskets
 */

using System;

// @lc code=start
public class Solution {
    public int TotalFruit(int[] tree) {
        int t1 = -1, t2 = -1, l1 = -1, l2 = -1, r1 = -1, r2 = -1, l = -1, n = tree.Length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int t = tree[i];
            if (t1 < 0) {
                t1 = t;
                l = i;
                l1 = i;
                r1 = i;
                ret = 1;
                continue;
            }
            if (t == t1) {
                r1 = i;
                ret = Math.Max(ret, i - l + 1);
                continue;
            }
            if (t2 < 0) {
                t2 = t;
                l2 = i;
                r2 = i;
                ret = i - l + 1;
                continue;
            }
            if (t == t2) {
                r2 = i;
                ret = Math.Max(ret, i - l + 1);
                continue;
            }
            if (r1 < r2) {
                l2 = r1 + 1;
                l = l2;
                t1 = t;
                l1 = i;
                r1 = i;
            } else {
                l1 = r2 + 1;
                l = l1;
                t2 = t;
                l2 = i;
                r2 = i;
            }
            ret = Math.Max(ret, i - l + 1);
        }
        return ret;
    }
}
// @lc code=end

