/*
 * @lc app=leetcode id=1659 lang=csharp
 *
 * [1659] Maximize Grid Happiness
 */

using System;

// @lc code=start
public class Solution {

    private static int CountNeighbor(int n, int i, int j, int iMask, int eMask, int delta) {
        int ret = 0;
        if (i > 0) {
            int mask = 1 << (n - 1);
            if ((mask & iMask) != 0) {
                ret += delta - 30;
            }
            if ((mask & eMask) != 0) {
                ret += delta + 20;
            }
        }
        if (j > 0) {
            if ((1 & iMask) != 0) {
                ret += delta - 30;
            }
            if ((1 & eMask) != 0) {
                ret += delta + 20;
            }
        }
        return ret;
    }

    private static int GetMaxGridHappiness(int m, int n, int i, int j, int introvertsCount, int extrovertsCount, int iMask, int eMask, int?[,,,,,] memo) {
        if (i >= m) {
            return 0;
        }
        if (memo[i, j, introvertsCount, extrovertsCount, iMask, eMask].HasValue) {
            return memo[i, j, introvertsCount, extrovertsCount, iMask, eMask].Value;
        }
        int ni, nj, niMask = (iMask << 1) & ((1 << n) - 1), neMask = (eMask << 1) & ((1 << n) - 1);
        if (j == n - 1) {
            ni = i + 1;
            nj = 0;
        } else {
            ni = i;
            nj = j + 1;
        }
        int ret = GetMaxGridHappiness(m, n, ni, nj, introvertsCount, extrovertsCount, niMask, neMask, memo);
        if (introvertsCount > 0) {
            int nb = CountNeighbor(n, i, j, iMask, eMask, -30);
            ret = Math.Max(ret, 120 + nb + GetMaxGridHappiness(m, n, ni, nj, introvertsCount - 1, extrovertsCount, niMask | 1, neMask, memo));
        }
        if (extrovertsCount > 0) {
            int nb = CountNeighbor(n, i, j, iMask, eMask, 20);
            ret = Math.Max(ret, 40 + nb + GetMaxGridHappiness(m, n, ni, nj, introvertsCount, extrovertsCount - 1, niMask, neMask | 1, memo));
        }
        memo[i, j, introvertsCount, extrovertsCount, iMask, eMask] = ret;
        return ret;
    }

    public int GetMaxGridHappiness(int m, int n, int introvertsCount, int extrovertsCount) {
        return GetMaxGridHappiness(m, n, 0, 0, introvertsCount, extrovertsCount, 0, 0, new int?[m, n, introvertsCount + 1, extrovertsCount + 1, 1 << n, 1 << n]);
    }
}
// @lc code=end

