/*
 * @lc app=leetcode id=1659 lang=java
 *
 * [1659] Maximize Grid Happiness
 */

// @lc code=start
class Solution {
    public int getMaxGridHappiness(int m, int n, int introvertsCount, int extrovertsCount) {
        return getMaxGridHappiness(m, n, introvertsCount, extrovertsCount, 0, 0, 0, 0, new Integer[m][n][introvertsCount + 1][extrovertsCount + 1][1 << n][1 << n]);
    }

    private static int getMaxGridHappiness(int m, int n, int introvertsCount, int extrovertsCount, int i, int j, int introState, int extroState, Integer[][][][][][] dp) {
        if (i >= m) {
            return 0;
        }
        Integer d = dp[i][j][introvertsCount][extrovertsCount][introState][extroState];
        if (d != null) {
            return d;
        }
        int nextIntroState = (introState << 1) & ((1 << n) - 1), nextExtroState = (extroState << 1) & ((1 << n) - 1), ni = i + ((j + 1) / n), nj = (j + 1) % n, ret = getMaxGridHappiness(m, n, introvertsCount, extrovertsCount, ni, nj, nextIntroState, nextExtroState, dp);
        if (introvertsCount > 0) {
            ret = Math.max(ret, 120 + getDiff(m, n, i, j, introState, extroState, -30) + getMaxGridHappiness(m, n, introvertsCount - 1, extrovertsCount, ni, nj, nextIntroState | 1, nextExtroState, dp));
        }
        if (extrovertsCount > 0) {
            ret = Math.max(ret, 40 + getDiff(m, n, i, j, introState, extroState, 20) + getMaxGridHappiness(m, n, introvertsCount, extrovertsCount - 1, ni, nj, nextIntroState, nextExtroState | 1, dp));
        }
        dp[i][j][introvertsCount][extrovertsCount][introState][extroState] = ret;
        return ret;
    }

    private static int getDiff(int m, int n, int i, int j, int introState, int extroState, int base) {
        int ret = 0;
        if (i > 0) {
            int mask = 1 << (n - 1);
            if ((introState & mask) != 0) {
                ret += base - 30;
            }
            if ((extroState & mask) != 0) {
                ret += base + 20;
            }
        }
        if (j > 0) {
            if ((introState & 1) != 0) {
                ret += base - 30;
            }
            if ((extroState & 1) != 0) {
                ret += base + 20;
            }
        }
        return ret;
    }
}
// @lc code=end

